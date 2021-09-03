using BookShop.Dal.SeedInterfaces;
using BookShop.Dal.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

//Ati: Itt hozzuk létre a szerepköröket? (identity szerepkörök)

namespace BookShop.Dal.SeedService {
    public class RoleSeedService : IRoleSeedService {

        private readonly RoleManager<IdentityRole<int>> roleManager;

        //Ati: Az identity api-val tudjuk kezelni a szerepköröket.
        public RoleSeedService(RoleManager<IdentityRole<int>> roleManager) {
            this.roleManager = roleManager;
        }

        //Ati: Ha az admin szerepkör nem létezik akkor hozzuk létre és adjuk hozzá a roleManager-hez
        public async Task SeedRoleAsync() {
            if (!await roleManager.RoleExistsAsync(Roles.Administrators))
                await roleManager.CreateAsync(new IdentityRole<int> { Name = Roles.Administrators });
        }
    }
}
