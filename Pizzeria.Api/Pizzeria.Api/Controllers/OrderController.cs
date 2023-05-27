using Microsoft.AspNetCore.Mvc;
using Pizzeria.Business.Models;

namespace Pizzeria.Api.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet("order/{orderId}")]
        public Order GetOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("order")]
        public Order CreateOrder()
        {
            throw new NotImplementedException();
        }
    }
}
