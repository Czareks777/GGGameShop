using DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models;
using Utility;

namespace GGameShop.DbInitalizer
{
    public class DbInitalizer : IDbInitalizer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public DbInitalizer(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }


        public void Initalize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex) { }

            if (!_roleManager.RoleExistsAsync(StaticDetails.Role_Client).GetAwaiter().GetResult())
            {
                 _roleManager.CreateAsync(new IdentityRole(StaticDetails.Role_Client));
                 _roleManager.CreateAsync(new IdentityRole(StaticDetails.Role_Admin));
                _roleManager.CreateAsync(new IdentityRole(StaticDetails.Role_Employee));
            }
            _userManager.CreateAsync(new User
            {
                UserName = "adminDeveloper@gmail.com",
                Email = "adminDeveloper@gmail.com",
                Name = "Cezary Sawicki",
                PhoneNumber = "666666666",
                Address = "Bazynskiego ",
                PostalCode = "10-691",
                City = "Gdasnk"
            }, "Admin123@").GetAwaiter().GetResult();
            User user = _db.Users.FirstOrDefault(u => u.Email == "adminDeveloper@gmail.com");
            _userManager.AddToRoleAsync(user, StaticDetails.Role_Admin).GetAwaiter().GetResult();
        }
        
    }
}

