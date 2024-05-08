using BisleriumBloggers.Interfaces.Repositories.Base;
using BisleriumBloggers.Models;
using BisleriumBloggers.Utilities;

namespace BisleriumBloggers.Persistence.Seed;

public class DbInitializer(IGenericRepository genericRepository) : IDbInitializer
{
    public void Initialize()
    {
        try
        {
            if (!genericRepository.Get<Role>().Any())
            {
                var admin = new Role()
                {
                    Name = "Admin",
                    Description = ""
                };
                var blogger = new Role()
                {
                    Name = "Blogger",
                    Description = ""
                };

                genericRepository.Insert(admin);
                genericRepository.Insert(blogger);
            }

            if (genericRepository.Get<User>().Any()) return;

            var adminRole = genericRepository.GetFirstOrDefault<Role>(x => x.Name == "Admin");

            var superAdminUser = new User
            {
                FullName = "Super Admin",
                EmailAddress = "superadmin@superadmin.com",
                UserName = "superadmin@superadmin.com",
                Password = Password.HashSecret("Admin@123"),
                RoleId = adminRole.Id,
                MobileNo = "+977 9803364638",
                ImageURL = null
            };

            genericRepository.Insert(superAdminUser);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}