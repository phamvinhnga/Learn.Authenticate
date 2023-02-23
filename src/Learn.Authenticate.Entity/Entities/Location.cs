using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Authenticate.Entity.Entities
{
    [Table("Location")]
    public class Location : BaseEntity<int>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        public int ParentId { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
