using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learn.Authenticate.Entity.Entities
{
    [Table("CategoryFood")]
    public class CategoryFood : BaseEntity<int>
    {
        [Required]
        public string Code { get; set; }    
        [Required]
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public string Permalink { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
    }
}
