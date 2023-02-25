using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Authenticate.Entity.Entities
{
    [Table("CategoryFood")]
    public class CategoryFood : BaseEntity<int>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Thumbnail { get; set; }
        public string Images { get; set; }
    }
}
