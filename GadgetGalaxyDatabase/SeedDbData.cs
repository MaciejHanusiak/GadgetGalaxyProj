using GadgetGalaxyDatabase.DbSets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadgetGalaxyDatabase
{
    public class SeedDbData
    {
        private DbContext _dbContext;

        public void SeedDatabase(GGDbContext dbContext)
        {
            _dbContext = dbContext;
            if (!dbContext.Categories.Any())
            {
                SeedCategory();
            }
            
            if (!dbContext.Customers.Any())
            {
                SeedCustomer();
            }

            if (!dbContext.Products.Any())
            { 
                SeedProduct();
            }

            if(!dbContext.Users.Any())
            {
                SeedUser();
            }

            if (!dbContext.Orders.Any())
            {
                SeedOrder();
            }
        }


        /// <summary>
        /// Seeds every data category into the database.
        /// </summary>
    public void SeedCategory()
    {
        var categories = new List<Category>
        {
            new Category { Name = "Computers" },
            new Category { Name = "Smartphones" },
            new Category { Name = "Televisions" },
            new Category { Name = "Audio and Video" },
            new Category { Name = "Cameras and Photography" },
            new Category { Name = "Gaming" },
            new Category { Name = "Home Appliances" },
            new Category { Name = "Accessories" },
            new Category { Name = "Wearable Technology" },
            new Category { Name = "Smart Home Devices" }
        };

        foreach (var category in categories)
        {
            _dbContext.Set<Category>().Add(category);
        }

        _dbContext.SaveChanges();
    }

    private void SeedCustomer()
    {
        var customers = new List<Customer>
        {
            new Customer { Name = "John Smith", Email = "john.smith@example.com", Phone = "1234567890" },
            new Customer { Name = "Emily Johnson", Email = "emily.johnson@example.com", Phone = "9876543210" },
            new Customer { Name = "Michael Williams", Email = "michael.williams@example.com", Phone = "5555555555" },
            new Customer { Name = "Sophia Brown", Email = "sophia.brown@example.com", Phone = "1234567890" },
            new Customer { Name = "William Jones", Email = "william.jones@example.com", Phone = "9876543210" },
            new Customer { Name = "Olivia Davis", Email = "olivia.davis@example.com", Phone = "5555555555" },
            new Customer { Name = "James Miller", Email = "james.miller@example.com", Phone = "1234567890" },
            new Customer { Name = "Emma Wilson", Email = "emma.wilson@example.com", Phone = "9876543210" },
            new Customer { Name = "Benjamin Taylor", Email = "benjamin.taylor@example.com", Phone = "5555555555" },
            new Customer { Name = "Ava Anderson", Email = "ava.anderson@example.com", Phone = "1234567890" },
            new Customer { Name = "Alexander Martinez", Email = "alexander.martinez@example.com", Phone = "9876543210" },
            new Customer { Name = "Mia Thompson", Email = "mia.thompson@example.com", Phone = "5555555555" },
            new Customer { Name = "Henry Garcia", Email = "henry.garcia@example.com", Phone = "1234567890" },
            new Customer { Name = "Sofia Robinson", Email = "sofia.robinson@example.com", Phone = "9876543210" },
            new Customer { Name = "Joseph Clark", Email = "joseph.clark@example.com", Phone = "5555555555" },
            new Customer { Name = "Charlotte Rodriguez", Email = "charlotte.rodriguez@example.com", Phone = "1234567890" },
            new Customer { Name = "David Lee", Email = "david.lee@example.com", Phone = "9876543210" },
            new Customer { Name = "Amelia Walker", Email = "amelia.walker@example.com", Phone = "5555555555" },
            new Customer { Name = "Daniel Hill", Email = "daniel.hill@example.com", Phone = "1234567890" },
            new Customer { Name = "Harper Young", Email = "harper.young@example.com", Phone = "9876543210" },
            new Customer { Name = "Emily Allen", Email = "emily.allen@example.com", Phone = "5555555555" },
            new Customer { Name = "Matthew Scott", Email = "matthew.scott@example.com", Phone = "1234567890" },
            new Customer { Name = "Abigail King", Email = "abigail.king@example.com", Phone = "9876543210" },
            new Customer { Name = "Ethan Baker", Email = "ethan.baker@example.com", Phone = "5555555555" },
            new Customer { Name = "Ella Carter", Email = "ella.carter@example.com", Phone = "1234567890" }
        };

        foreach (var customer in customers)
        {
            _dbContext.Set<Customer>().Add(customer);
        }

        _dbContext.SaveChanges();
    }

    private void SeedProduct()
    {
        var products = new List<Product>
        {
            new Product { Name = "Laptop", Price = 999.99m, CategoryId = 1 },
            new Product { Name = "Smartphone", Price = 799.99m, CategoryId = 2 },
            new Product { Name = "TV", Price = 599.99m, CategoryId = 3 },
            new Product { Name = "Bluetooth Speaker", Price = 59.99m, CategoryId = 4 },
            new Product { Name = "Digital Camera", Price = 499.99m, CategoryId = 5 },
            new Product { Name = "Gaming Console", Price = 399.99m, CategoryId = 6 },
            new Product { Name = "Refrigerator", Price = 899.99m, CategoryId = 7 },
            new Product { Name = "Headphones", Price = 79.99m, CategoryId = 4 },
            new Product { Name = "Tablet", Price = 299.99m, CategoryId = 1 },
            new Product { Name = "Smartwatch", Price = 199.99m, CategoryId = 9 },
            new Product { Name = "Home Theater System", Price = 349.99m, CategoryId = 4 },
            new Product { Name = "DSLR Camera", Price = 999.99m, CategoryId = 5 },
            new Product { Name = "Gaming Mouse", Price = 49.99m, CategoryId = 6 },
            new Product { Name = "Washing Machine", Price = 699.99m, CategoryId = 7 },
            new Product { Name = "Wireless Earbuds", Price = 129.99m, CategoryId = 4 },
            new Product { Name = "Desktop Computer", Price = 1499.99m, CategoryId = 1 },
            new Product { Name = "Virtual Reality Headset", Price = 299.99m, CategoryId = 9 },
            new Product { Name = "Soundbar", Price = 199.99m, CategoryId = 4 },
            new Product { Name = "Mirrorless Camera", Price = 1199.99m, CategoryId = 5 },
            new Product { Name = "Gaming Keyboard", Price = 79.99m, CategoryId = 8}
        };

        foreach (var product in products)
        {
            _dbContext.Set<Product>().Add(product);
        }

        _dbContext.SaveChanges();
    }

    private void SeedUser()
    {
        var users = new List<User>
        {
            new User { Username = "User1", Password = "password1" },
            new User { Username = "JohnDoe", Password = "pass123" },
            new User { Username = "JaneSmith", Password = "secret456" },
            new User { Username = "MikeJohnson", Password = "password789" },
            new User { Username = "EmilyDavis", Password = "letmein" },
            new User { Username = "DavidWilson", Password = "qwerty" },
            new User { Username = "SarahAnderson", Password = "abcdef" },
            new User { Username = "RobertClark", Password = "test123" },
            new User { Username = "OliviaHall", Password = "hello123" },
            new User { Username = "DanielMoore", Password = "welcome" },
            new User { Username = "SophiaGarcia", Password = "123456" },
            new User { Username = "MatthewLee", Password = "password123" },
            new User { Username = "IsabellaHill", Password = "letmein123" },
            new User { Username = "JosephAdams", Password = "secret789" },
            new User { Username = "GraceAllen", Password = "abc123" },
            new User { Username = "AndrewCook", Password = "password456" }
        };

        foreach (var user in users)
        {
            _dbContext.Set<User>().Add(user);
        }

        _dbContext.SaveChanges();
    }

    private void SeedOrder()
    {
        var orders = new List<Order>
        {
new Order
{
    UserId = 1,
    OrderDate = DateTime.Now,
    Products = new List<Product>
    {
        new Product { Name = "Laptop", Price = 999.99m, CategoryId = 1 },
        new Product { Name = "Smartphone", Price = 799.99m, CategoryId = 2 },
        new Product { Name = "TV", Price = 599.99m, CategoryId = 3 }
    }
},
new Order
{
    UserId = 2,
    OrderDate = DateTime.Now,
    Products = new List<Product>
    {
        new Product { Name = "Bluetooth Speaker", Price = 59.99m, CategoryId = 4 },
        new Product { Name = "Digital Camera", Price = 499.99m, CategoryId = 5 }
    }
},
new Order
{
    UserId = 3,
    OrderDate = DateTime.Now,
    Products = new List<Product>
    {
        new Product { Name = "Gaming Console", Price = 399.99m, CategoryId = 6 },
        new Product { Name = "Refrigerator", Price = 899.99m, CategoryId = 7 }
    }
},
new Order
{
    UserId = 4,
    OrderDate = DateTime.Now,
    Products = new List<Product>
    {
        new Product { Name = "Headphones", Price = 79.99m, CategoryId = 4 },
        new Product { Name = "Tablet", Price = 299.99m, CategoryId = 1 },
        new Product { Name = "Smartwatch", Price = 199.99m, CategoryId = 9 }
    }
},
new Order
{
    UserId = 5,
    OrderDate = DateTime.Now,
    Products = new List<Product>
    {
        new Product { Name = "Home Theater System", Price = 349.99m, CategoryId = 4 },
        new Product { Name = "DSLR Camera", Price = 999.99m, CategoryId = 5 }
    }
},
new Order
{
    UserId = 6,
    OrderDate = DateTime.Now,
    Products = new List<Product>
    {
        new Product { Name = "Gaming Mouse", Price = 49.99m, CategoryId = 6 },
        new Product { Name = "Washing Machine", Price = 699.99m, CategoryId = 7 }
    }
},
new Order
{
    UserId = 7,
    OrderDate = DateTime.Now,
    Products = new List<Product>
    {
        new Product { Name = "Wireless Earbuds", Price = 129.99m, CategoryId = 4 },
        new Product { Name = "Desktop Computer", Price = 1499.99m, CategoryId = 1 }
    }
},
new Order
{
    UserId = 8,
    OrderDate = DateTime.Now,
    Products = new List<Product>
    {
        new Product { Name = "Virtual Reality Headset", Price = 299.99m, CategoryId = 9 },
        new Product { Name = "Soundbar", Price = 199.99m, CategoryId = 4 }
    }
},
new Order
{
    UserId = 9,
    OrderDate = DateTime.Now,
    Products = new List<Product>
    {
        new Product { Name = "Mirrorless Camera", Price = 1199.99m, CategoryId = 5 },
        new Product { Name = "Gaming Keyboard", Price = 79.99m, CategoryId = 6 }
    }
},
new Order
{
    UserId = 10,
    OrderDate = DateTime.Now,
    Products = new List<Product>
    {
        new Product { Name = "Air Conditioner", Price = 799.99m, CategoryId = 7 },
        new Product { Name = "Wireless Speaker", Price = 149.99m, CategoryId = 4 }
    }
}

        };

        foreach (var order in orders)
        {
            _dbContext.Set<Order>().Add(order);
        }

        _dbContext.SaveChanges();
    }
    }
}
