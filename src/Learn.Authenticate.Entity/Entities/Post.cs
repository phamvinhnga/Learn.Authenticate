using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Authenticate.Entity.Entities
{
    public class Post : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Summary { get; set; }
        public string Type { get; set; }
        public string Thumbnail { get; set; }
        public string Images { get; set; }
    }
}
