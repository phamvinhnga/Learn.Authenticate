using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Authenticate.Entity.Entities
{
    public class Location : BaseTreeEntity<int>
    {
        public string Description { get; set; }
        public string Name { get; set; }
    }
}
