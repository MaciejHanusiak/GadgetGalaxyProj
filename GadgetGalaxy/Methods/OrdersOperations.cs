using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GadgetGalaxyDatabase;
using Microsoft.EntityFrameworkCore;

namespace GadgetGalaxy.Methods
{
    /// <summary>
    /// This class handles operations related to orders in the database.
    /// </summary>
    public class OrdersOperations
    {
        private readonly GGDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrdersOperations"/> class.
        /// </summary>
        /// <param name="context">The database context to be used.</param>
        public OrdersOperations(GGDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Removes an order from the database based on its ID.
        /// </summary>
        /// <param name="id">The ID of the order to be removed.</param>
        public void removeOrder(int id)
        {
            var order = _context.Orders.Find(id);
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
    }
}
