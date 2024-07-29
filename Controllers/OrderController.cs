using AutoMapper;
using CustomerServiceApi.Controllers.ViewModel;
using Elham.OrderManagement.Model;
using Elham.OrderManagement.Service;
using Microsoft.AspNetCore.Mvc;

namespace CustomerServiceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        public readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService, IMapper mapper) {
            _orderService = orderService;
            _mapper = mapper;
        }
        public IActionResult Get()
        {
            var list = _orderService.GetList();
            return Ok(_mapper.Map<List<Order>,List<OrderDto>>(list));
        }

        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var order = _orderService.Get(id);
            return Ok(_mapper.Map<OrderDto>(order));
        }

        [Route("{id}/customer")]
        public IActionResult GetCustomer(int id)
        {
            var customer = _orderService.GetCustomer(id);

            return Ok(_mapper.Map<Customer, CustomerDto>(customer));
        }

        [HttpPost]
        public IActionResult Add(OrderDto order)
        {
            _orderService.Create(_mapper.Map<Order>(order));
            return Ok();
        }

        [HttpPost]
        [Route("{id}")]
        public IActionResult Update(int id, OrderDto order)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
