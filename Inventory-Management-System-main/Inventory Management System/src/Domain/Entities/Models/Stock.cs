using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public partial class Stock
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public int PurchaseId { get; set; }
        public int SellingId { get; set; }
        public bool IsSold { get; set; }
        public bool IsDamage { get; set; }
        public DateTime InsertAt { get; set; }
        public virtual Product Product { get; set; }
        //public virtual Damage Damage { get; set; }
        // public virtual Selling Selling { get; set; }
        // public virtual Purchase Purchase { get; set; }
        
    }
}
