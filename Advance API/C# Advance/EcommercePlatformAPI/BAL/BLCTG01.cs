using EcommercePlatformAPI.MAL;
using EcommercePlatformAPI.MAL.DTO;
using EcommercePlatformAPI.MAL.POCO;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Data;
using System.Web;

namespace EcommercePlatformAPI.BAL
{
    /// <summary>
    /// Business logic class for category
    /// </summary>
    public class BLCTG01
    {
        private readonly IDbConnectionFactory _dbFactory;
        private Response _objResponse;
        private CTG01 _objCTG01;
        private int _id;

        public EnumType Type { get; set; }

        /// <summary>
        /// Constuctor for class BLCTG01
        /// </summary>
        /// <exception cref="Exception">Throw exception if DB connection not happend properly</exception>
        public BLCTG01()
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
        /// Get all categories
        /// </summary>
        /// <returns>Response containing Message and Data of categories</returns>
        public Response GetAllCategory()
        {
            using (IDbConnection db = _dbFactory.OpenDbConnection())
            {
                _objResponse.Data = db.Select<CTG01>();
            }
            _objResponse.IsError = _objResponse.Data == null;
            _objResponse.Message = _objResponse.IsError ? Message.M03 : _objResponse.Data.Count == 0 ? Message.M04 : Message.M05;
            return _objResponse;
        }

        /// <summary>
        /// Get category by id
        /// </summary>
        /// <param name="id">Category id</param>
        /// <returns>Response containing Message and Data of category</returns>
        public Response GetCategoryById(int id)
        {
            using(IDbConnection db = _dbFactory.OpenDbConnection())
            {
                _objResponse.Data = db.SingleById<CTG01>(id);
            }
            _objResponse.IsError = _objResponse.Data == null;
            _objResponse.Message = _objResponse.IsError ? Message.M04 : Message.M05;
            return _objResponse;
        }

        /// <summary>
        /// PreSave method for performing operations before add or update data
        /// </summary>
        /// <param name="objDTO">DTO Category data</param>
        public void PreSave(DTOCTG01 objDTO)
        {
            _objCTG01 = objDTO.Convert<CTG01>();
            _id = Type == EnumType.U ? objDTO.G01F01 : 0;
        }

        /// <summary>
        /// Validation method for check if data entered is valid or not before add or update operation
        /// </summary>
        /// <returns>Response containing appropriate message</returns>
        public Response Validation()
        {
            if(Type == EnumType.U)
            {
                if (!(_id >= 0) || GetCategoryById(_id).IsError)
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = Message.M06;
                }
            }
            return _objResponse;
        }

        /// <summary>
        /// Save method for add or update category data
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
                        int id = (int)db.Insert(_objCTG01, selectIdentity: true);
                    }
                    _objResponse.Message = Message.M07;
                    _objResponse.Data = _objCTG01;
                }
                else if (Type == EnumType.U)
                {
                    using (IDbConnection db = _dbFactory.OpenDbConnection())
                    {
                        db.Update(_objCTG01);
                    }
                    _objResponse.Message = Message.M08;
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
        /// Delete method for delete category by its id
        /// </summary>
        /// <param name="id">Category id</param>
        /// <returns>Response containing message if category deleted or not</returns>
        public Response Delete(int id)
        {
            try
            {
                if (!(id >= 0) || GetCategoryById(id).IsError)
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = Message.M06;
                }
                else
                {
                    using (IDbConnection db = _dbFactory.OpenDbConnection())
                    {
                        db.DeleteById<CTG01>(id);
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