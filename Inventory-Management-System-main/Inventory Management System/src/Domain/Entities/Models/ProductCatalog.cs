using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public partial class ProductCatalog
    {

        public ProductCatalog() {
            Product = new HashSet<Product>();
        }
        [Key]
        public int Id { get; set; }
        public int CatalogTypeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }
        public int? ParentId { get; set; }
        public int ItemCount { get; set; }
        public DateTime CreateAt { get; set; }

        public virtual ProductCatalogType CatalogType { get; set; }
        public virtual ProductCatalog Parent { get; set; }
        public virtual ICollection<Product> Product { get;}

    }
}
