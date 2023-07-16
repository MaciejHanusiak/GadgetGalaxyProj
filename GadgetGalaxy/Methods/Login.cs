using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GadgetGalaxyDatabase;

namespace GadgetGalaxy.Methods
{
    /// <summary>
    /// This class handles user login operations.
    /// </summary>
    public class Login
    {
        private readonly GGDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Login"/> class.
        /// </summary>
        /// <param name="context">The database context to be used.</param>
        public Login(GGDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Checks if a user can be authenticated based on the provided username and password.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>True if the user can be authenticated, otherwise false.</returns>
        public bool LoginUser(string username, string password)
        {
            return _context.Users.Any(u => u.Username == username && u.Password == password);
        }
    }
}
