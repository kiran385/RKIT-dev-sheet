using EcommercePlatformAPI.BAL;
using EcommercePlatformAPI.MAL;
using EcommercePlatformAPI.MAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EcommercePlatformAPI.API
{
    /// <summary>
    /// Controller for Order APIs
    /// </summary>
    public class CLORD01Controller : ApiController
    {
        private readonly BLORD01 _objBLORD01 = new BLORD01();
        private Response _objResponse = new Response();

        /// <summary>
        /// Get all orders
        /// </summary>
        /// <returns>Response containing Message and Data of orders</returns>
        [HttpGet]
        [Route("get_all_orders")]
        public Response GetAllOrders()
        {
            Response objResponse = _objBLORD01.GetAllOrders();
            return objResponse;
        }

        /// <summary>
        /// Get order by id
        /// </summary>
        /// <param name="id">Order id</param>
        /// <returns>Response containing Message and Data of order</returns>
        [HttpGet]
        [Route("get_order_by_id/{id}")]
        public Response GetOrderById(int id)
        {
            Response objResponse = _objBLORD01.GetOrderById(id);
            return objResponse;
        }

        /// <summary>
        /// Get all pending orders
        /// </summary>
        /// <returns>Response containing data of pending orders</returns>
        [HttpGet]
        [Route("get_pending_orders")]
        public Response GetPendingOrders()
        {
            Response objResponse = _objBLORD01.GetPendingOrders();
            return objResponse;
        }

        /// <summary>
        /// Checks if order delivery status is pending or success 
        /// </summary>
        /// <param name="id">Order id</param>
        /// <returns>Response containing Message for status of order delivery</returns>
        [HttpGet]
        [Route("check_order_status/{id}")]
        public Response CheckOrderStatus(int id)
        {
            Response objResponse = _objBLORD01.CheckOrderStatus(id);
            return objResponse;
        }

        /// <summary>
        /// Add new order
        /// </summary>
        /// <param name="objDTO">Order data</param>
        /// <returns>Response containing Message if data added or not</returns>
        [HttpPost]
        [Route("add_new_order")]
        public IHttpActionResult AddNewOrder(DTOORD01 objDTO)
        {
            _objBLORD01.Type = EnumType.A;
            _objBLORD01.PreSave(objDTO);
            _objResponse = _objBLORD01.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLORD01.Save();
            }
            return Ok(_objResponse);
        }

        /// <summary>
        /// Update order
        /// </summary>
        /// <param name="objDTO">Updated order data</param>
        /// <returns>Response containing Message if data updated or not</returns>
        [HttpPut]
        [Route("update_order")]
        public IHttpActionResult UpdateOrder(DTOORD01 objDTO)
        {
            _objBLORD01.Type = EnumType.U;
            _objBLORD01.PreSave(objDTO);
            _objResponse = _objBLORD01.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLORD01.Save();
            }
            return Ok(_objResponse);
        }

        /// <summary>
        /// Delete order by its id
        /// </summary>
        /// <param name="id">Order id</param>
        /// <returns>Response containing if order deleted or not</returns>
        [HttpDelete]
        [Route("delete_order/{id}")]
        public IHttpActionResult DeleteProduct(int id)
        {
            _objResponse = _objBLORD01.Delete(id);
            return Ok(_objResponse);
        }
    }
}
