using System;
using System.Collections.Generic;
using System.Text;
using BookShop.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Dal.EntityConfiguration
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData( 
                new Category { Id =  1, DisplayName = "Ezoterika",              ParentCategoryId = null,    Order = "00"    },
                new Category { Id =  2, DisplayName = "Feng shui",              ParentCategoryId = 1,       Order = "00.01" },
                new Category { Id =  3, DisplayName = "Horoszkóp, asztrológia", ParentCategoryId = 1,       Order = "00.02" },
                new Category { Id =  4, DisplayName = "Parapszichológia",       ParentCategoryId = 1,       Order = "00.03" },
                new Category { Id =  5, DisplayName = "Irodalom",               ParentCategoryId = null,    Order = "01"    },
                new Category { Id =  6, DisplayName = "Életrajz",               ParentCategoryId = 5,       Order = "01.01" },
                new Category { Id =  7, DisplayName = "Dráma, színmű",          ParentCategoryId = 5,       Order = "01.02" },
                new Category { Id =  8, DisplayName = "Vers, eposz",            ParentCategoryId = 5,       Order = "01.03" },
                new Category { Id =  9, DisplayName = "Tankönyvek",             ParentCategoryId = null,    Order = "02"    },
                new Category { Id = 10, DisplayName = "Matematika",             ParentCategoryId = 9,       Order = "02.01" },
                new Category { Id = 11, DisplayName = "Kémia",                  ParentCategoryId = 9,       Order = "02.02" },
                new Category { Id = 12, DisplayName = "Közgazdaságtudomány",    ParentCategoryId = 9,       Order = "02.03" },
                new Category { Id = 13, DisplayName = "Biológia",               ParentCategoryId = 9,       Order = "02.04" },
                new Category { Id = 14, DisplayName = "Regény",                 ParentCategoryId = null,    Order = "03"    },
                new Category { Id = 15, DisplayName = "Családregény",           ParentCategoryId = 14,      Order = "03.01" },
                new Category { Id = 16, DisplayName = "Fantasy",                ParentCategoryId = 14,      Order = "03.02" },
                new Category { Id = 17, DisplayName = "Erotikus",               ParentCategoryId = 14,      Order = "03.03" },
                new Category { Id = 18, DisplayName = "Krimi",                  ParentCategoryId = 14,      Order = "03.04" },
                new Category { Id = 19, DisplayName = "Sci-fi",                 ParentCategoryId = 14,      Order = "03.05" },
                new Category { Id = 20, DisplayName = "Thriller",               ParentCategoryId = 14,      Order = "03.06" },
                new Category { Id = 21, DisplayName = "Történelmi",             ParentCategoryId = 14,      Order = "03.07" }
            );
        }
    }
}