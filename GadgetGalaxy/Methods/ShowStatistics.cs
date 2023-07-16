using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GadgetGalaxyDatabase.DbSets;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace GadgetGalaxy.Methods
{
    /// <summary>
    /// This class handles statistics related to products, customers, and orders in the database.
    /// </summary>
    public class ShowStatistics
    {
        private readonly DbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShowStatistics"/> class.
        /// </summary>
        /// <param name="context">The database context to be used.</param>
        public ShowStatistics(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves the total number of products in the database.
        /// </summary>
        /// <returns>The total number of products as a string.</returns>
        public string GetTotalProducts()
        {
            var totalProducts = _context.Set<Product>().Count();
            return totalProducts.ToString();
        }

        /// <summary>
        /// Retrieves the total number of customers in the database.
        /// </summary>
        /// <returns>The total number of customers as a string.</returns>
        public string GetTotalCustomers()
        {
            var totalCustomers = _context.Set<Customer>().Count();
            return totalCustomers.ToString();
        }

        /// <summary>
        /// Retrieves the total number of orders in the database.
        /// </summary>
        /// <returns>The total number of orders as a string.</returns>
        public string GetTotalOrders()
        {
            var totalOrders = _context.Set<Order>().Count();
            return totalOrders.ToString();
        }
    }
}
