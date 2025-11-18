using EcommercePlatformAPI.BAL;
using EcommercePlatformAPI.MAL;
using EcommercePlatformAPI.MAL.DTO;
using EcommercePlatformAPI.MAL.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EcommercePlatformAPI.API
{
    /// <summary>
    /// Controller for category APIs
    /// </summary>
    public class CLCTG01Controller : ApiController
    {
        private readonly BLCTG01 _objBLCTG01 = new BLCTG01();
        private Response _objResponse = new Response();

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns>Response containing Message and Data of categories</returns>
        [HttpGet]
        [Route("get_all_category")]
        public IHttpActionResult GetAllCategory()
        {
            Response objResponse = _objBLCTG01.GetAllCategory();
            return Ok(objResponse);
        }

        /// <summary>
        /// Get category by id
        /// </summary>
        /// <param name="id">Category id</param>
        /// <returns>Response containing Message and Data of category</returns>
        [HttpGet]
        [Route("get_category_by_Id/{id}")]
        public IHttpActionResult GetCategoryById(int id)
        {
            Response objResponse = _objBLCTG01.GetCategoryById(id);
            return Ok(objResponse);
        }

        /// <summary>
        /// Add new category
        /// </summary>
        /// <param name="objDTO">Category data</param>
        /// <returns>Response containing Message if data added or not</returns>
        [HttpPost]
        [Route("add_new_category")]
        public IHttpActionResult AddNewCategory(DTOCTG01 objDTO)
        {
            _objBLCTG01.Type = EnumType.A;
            _objBLCTG01.PreSave(objDTO);
            _objResponse = _objBLCTG01.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLCTG01.Save();
            }
            return Ok(_objResponse);
        }

        /// <summary>
        /// Update category
        /// </summary>
        /// <param name="objDTO">Updated category data</param>
        /// <returns>Response containing Message if data updated or not</returns>
        [HttpPut]
        [Route("update_category")]
        public IHttpActionResult UpdateCategory(DTOCTG01 objDTO)
        {
            _objBLCTG01.Type = EnumType.U;
            _objBLCTG01.PreSave(objDTO);
            _objResponse = _objBLCTG01.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLCTG01.Save();
            }
            return Ok(_objResponse);
        }

        /// <summary>
        /// Delete category by its id
        /// </summary>
        /// <param name="id">Category id</param>
        /// <returns>Response containing if category deleted or not</returns>
        [HttpDelete]
        [Route("delete_category/{id}")]
        public IHttpActionResult DeleteCategory(int id)
        {
            _objResponse = _objBLCTG01.Delete(id);
            return Ok(_objResponse);
        }
    }
}
