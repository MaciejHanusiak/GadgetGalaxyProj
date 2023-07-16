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
    /// <summary>
    /// This class handles operations related to customers in the database.
    /// </summary>
    public class CustomersOperations
    {
        private readonly DbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomersOperations"/> class.
        /// </summary>
        /// <param name="context">The database context to be used.</param>
        public CustomersOperations(GGDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new customer to the database.
        /// </summary>
        /// <param name="name">The name of the customer.</param>
        /// <param name="email">The email address of the customer.</param>
        /// <param name="phone">The phone number of the customer.</param>
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


        /// <summary>
        /// Deletes a customer from the database based on their ID.
        /// </summary>
        /// <param name="id">The ID of the customer to be deleted.</param>
        public void DeleteCustomer(int id)
        {
            var customer = _context.Set<Customer>().Find(id);
            _context.Remove(customer);
            _context.SaveChanges();
        }
    }
}
