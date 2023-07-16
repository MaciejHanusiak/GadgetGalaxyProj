using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GadgetGalaxyDatabase.DbSets;
using Microsoft.EntityFrameworkCore;

namespace GadgetGalaxy.Methods
{
    /// <summary>
    /// This class handles operations related to products in the database.
    /// </summary>
    public class ProductsOperation
    {
        private readonly DbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsOperation"/> class.
        /// </summary>
        /// <param name="context">The database context to be used.</param>
        public ProductsOperation(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new product to the database.
        /// </summary>
        /// <param name="name">The name of the product.</param>
        /// <param name="price">The price of the product as a string (to be converted to Decimal).</param>
        /// <param name="categoryId">The ID of the category to which the product belongs.</param>
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

        /// <summary>
        /// Removes a product from the database based on its ID.
        /// </summary>
        /// <param name="productId">The ID of the product to be removed.</param>
        public void removeProduct(int productID)
        {
            var product = _context.Set<Product>().Where(p => p.Id == productID).FirstOrDefault();
            _context.Remove(product);
            _context.SaveChanges();
        }
    }
}
