using Elham.OrderManagement.Model;

namespace Elham.OrderManagement.Service
{
    public interface ICustomerService
    {
        void Create(Customer customer);
        Customer Get(int id);
        List<Customer> GetList();
        List<Order> GetOrders(int id);
        void Update(Customer customer);
        void Delete(int id);
    }
}
