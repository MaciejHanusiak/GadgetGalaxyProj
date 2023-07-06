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
    public class ShowStatistics
    {
        private readonly DbContext _context;

        public ShowStatistics(DbContext context)
        {
            _context = context;
        }
        public string GetTotalProducts()
        {
            var totalProducts = _context.Set<Product>().Count();
            return totalProducts.ToString();
        }

        public string GetTotalCustomers()
        {
            var totalCustomers = _context.Set<Customer>().Count();
            return totalCustomers.ToString();
        }

        public string GetTotalOrders()
        {
            var totalOrders = _context.Set<Order>().Count();
            return totalOrders.ToString();
        }
    }
}
