using Microsoft.AspNetCore.Identity;

namespace AnotherService
{
    public class AppUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public byte[]? ProfilePicture { get; set; }
    }
}
