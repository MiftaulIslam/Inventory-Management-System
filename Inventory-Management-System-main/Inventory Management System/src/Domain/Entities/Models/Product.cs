using Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public partial class Product
    {
        public Product()
        {
            Stock = new HashSet<Stock>();
        }
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal PurchasePrice { get; set; }
        public decimal Price { get; set; }
        public string Warrenty { get; set; } = string.Empty;
        public StockStatus Status { get; set; }
        public int? StockQuantity{ get; set; }
        public DateTime CreateAt { get; set;}

        public virtual ProductCatalog Catalog{ get; set; }
        public virtual ICollection<Stock> Stock { get; set; }
        

    }
}
