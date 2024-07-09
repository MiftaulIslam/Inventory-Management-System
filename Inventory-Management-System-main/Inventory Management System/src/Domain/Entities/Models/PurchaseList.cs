using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public partial class PurchaseList
    {
        public PurchaseList() { }
        [Key]
        public int Id { get; set; }
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get;set; }

        public virtual Purchase Purchase { get; set; }
        public virtual Product Product { get; set; }
    }
}
