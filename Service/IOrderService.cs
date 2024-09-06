using Elham.OrderManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elham.OrderManagement.Service
{
    public interface IOrderService
    {
        void Create(Order order);
        Order Get(int id);
        List<Order> GetList();
        Customer GetCustomer(int id);
        void Update();
        void Delete(int id);
    }
}
