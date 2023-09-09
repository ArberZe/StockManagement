using StockManagement.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StockManagement.Identity
{
    public class StockManagementIdentityDbContext: IdentityDbContext<ApplicationUser>
    {
        public StockManagementIdentityDbContext(): base()
        {
            
        }

        public StockManagementIdentityDbContext(DbContextOptions<StockManagementIdentityDbContext> options) : base(options) { }
    }
}
