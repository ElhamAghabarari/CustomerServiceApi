using Elham.OrderManagement.Model;

namespace CustomerServiceApi.Controllers.ViewModel
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
