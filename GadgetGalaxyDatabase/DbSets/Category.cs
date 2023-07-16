using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadgetGalaxyDatabase.DbSets
{
    /// <summary>
    /// This class represents the Category table in the database.
    /// </summary>
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
