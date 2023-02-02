using System.ComponentModel.DataAnnotations;

namespace Learn.Authenticate.Biz.Dto
{
    public class UserSignUpInputDto 
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

        [Required]
        public string Password { get; set; }
    }

    public class UserSignInInputDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class CurrentUserOutputDto
    {
        public int Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }
        public string FullName { get; set; }

        public Guid ExtentionId { get; set; }
    }

    public class UserSignInOutputDto
    {
        public string AccessToken { get; set; }

        public DateTime Expire { get; set; }
    }
}
