namespace washbook_backend.Data;

using washbook_backend.Utilities.Helpers;
using Microsoft.AspNetCore.Identity;

public class AppDbInitializer
{
    public static async Task SeedRolesToDb(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync(UserRoles.Manager))
            {
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Manager));
            }

            if (!await roleManager.RoleExistsAsync(UserRoles.Student))
            {
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Student));
            }
        }
    }
}