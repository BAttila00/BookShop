using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Dal.SeedInterfaces {
    public interface IUserSeedService {
        Task SeedUserAsync();
    }
}
