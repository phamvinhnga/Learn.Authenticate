using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Authenticate.Entity.Model
{
    public class ShopInputModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string GoogleMap { get; set; }
        public FileModel Thumbnail { get; set; }
        public int LocationId { get; set; }
    }

    public class ShopOutputModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string GoogleMap { get; set; }
        public FileModel Thumbnail { get; set; }
        public int LocationId { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUser { get; set; }
    }
}
