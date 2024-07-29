using AutoMapper;
using CustomerServiceApi.Controllers.ViewModel;
using Elham.OrderManagement.Model;

namespace CustomerServiceApi.Controllers.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
        }
    }
}
