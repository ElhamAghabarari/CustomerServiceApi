using AutoMapper;
using CustomerServiceApi.Controllers.ViewModel;
using Elham.OrderManagement.Model;
using Elham.OrderManagement.Service;
using Microsoft.AspNetCore.Mvc;

namespace CustomerServiceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService=customerService;
            _mapper=mapper;
        }

        public IActionResult Get()
        {
            IList<string> strList1 = new List<string>() { "Ttwo", "Tthree", "Four", "Five" };
            IList<string> strList2 = new List<string>() { null, "Two", "Three", "Four", "Five" };

            Console.WriteLine(strList1.LastOrDefault(s => s.Contains("T")));
            Console.WriteLine(strList2.LastOrDefault(s => s.Contains("T")));

            var list = _customerService.GetList();
            return Ok(_mapper.Map<List<Customer>,List<CustomerDto>>(list));
        }

        //[Route("{id}")]
        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
                return NotFound();

            var customer= _customerService.Get(id);
            return Ok(_mapper.Map<Customer,CustomerDto>(customer));
        }

        
        [Route("{id}/orders")]
        public IActionResult GetOrders(int id)
        {
            var orders = _customerService.GetOrders(id);

            return Ok(_mapper.Map<List<Order>, List<OrderDto>>(orders));
        }

        [HttpPost]
        public IActionResult Add([FromBody] CustomerDto customer)
        {
            _customerService.Create(_mapper.Map<Customer>(customer));
            return Ok();
        }

        [HttpPost]
        [Route("{id}")]
        public IActionResult Update(int id, CustomerDto customer)
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
