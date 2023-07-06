using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GadgetGalaxyDatabase.DbSets;
using Microsoft.EntityFrameworkCore;

namespace GadgetGalaxy.Methods
{
    public class ProductsOperation
    {
        private readonly DbContext _context;

        public ProductsOperation(DbContext context)
        {
            _context = context;
        }

        public void addProduct(string name, string price, int categoryId)
        {
            var product = new Product
            {
                Name = name,
                CategoryId = categoryId,
                Price = Convert.ToDecimal(price)
            };
            _context.Add(product);
            _context.SaveChanges();
        }

        public void removeProduct(int productID)
        {
            var product = _context.Set<Product>().Where(p => p.Id == productID).FirstOrDefault();
            _context.Remove(product);
            _context.SaveChanges();
        }
    }
}
