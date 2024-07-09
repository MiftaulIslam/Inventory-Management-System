using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public partial class SellingList
    {
        public SellingList() { }

        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int StockId { get; set; }
        public decimal SellingPrice { get; set; }

        public string Warrenty { get; set; }

        public virtual Stock Stock { get; set; }
        public virtual Product Product { get; set; }

        
    }
}
