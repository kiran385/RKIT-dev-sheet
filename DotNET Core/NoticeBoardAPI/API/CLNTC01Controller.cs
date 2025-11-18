using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoticeBoardAPI.BAL.Interface;
using NoticeBoardAPI.BAL.Service;
using NoticeBoardAPI.MAL;
using NoticeBoardAPI.MAL.DTO;

namespace NoticeBoardAPI.API
{
    /// <summary>
    /// Contains all notice board APIs
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,User")]
    public class CLNTC01Controller : ControllerBase
    {
        /// <summary>
        /// Instance of INTC01Service which contains logic of all methods
        /// </summary>
        private readonly INTC01Service _objINTC01;

        /// <summary>
        /// Instance of response
        /// </summary>
        private Response _objResponse;

        /// <summary>
        /// Instance of ILogger
        /// </summary>
        private readonly ILogger<CLNTC01Controller> _logger;

        /// <summary>
        /// Intializes response, INTC01Service and ILogger instance
        /// </summary>
        /// <param name="objINTC01">INTC01Service instance</param>
        /// <param name="logger">ILogger instance</param>
        public CLNTC01Controller(INTC01Service objINTC01, ILogger<CLNTC01Controller> logger)
        {
            _objINTC01 = objINTC01;
            _objResponse = new Response();
            _logger = logger;
        }

        /// <summary>
        /// Get all notices
        /// </summary>
        /// <returns>Response contains data of notices</returns>
        [HttpGet("get_all_notice")]
        public Response GetNotice()
        {
            Response objResponse = _objINTC01.GetNotice();
            return objResponse;
        }

        /// <summary>
        /// Get notice by id
        /// </summary>
        /// <param name="id">Notice id</param>
        /// <returns>Response containing notice data</returns>
        [HttpGet("get_notice_by_id")]
        public Response GetNoticeById(int id)
        {
            Response objResponse = _objINTC01.GetNoticeById(id);
            return objResponse;
        }

        /// <summary>
        /// Add new notice
        /// </summary>
        /// <param name="objDTO">Notice object</param>
        /// <returns>Response contains is data added or not</returns>
        [Authorize(Roles = "Admin")]
        [HttpPost("add_new_notice")]
        public Response AddNewNotice(DTONTC01 objDTO)
        {
            _objINTC01.Type = EnumType.A;
            _objINTC01.PreSave(objDTO);
            _objResponse = _objINTC01.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _objINTC01.Save();
                _logger.LogInformation("--- New notice is added to notice board ---");
            }
            return _objResponse;
        }

        /// <summary>
        /// Update notice data
        /// </summary>
        /// <param name="objDTO">New notice object</param>
        /// <returns>Response contains is data updated or not</returns>
        [Authorize(Roles = "Admin")]
        [HttpPut("update_notice")]
        public Response UpdateNotice(DTONTC01 objDTO)
        {
            _objINTC01.Type = EnumType.U;
            _objINTC01.PreSave(objDTO);
            _objResponse = _objINTC01.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _objINTC01.Save();
                _logger.LogInformation("--- Notice is updated on notice board ---");
            }
            return _objResponse;
        }

        /// <summary>
        /// Delete notice by id
        /// </summary>
        /// <param name="id">Notice id</param>
        /// <returns>Response contains is notice deleted or not</returns>
        [Authorize(Roles = "Admin")]
        [HttpDelete("delete_notice")]
        public Response DeleteNotice(int id)
        {
            _objResponse = _objINTC01.Delete(id);
            _logger.LogInformation("--- Notice is deleted from notice board ---");
            return _objResponse;
        }
    }
}
