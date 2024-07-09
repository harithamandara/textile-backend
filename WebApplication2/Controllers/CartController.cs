using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Business;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private CartDataContext cartDataContext;
     

        public CartController(IConfiguration config)
        {
            cartDataContext = new CartDataContext(config);
        }


        [Route("GetAllCartProducts")]
        [HttpGet]
        public async Task<IActionResult> GetAllCartProducts()
        {
            try
            {
                var cartProducts = cartDataContext.GetAllCartProducts();
                return Ok(cartProducts);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "Intern server error");
            }
        }

        [Route("PostCartProducts")]
        [HttpPost]

        public async Task<IActionResult> PostCartProducts(CartModel obj)
        {
            bool result = false;
            try
            {
                result = cartDataContext.PostCartProducts(obj);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "Intern server error");
            }

            return Ok(result);
        }

        [Route("UpdateCartProducts")]
        [HttpPut]

        public async Task<IActionResult> UpdateCartProducts(CartModel obj)
        {
            bool result = false;
            try
            {
                result = cartDataContext.UpdateCartProducts(obj);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "Intern server error");
            }

            return Ok(result);
        }

        [Route("DeleteCartProducts")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCartProducts(int CId)
        {
            bool result = false;
            try
            {
                result = cartDataContext.DeleteCartProducts(CId);
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
