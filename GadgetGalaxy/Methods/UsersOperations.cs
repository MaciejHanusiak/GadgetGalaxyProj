using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GadgetGalaxyDatabase.DbSets;
using Microsoft.EntityFrameworkCore;

namespace GadgetGalaxy.Methods
{
    public class UsersOperations
    {
        private readonly DbContext _context;

        public UsersOperations(DbContext context)
        {
            _context = context;
        }

        public void addUser(string login, string password)
        {
            var user = new User
            {
                Username = login,
                Password = password
            };
            _context.Add(user);
            _context.SaveChanges();
        }

        public void removeUser(int userID)
        {
            var user = _context.Set<User>().Where(u => u.UserId == userID).FirstOrDefault();
            _context.Remove(user);
            _context.SaveChanges();
        }
    }
}
