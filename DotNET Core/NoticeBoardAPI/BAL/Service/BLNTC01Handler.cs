using Mysqlx.Crud;
using NoticeBoardAPI.BAL.Interface;
using NoticeBoardAPI.MAL;
using NoticeBoardAPI.MAL.DTO;
using NoticeBoardAPI.MAL.POCO;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System.Data;
using System.Security.Cryptography;

namespace NoticeBoardAPI.BAL.Service
{
    public class BLNTC01Handler : INTC01Service
    {
        /// <summary>
        /// Instance of IDbConnectionFactory
        /// </summary>
        private readonly IDbConnectionFactory _dbFactory;

        /// <summary>
        /// Instance of response
        /// </summary>
        private Response _objResponse;

        /// <summary>
        /// Instance of NTC01 modal
        /// </summary>
        private NTC01 _objNTC01;

        /// <summary>
        /// Id
        /// </summary>
        private int _id;

        /// <summary>
        /// Enum for Add or Update data
        /// </summary>
        public EnumType Type { get; set; }

        /// <summary>
        /// Constructor initializes response and IDbConnectionFactory instance
        /// </summary>
        /// <param name="dbFactory">IDbConnectionFactory instance</param>
        /// <exception cref="Exception">Exception thrown if IDbConnectionFactory not initializes properly</exception>
        public BLNTC01Handler(IDbConnectionFactory dbFactory)
        {
            _objResponse = new Response();
            _dbFactory = dbFactory;

            //Checking if connection is their or not
            if (_dbFactory == null)
            {
                throw new Exception(Message.M02);
            }
        }

        /// <summary>
        /// Get all notices
        /// </summary>
        /// <returns>Response contains data of notices</returns>
        public Response GetNotice()
        {
            using (IDbConnection db = _dbFactory.OpenDbConnection())
            {
                _objResponse.Data = db.Select<NTC01>();
            }
            _objResponse.IsError = _objResponse.Data == null;
            _objResponse.Message = _objResponse.IsError ? Message.M03 : _objResponse.Data.Count == 0 ? Message.M04 : Message.M05;
            return _objResponse;
        }

        /// <summary>
        /// Get notice by id
        /// </summary>
        /// <param name="id">Notice id</param>
        /// <returns>Response containing notice data</returns>
        public Response GetNoticeById(int id)
        {
            using (IDbConnection db = _dbFactory.OpenDbConnection())
            {
                _objResponse.Data = db.SingleById<NTC01>(id);
            }
            _objResponse.IsError = _objResponse.Data == null;
            _objResponse.Message = _objResponse.IsError ? Message.M04 : Message.M05;
            return _objResponse;
        }

        /// <summary>
        /// Convert DTO to POCO before add or update operation
        /// </summary>
        /// <param name="objDTO">DTONTC01 instance</param>
        public void PreSave(DTONTC01 objDTO)
        {
            _objNTC01 = objDTO.Convert<NTC01>();

            if (Type == EnumType.A)
            {
                _objNTC01.C01F04 = DateTime.Now;
            }
            else
            {
                _id = objDTO.C01F01;
            }
        }

        /// <summary>
        /// Validate data before add or update operation
        /// </summary>
        /// <returns>Response contains proper message if any error is occured or not</returns>
        public Response Validation()
        {
            if (Type == EnumType.U)
            {
                if (!(_id >= 0) || GetNoticeById(_id).IsError)
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = Message.M06;
                }
            }
            return _objResponse;
        }

        /// <summary>
        /// Perform Add and Update operation
        /// </summary>
        /// <returns>Response contains proper message if any error is occured or not</returns>
        public Response Save()
        {
            try
            {
                if (Type == EnumType.A)
                {
                    using (IDbConnection db = _dbFactory.OpenDbConnection())
                    {
                        long id = db.Insert(_objNTC01, selectIdentity: true);
                    }
                    _objResponse.Message = Message.M07;
                    _objResponse.Data = _objNTC01;
                }
                else
                {
                    using (IDbConnection db = _dbFactory.OpenDbConnection())
                    {
                        long id = db.Update(_objNTC01);
                    }
                    _objResponse.Message = Message.M08;
                    _objResponse.Data = _objNTC01;
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
        /// Delete notice by id
        /// </summary>
        /// <param name="id">Notice id</param>
        /// <returns>Response contains is notice deleted or not</returns>
        public Response Delete(int id)
        {
            try
            {
                if (!(id >= 0) || GetNoticeById(id).IsError)
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = Message.M06;
                }
                else
                {
                    using (IDbConnection db = _dbFactory.OpenDbConnection())
                    {
                        db.DeleteById<NTC01>(id);
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
