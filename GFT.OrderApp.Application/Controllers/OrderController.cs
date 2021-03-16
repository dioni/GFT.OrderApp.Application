using GFT.OrderApp.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GFT.OrderApp.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        [HttpPost]
        public IActionResult Post(OrderInputDto orderInputDto)
        {
            var output = _orderService.CreateOrder(orderInputDto.Input);

            return Ok(new OrderOutputDto(output));
        }
    }

    public class OrderInputDto
    {
        public string Input { get; set; }
    }

    public class OrderOutputDto
    {
        public OrderOutputDto(string output)
        {
            Output = output ?? throw new ArgumentNullException(nameof(Output));
        }

        public string Output { get; set; }
    }
}
