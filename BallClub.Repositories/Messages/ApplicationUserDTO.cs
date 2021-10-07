using Microsoft.AspNetCore.Identity;
using System;

namespace BallClub.Repositories.Messages
{
    public class ApplicationUserDTO : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime JoinDate { get; set; }
    }
}
