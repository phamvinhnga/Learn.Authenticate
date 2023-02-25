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
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string GoogleMap { get; set; }
        public FileModel Thumbnail { get; set; }
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        [Required]
        public string Status { get; set; }
    }

    public class ShopOutputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string GoogleMap { get; set; }
        public FileModel Thumbnail { get; set; }
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUser { get; set; }
        public string Status { get; set; }
    }

    public class ShopPageInputModel : BasePageInputModel
    {
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
    }
}
