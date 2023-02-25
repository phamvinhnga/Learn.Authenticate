using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Authenticate.Entity.Entities
{
    [Table("Product")]
    public class Product : BaseEntity<int>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Status { get; set; }
        public string Thumbnail { get; set; }
        public string Images { get; set; }
        public decimal Price { get; set; }
        public decimal ImportPrice { get; set; }
        public decimal PromotionalPrice { get; set; }
        public decimal ImportNumber { get; set; }
        public decimal SellNumber { get; set; }
        public bool HasPromotional { get; set; }
    }
}
