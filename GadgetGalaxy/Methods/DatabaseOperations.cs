using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GadgetGalaxyDatabase;
using Microsoft.EntityFrameworkCore;

namespace GadgetGalaxy.Methods
{
    public class DatabaseOperations
    {
        private readonly DbContext _context;

        public DatabaseOperations(DbContext context)
        {
            _context = context;
        }
        public List<T> GetData<T>() where T : class
        {
            List<T> dataList = new List<T>();
            using (var context = _context)
            {
                dataList = context.Set<T>().ToList();
            }
            return dataList;
        }
    }
}
