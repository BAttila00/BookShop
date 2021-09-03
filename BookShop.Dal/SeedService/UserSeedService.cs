using BookShop.Dal.Entities;
using BookShop.Dal.SeedInterfaces;
using BookShop.Dal.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ati: Itt hozzuk létre az admin userünket és adjuk hozzá az Administrators szerepkörhöz.

namespace BookShop.Dal.SeedService {
    public class UserSeedService : IUserSeedService {
        private readonly UserManager<User> userManager;
        public UserSeedService(UserManager<User> userManager) {
            this.userManager = userManager;
        }
        public async Task SeedUserAsync() {
            if (!(await userManager.GetUsersInRoleAsync(Roles.Administrators)).Any()) {                 //Ati: Ha még nincsen admin felhasználó csak akkor fusson le ez a kód (tehát csa kakkor hozzuk létre az admint)
                var user = new User {
                    UserName = "admin",
                    Email = "admin@bookshop.hu",
                    DisplayName = "Adminisztrátor",
                    SecurityStamp = Guid.NewGuid().ToString(),
                };
                var createResult = await userManager.CreateAsync(user, "$Administrator123");            //Ati: létrehozunk egy (az elöbb felparaméterezett) usert, akinek a jelszava az $Administrator123 lesz
                var addToRoleResult = await userManager.AddToRoleAsync(user, Roles.Administrators);     // megmondjuk h ezen user egy adminisztrátor lesz (felvesszük az Administrators szerepkörbe)
                if (!createResult.Succeeded || !addToRoleResult.Succeeded)
                    throw new ApplicationException("Administrator could not be created: " +
                    string.Join(", ", createResult.Errors
                    .Concat(addToRoleResult.Errors)
                    .Select(e => e.Description)));
            }
        }
    }
}
