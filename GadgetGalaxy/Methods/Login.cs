using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GadgetGalaxyDatabase;

namespace GadgetGalaxy.Methods
{
    public class Login
    {
        private readonly GGDbContext _context;

        public Login(GGDbContext context)
        {
            _context = context;
        }

        public bool LoginUser(string username, string password)
        {
            return _context.Users.Any(u => u.Username == username && u.Password == password);
        }
    }
}
