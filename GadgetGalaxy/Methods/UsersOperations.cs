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
    /// This class handles operations related to users in the database.
    /// </summary>
    public class UsersOperations
    {
        private readonly DbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersOperations"/> class.
        /// </summary>
        /// <param name="context">The database context to be used.</param>
        public UsersOperations(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new user to the database.
        /// </summary>
        /// <param name="login">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
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

        /// <summary>
        /// Removes a user from the database based on their ID.
        /// </summary>
        /// <param name="userID">The ID of the user to be removed.</param>
        public void removeUser(int userID)
        {
            var user = _context.Set<User>().Where(u => u.UserId == userID).FirstOrDefault();
            _context.Remove(user);
            _context.SaveChanges();
        }
    }
}
