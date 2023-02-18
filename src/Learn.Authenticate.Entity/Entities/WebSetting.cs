using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Authenticate.Entity.Entities
{
    public class WebSetting : BaseEntity<int>
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
