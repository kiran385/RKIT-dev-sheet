using EcommercePlatformAPI.BAL;
using EcommercePlatformAPI.MAL;
using EcommercePlatformAPI.MAL.DTO;
using System.Web.Http;

namespace EcommercePlatformAPI.API
{
    /// <summary>
    /// Controller for Product APIs
    /// </summary>
    public class CLPRD01Controller : ApiController
    {
        private readonly BLPRD01 _objBLPRD01 = new BLPRD01();
        private Response _objResponse = new Response();

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>Response containing Message and Data of products</returns>
        [HttpGet]
        [Route("get_all_products")]
        public IHttpActionResult GetAllProducts()
        {
            Response objResponse = _objBLPRD01.GetAllProducts();
            return Ok(objResponse);
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns>Response containing Message and Data of product</returns>
        [HttpGet]
        [Route("get_product_by_id/{id}")]
        public IHttpActionResult GetProductById(int id)
        {
            Response objResponse = _objBLPRD01.GetProductById(id);
            return Ok(objResponse);
        }

        /// <summary>
        /// Get list of orders corresponding to every product id
        /// </summary>
        /// <returns>Returns list of orders corresponding to every product id</returns>
        [HttpGet]
        [Route("get_product_orders")]
        public IHttpActionResult GetProductOrders()
        {
            Response objResponse = _objBLPRD01.GetProductOrders();
            return Ok(objResponse);
        }

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="objDTO">Product data</param>
        /// <returns>Response containing Message if data added or not</returns>
        [HttpPost]
        [Route("add_new_product")]
        public IHttpActionResult AddNewProduct(DTOPRD01 objDTO)
        {
            _objBLPRD01.Type = EnumType.A;
            _objBLPRD01.PreSave(objDTO);
            _objResponse = _objBLPRD01.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLPRD01.Save();
            }
            return Ok(_objResponse);
        }

        /// <summary>
        /// Update product
        /// </summary>
        /// <param name="objDTO">Updated product data</param>
        /// <returns>Response containing Message if data updated or not</returns>
        [HttpPut]
        [Route("update_product")]
        public IHttpActionResult UpdateProduct(DTOPRD01 objDTO)
        {
            _objBLPRD01.Type = EnumType.U;
            _objBLPRD01.PreSave(objDTO);
            _objResponse = _objBLPRD01.Validation();
            if (!_objResponse.IsError)
            {
                _objResponse = _objBLPRD01.Save();
            }
            return Ok(_objResponse);
        }

        /// <summary>
        /// Delete product by its id
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns>Response containing if product deleted or not</returns>
        [HttpDelete]
        [Route("delete_product/{id}")]
        public IHttpActionResult DeleteProduct(int id)
        {
            _objResponse = _objBLPRD01.Delete(id);
            return Ok(_objResponse);
        }
    }
}
