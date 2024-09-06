using Elham.OrderManagement.Data;
using Elham.OrderManagement.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elham.OrderManagement.Service
{
    public class OrderService: IOrderService
    {
        private readonly Context _context;
        private readonly ILogger<OrderService> _logger;

        public OrderService(Context context, ILogger<OrderService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Create(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();

            _logger.LogInformation("Create Order");
        }

        public void Update()
        {
            var order = new Order() { Id = 1, Name="custom order" };

            _context.Orders.Update(order);
            ////save data to the database tables
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            var order = _context.Orders.Single(x => x.Id == id);

            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public List<Order> GetList()
        {
            Console.WriteLine("==========================\nOrderList");

            var orderList = _context.Orders.Where(x => x.Id > 0)
                .ToList();

            return orderList;
        }

        public Order Get(int id)
        {

            var order = _context.Orders.Single(x => x.Id == id);

            return order;

        }

        public Customer GetCustomer(int id)
        {

            var order = _context.Orders.Include(x=>x.Customer).Single(x => x.Id == id);
 
            return order.Customer;

        }
    }
}
