using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public partial class Damage
    {
        public Damage()
        {
            Stock = new HashSet<Stock>();
        }

        [Key]
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public ICollection<Stock> Stock { get; set; }
    }
}
