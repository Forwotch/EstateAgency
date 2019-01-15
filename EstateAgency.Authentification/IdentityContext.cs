using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EstateAgency.Authentification
{
    public class IdentityContext : IdentityDbContext<User>
    {
        public IdentityContext(DbContextOptions<IdentityContext> contextOptions) : base(contextOptions)
        {
            Database.EnsureCreated();
        }
    }
}