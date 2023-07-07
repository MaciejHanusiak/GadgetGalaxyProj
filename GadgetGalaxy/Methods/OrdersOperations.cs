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
    public class OrdersOperations
    {
        private readonly GGDbContext _context;

        public OrdersOperations(GGDbContext context)
        {
            _context = context;
        }

        public void removeOrder(int id)
        {
            var order = _context.Orders.Find(id);
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
    }
}
