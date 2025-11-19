using EcommercePlatformAPI.MAL;
using EcommercePlatformAPI.MAL.DTO;
using EcommercePlatformAPI.MAL.POCO;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommercePlatformAPI.BAL
{
    /// <summary>
    /// Business logic class for product
    /// </summary>
    public class BLPRD01
    {
        private readonly IDbConnectionFactory _dbFactory;
        private Response _objResponse;
        private PRD01 _objPRD01;
        private int _id;

        public EnumType Type { get; set; }

        /// <summary>
        /// Constuctor for class BLPRD01
        /// </summary>
        /// <exception cref="Exception">Throw exception if DB connection not happend properly</exception>
        public BLPRD01()
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
        /// Get all products
        /// </summary>
        /// <returns>Response containing Message and Data of products</returns>
        public Response GetAllProducts()
        {
            using(IDbConnection db = _dbFactory.OpenDbConnection())
            {
                _objResponse.Data = db.Select<PRD01>();
            }
            _objResponse.IsError = _objResponse.Data == null;
            _objResponse.Message = _objResponse.IsError ? Message.M03 : _objResponse.Data.Count == 0 ? Message.M04 : Message.M05;
            return _objResponse;
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns>Response containing Message and Data of product</returns>
        public Response GetProductById(int id)
        {
            using(IDbConnection db = _dbFactory.OpenDbConnection())
            {
                _objResponse.Data = db.SingleById<PRD01>(id);
            }
            _objResponse.IsError = _objResponse.Data == null;
            _objResponse.Message = _objResponse.IsError ? Message.M04 : Message.M05;
            return _objResponse;
        }

        /// <summary>
        /// Get list of orders corresponding to every product id
        /// </summary>
        /// <returns>Returns list of orders corresponding to every product id</returns>
        public Response GetProductOrders()
        {
            using(IDbConnection db = _dbFactory.OpenDbConnection())
            {
                List<PRD01> products = db.Select<PRD01>();
                List<ORD01> orders = db.Select<ORD01>();

                List<DTOPRDORD01> result = products.Select(p => new DTOPRDORD01
                {
                    D01F01 = p.D01F01,
                    D01F02 = orders.Where(o => o.D01F02 == p.D01F01).ToList()
                }).ToList();
                _objResponse.Data = result;
            }
            _objResponse.IsError = _objResponse.Data == null;
            _objResponse.Message = _objResponse.IsError ? Message.M04 : Message.M05;
            return _objResponse;
        }

        /// <summary>
        /// PreSave method for performing operations before add or update data
        /// </summary>
        /// <param name="objDTO">DTO Product data</param>
        public void PreSave(DTOPRD01 objDTO)
        {
            _objPRD01 = objDTO.Convert<PRD01>();
            _id = Type == EnumType.U ? objDTO.D01F01 : 0;
        }

        /// <summary>
        /// Validation method for check if data entered is valid or not before add or update operation
        /// </summary>
        /// <returns>Response containing appropriate message</returns>
        public Response Validation()
        {
            if(Type == EnumType.U)
            {
                if (!(_id >= 0) || GetProductById(_id).IsError)
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = Message.M06;
                }
            }
            return _objResponse;
        }

        /// <summary>
        /// Save method for add or update product data
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
                        int id = (int)db.Insert(_objPRD01, selectIdentity: true);
                    }
                    _objResponse.Message = Message.M07;
                    _objResponse.Data = _objPRD01;
                }
                else
                {
                    using (IDbConnection db = _dbFactory.OpenDbConnection())
                    {
                        db.Update(_objPRD01);
                    }
                    _objResponse.Message = Message.M08;
                }
            }
            catch(Exception ex)
            {
                _objResponse.IsError = true;
                _objResponse.Message = ex.Message;
                _objResponse.Data = null;
            }
            return _objResponse;
        }

        /// <summary>
        /// Delete method for delete product by its id
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns>Response containing message if product deleted or not</returns>
        public Response Delete(int id)
        {
            try
            {
                if (!(id >= 0) || GetProductById(id).IsError)
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = Message.M06;
                }
                else
                {
                    using (IDbConnection db = _dbFactory.OpenDbConnection())
                    {
                        db.DeleteById<PRD01>(id);
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