using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public partial class Vendor
    {
        public Vendor()
        {
            Purchase = new HashSet<Purchase>();
        }
        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal ReturnAmount { get; set; }
        public decimal Paid { get; set; }
        public decimal Due { get; set; }
        public byte[] Photo { get; set; }
        public DateTime CreateAt { get; set; }

        public virtual ICollection<Purchase> Purchase { get; set; }
    }
}
