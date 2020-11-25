using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace MyBlog
{
    public static class RoleClaimExtension 
    {
        public static List<Claim> GetClaimsFromRoles(IList<string> roles) => roles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();
    }
}