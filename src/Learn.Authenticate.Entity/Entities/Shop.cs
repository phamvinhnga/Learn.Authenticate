using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Authenticate.Entity.Entities
{
    [Table("Shop")]
    public class Shop : BaseEntity<int>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string GoogleMap { get; set; }
        public string Thumbnail { get; set; }
        public string Images { get; set; }
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
