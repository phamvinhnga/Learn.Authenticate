﻿namespace Learn.Authenticate.Biz.Model
{
    public class StaffRregisterInputModel
    {
        public string Surname { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; } = "User123";
    }

}
