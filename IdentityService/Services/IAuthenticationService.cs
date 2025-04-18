using IdentityService.Models;

namespace IdentityService.Services;

public interface IAuthenticationService
{
    string GenerateJwtToken(User user);
}
