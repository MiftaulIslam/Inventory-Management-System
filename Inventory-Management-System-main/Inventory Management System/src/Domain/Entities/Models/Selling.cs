using Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public partial class Selling
    {
        public Selling() {
            SellingList = new HashSet<SellingList>();
        }
        [Key]
        public int Id { get; set; }
        public int SellingSn { get; set; }
        public int CustomerId { get; set; }
        public string Memo { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal Paid { get; set; }
        public decimal Due { get; set; }
        public decimal ReturnAmout { get; set; }
        public bool IsPaid { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public DateTime PromisedPaymentDate { get; set; }
        public DateTime SellingAt { get; set; }


        //Calcuation-only for admin

        public int Profit { get; set; } // SellingList Price - PurchaseList Price
        
        //public virtual Customer Customer { get; set; }
        public virtual ICollection<SellingList> SellingList { get; set; }

    }
}
