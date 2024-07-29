using Elham.OrderManagement.Model;

namespace CustomerServiceApi.Controllers.ViewModel
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string? Name { get; set; }
    }
}
