using Learn.Authenticate.Entity.Migrations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Learn.Authenticate.Entity.Entities
{
    public class User : IdentityUser<int>
    {
        [Required]
        [StringLength(64)]
        public string Surname { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        [Required]
        public Guid ExtentionId { get; set; } = Guid.NewGuid();

        public virtual string FullName
        {
            get
            {
                return $"{this.Surname.Trim()} {this.Name.Trim()}";
            }
        }

        public void SetPasswordHasher(string password)
        {
            PasswordHash = new PasswordHasher<User>().HashPassword(this, password);
        }
    }
}
