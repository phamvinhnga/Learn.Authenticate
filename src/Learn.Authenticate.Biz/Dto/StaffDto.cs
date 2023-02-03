using System.ComponentModel.DataAnnotations;

namespace Learn.Authenticate.Biz.Dto
{
    public class StaffRegisterInputDto
    {
        [Required]
        public string Surname { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }

    public class StaffOutputDto
    {
        public string Surname { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string PhoneNumber { get; set; }
    }
}
