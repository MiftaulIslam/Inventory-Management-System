using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public partial class ProductCatalogType
    {
        public ProductCatalogType() {
            ProductCatalog = new HashSet<ProductCatalog>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<ProductCatalog> ProductCatalog { get; set; }
    }
}
