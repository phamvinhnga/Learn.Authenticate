using Learn.Authenticate.Entity.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Authenticate.Biz.Dto
{
    public class PostInputDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        public string Summary { get; set; }
        public string Type { get; set; }
        public string Thumbnail { get; set; }
        public string Images { get; set; }
    }
}
