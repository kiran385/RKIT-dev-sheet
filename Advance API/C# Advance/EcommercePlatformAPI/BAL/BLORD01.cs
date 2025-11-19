using EcommercePlatformAPI.MAL;
using EcommercePlatformAPI.MAL.DTO;
using EcommercePlatformAPI.MAL.POCO;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Data;
using System.Linq;
using System.Web;

namespace EcommercePlatformAPI.BAL
{
    /// <summary>
    /// Business logic class for order
    /// </summary>
    public class BLORD01
    {
        private readonly IDbConnectionFactory _dbFactory;
        private Response _objResponse;
        private ORD01 _objORD01;
        private int _id;

        public EnumType Type { get; set; }

        /// <summary>
        /// Constuctor for class BLORD01
        /// </summary>
        /// <exception cref="Exception">Throw exception if DB connection not happend properly</exception>
        public BLORD01()
        {
            _objResponse = new Response();
            _dbFactory = HttpContext.Current.Application[Message.M01] as IDbConnectionFactory;

            //Checking if connection is their or not
            if (_dbFactory == null)
            {
                throw new Exception(Message.M02);
            }
        }

        /// <summary>
        /// Get all orders
        /// </summary>
        /// <returns>Response containing Message and Data of orders</returns>
        public Response GetAllOrders()
        {
            using(IDbConnection db = _dbFactory.OpenDbConnection())
            {
                _objResponse.Data = db.Select<ORD01>();
            }
            _objResponse.IsError = _objResponse.Data == null;
            _objResponse.Message = _objResponse.IsError ? Message.M03 : _objResponse.Data.Count == 0 ? Message.M04 : Message.M05;
            return _objResponse;
        }

        /// <summary>
        /// Get order by id
        /// </summary>
        /// <param name="id">Order id</param>
        /// <returns>Response containing Message and Data of order</returns>
        public Response GetOrderById(int id)
        {
            using(IDbConnection db = _dbFactory.OpenDbConnection())
            {
                _objResponse.Data = db.SingleById<ORD01>(id);
            }
            _objResponse.IsError = _objResponse.Data == null;
            _objResponse.Message = _objResponse.IsError ? Message.M04 : Message.M05;
            return _objResponse;
        }

        /// <summary>
        /// Get all pending orders
        /// </summary>
        /// <returns>Response containing data of pending orders</returns>
        public Response GetPendingOrders()
        {
            using(IDbConnection db = _dbFactory.OpenDbConnection())
            {
                SqlExpression<ORD01> q = db.From<ORD01>()
                    .Where(o => o.D01F05 == EnumStatus.pending);
                _objResponse.Data = db.Select(q);
            }
            _objResponse.IsError = _objResponse.Data == null;
            _objResponse.Message = _objResponse.IsError ? Message.M04 : Message.M05;
            return _objResponse;
        }

        /// <summary>
        /// Checks if order delivery status is pending or success 
        /// </summary>
        /// <param name="id">Order id</param>
        /// <returns>Response containing Message for status of order delivery</returns>
        public Response CheckOrderStatus(int id)
        {
            if (!GetOrderById(id).IsError)
            {
                using (IDbConnection db = _dbFactory.OpenDbConnection())
                {
                    _objResponse.Data = db.Column<string>(
                        db.From<ORD01>()
                        .Where(o => o.D01F01 == id)
                        .Select(o => o.D01F05));
                }
            }
            return _objResponse;
        }

        /// <summary>
        /// PreSave method for performing operations before add or update data
        /// </summary>
        /// <param name="objDTO">DTO Order data</param>
        public void PreSave(DTOORD01 objDTO)
        {
            _objORD01 = objDTO.Convert<ORD01>();
            
            if(Type == EnumType.A)
            {
                _objORD01.D01F05 = EnumStatus.pending;
                _objORD01.D01F06 = DateTime.Now;
                using(IDbConnection db = _dbFactory.OpenDbConnection())
                {
                    int price = db.Scalar<int>(
                        db.From<PRD01>()
                        .Where(p => p.D01F01 == objDTO.D01F02)
                        .Select(p => p.D01F04));
                    _objORD01.D01F04 = _objORD01.D01F03 * price;
                }
            }
            else
            {
                _objORD01.D01F05 = EnumStatus.success;
                _id = objDTO.D01F01;
            }
        }

        /// <summary>
        /// Validation method for check if data entered is valid or not before add or update operation
        /// </summary>
        /// <returns>Response containing appropriate message</returns>
        public Response Validation()
        {
            if (Type == EnumType.U)
            {
                if (!(_id >= 0) || GetOrderById(_id).IsError)
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = Message.M06;
                }
                else if (CheckOrderStatus(_id).Data[0] == "success")
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = Message.M11;
                }
            }
            return _objResponse;
        }

        /// <summary>
        /// Save method for add or update order data
        /// </summary>
        /// <returns>Response containing appropriate message and data which is added or updated</returns>
        public Response Save()
        {
            try
            {
                if (Type == EnumType.A)
                {
                    using (IDbConnection db = _dbFactory.OpenDbConnection())
                    {
                        int id = (int)db.Insert(_objORD01, selectIdentity: true);
                    }
                    _objResponse.Message = Message.M07;
                    _objResponse.Data = _objORD01;
                }
                else
                {
                    using (IDbConnection db = _dbFactory.OpenDbConnection())
                    {
                        ORD01 objORD01 = db.SingleById<ORD01>(_objORD01.D01F01);
                        PRD01 objPRD01 = db.SingleById<PRD01>(objORD01.D01F02);

                        if(objPRD01.InStock(objORD01.D01F03))
                        {
                            db.UpdateOnly(() =>
                            new PRD01 { D01F03 = objPRD01.D01F03 - objORD01.D01F03 },
                            where: p => p.D01F01 == objORD01.D01F02);

                            db.Update(objORD01);
                            _objResponse.Message = Message.M08;
                        }
                        else
                        {
                            _objResponse.IsError = true;
                            _objResponse.Message = Message.M10;
                        }

                        //int productQuantity = db.Scalar<int>(
                        //    db.From<PRD01>()
                        //    .Where(p => p.D01F01 == _objORD01.D01F02)
                        //    .Select(p => p.D01F03));
                        //int orderQuantity = db.Scalar<int>(
                        //    db.From<ORD01>()
                        //    .Where(o => o.D01F01 == _objORD01.D01F01)
                        //    .Select(o => o.D01F03));
                        //db.UpdateOnly(() =>
                        //new PRD01 { D01F03 = productQuantity - orderQuantity },
                        //where: p => p.D01F01 == _objORD01.D01F02);

                        //db.Update(_objORD01);
                        //_objResponse.Message = Message.M08;
                    }
                }
            }
            catch (Exception ex)
            {
                _objResponse.IsError = true;
                _objResponse.Message = ex.Message;
                _objResponse.Data = null;
            }
            return _objResponse;
        }

        /// <summary>
        /// Delete method for delete order by its id
        /// </summary>
        /// <param name="id">Order id</param>
        /// <returns>Response containing message if order deleted or not</returns>
        public Response Delete(int id)
        {
            try
            {
                if (!(id >= 0) || GetOrderById(id).IsError)
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = Message.M06;
                }
                else
                {
                    using (IDbConnection db = _dbFactory.OpenDbConnection())
                    {
                        db.DeleteById<ORD01>(id);
                    }
                    _objResponse.Data = null;
                    _objResponse.IsError = false;
                    _objResponse.Message = Message.M09;
                }
            }
            catch (Exception ex)
            {
                _objResponse.IsError = true;
                _objResponse.Message = ex.Message;
                _objResponse.Data = null;
            }
            return _objResponse;
        }
    }
}