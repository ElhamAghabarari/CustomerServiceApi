using Elham.OrderManagement.Data;
using Elham.OrderManagement.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Elham.OrderManagement.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly Context _context;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(Context context, ILogger<CustomerService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            _logger.LogInformation("Create Customet");

        }

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();

            _logger.LogInformation("Update Customet");
        }

        public void Delete(int id)
        {
            var customer = _context.Customers.Single(x => x.Id == id);

            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public List<Customer> GetList()
        {
            Console.WriteLine("==========================\nCustomerList");

            var customerList = _context.Customers.Where(x => x.Id > 0)
                .ToList();

            return customerList;
        }

        public Customer Get(int id)
        {
            var customer = _context.Customers.Include(x => x.Orders).Single(x => x.Id == id);

            return customer;

        }
        public List<Order> GetOrders(int id)
        {
            var customer = _context.Customers.Include(x => x.Orders).Single(x => x.Id == id);
            changeVal();
            return (List<Order>)customer.Orders;
        }

        public void changeVal()
        {
            string name = "ddsd $ dfdsf dsfdsf $ dfdsfds sdfdsf $ gfdgfd";
            string [] a=name.Split('$');
            name = "";
            int index = 0;
            foreach(var i in a)
            {
                name += i;
                if (index == 0)
                    name += "$";
                index++;
            }
            Console.WriteLine(name);
        }
    }

    
}
