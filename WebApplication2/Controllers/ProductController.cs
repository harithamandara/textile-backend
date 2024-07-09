using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Business;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductDataContext productDataContext;
      

        public ProductController(IConfiguration config)
        {
            productDataContext = new ProductDataContext(config);
        }


        [Route("GetAllProducts")]
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = productDataContext.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {


                Console.WriteLine(ex);
                return StatusCode(500, "Intern server error");
            }
        }

        [Route("PostProducts")]
        [HttpPost]

        public async Task<IActionResult> PostProducts(ProductModel obj)
        {
            bool result = false;
            try
            {
                result = productDataContext.PostProducts(obj);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "Intern server error");
            }

            return Ok(result);
        }

        [Route("UpdateProducts")]
        [HttpPut]

        public async Task<IActionResult> UpdateProducts(ProductModel obj)
        {
            bool result = false;
            try
            {
                result = productDataContext.UpdateProducts(obj);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "Intern server error");
            }

            return Ok(result);
        }

        [Route("DeleteProducts")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProducts(int ProductId)
        {
            bool result = false;
            try
            {
                result = productDataContext.DeleteProducts(ProductId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "Intern server error");
            }

            return Ok(result);
        }

    }
}
