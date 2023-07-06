using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GadgetGalaxyDatabase;
using GadgetGalaxyDatabase.DbSets;
using Microsoft.EntityFrameworkCore;

namespace GadgetGalaxy.Methods
{
    public class CustomersOperations
    {
        private readonly DbContext _context;

        public CustomersOperations(GGDbContext context)
        {
            _context = context;
        }

        public void AddCustomer(string name, string email, string phone)
        {
            var customer = new Customer
            {
                Name = name,
                Email = email,
                Phone = phone
            };
            _context.Add(customer);
            _context.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            var customer = _context.Set<Customer>().Find(id);
            _context.Remove(customer);
            _context.SaveChanges();
        }
    }
}
