using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GadgetGalaxyDatabase;
using Microsoft.EntityFrameworkCore;

namespace GadgetGalaxy.Methods
{
    /// <summary>
    /// This class handles operations related to the database.
    /// </summary>
    public class DatabaseOperations
    {
        private readonly DbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseOperations"/> class.
        /// </summary>
        /// <param name="context">The database context to be used.</param>
        public DatabaseOperations(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a list of data of the specified type from the database.
        /// </summary>
        /// <typeparam name="T">The type of data to retrieve.</typeparam>
        /// <returns>A list containing the retrieved data.</returns>
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
