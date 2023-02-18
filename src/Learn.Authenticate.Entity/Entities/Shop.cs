using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Authenticate.Entity.Entities
{
    public class Shop : BaseEntity<int>
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string AddressNumber { get; set; }
        public string Street { get; set; }
        public string PhoneNumber { get; set; }
        public string Map { get; set; }
        public string Thumbnail { get; set; }
        public string Images { get; set; }
        public int LocationId { get; set; }
    }
}
