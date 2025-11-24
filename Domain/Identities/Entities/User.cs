using Microsoft.AspNetCore.Identity;
using SharedKernel;

namespace Domain.Identities.Entities;

public class User : IdentityUser<Ulid>
{
    public string Name { get; set; } = null!;

    public string? ProfileImage { get; set; }

    public string? FcmToken { get; set; }

    public DateTime LastLoginDate { get; set; }

    public DateTime RegistrationDate { get; set; }
    
    // Navigation properties
    [NavigationalProperty] 
    public virtual ICollection<UserDevice> UserDevices { get; set; } = null!;
}
