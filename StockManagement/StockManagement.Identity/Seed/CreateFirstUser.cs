using StockManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace GloboTicket.TicketManagement.Identity.Seed
{
    public static class UserCreator
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            var applicationUser = new ApplicationUser
            {
                FirstName = "filan",
                LastName = "fisteku",
                UserName = "filan",
                Email = "filan@test.com",
                EmailConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(applicationUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(applicationUser, "Azerty&01?");
            }
        }
    }
}