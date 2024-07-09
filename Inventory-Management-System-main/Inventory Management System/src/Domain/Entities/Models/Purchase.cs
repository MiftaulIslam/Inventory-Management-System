using Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public partial class Purchase
    {
        public Purchase() {
            PurchaseList = new HashSet<PurchaseList>();
        }
        [Key]
        public int Id { get; set; }
        public int VendorId { get; set; }
        public int PurchaseSn { get; set; }
        public string Memo { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal Paid { get; set; }
        public decimal Due { get; set; }
        public decimal ReturnAmout { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public DateTime PurchaseAt { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual ICollection<PurchaseList> PurchaseList{ get; set; }
    }
}
