using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadgetGalaxyDatabase.DbSets
{
    /// <summary>
    /// This class represents the Order table in the database.
    /// </summary>
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
