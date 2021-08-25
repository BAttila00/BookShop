using System;
using System.Collections.Generic;
using System.Text;
using BookShop.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Dal.EntityConfiguration
{
    public class PublisherEntityConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasData(
                new Publisher { Id = 1,  DisplayName = "Bioenergetic Kiadó" },
                new Publisher { Id = 2,  DisplayName = "Terc Kiadó" },
                new Publisher { Id = 3,  DisplayName = "Csengőkert Könyvkiadó" },
                new Publisher { Id = 4,  DisplayName = "Hajja és Fiai Könyvkiadó" },
                new Publisher { Id = 5,  DisplayName = "Sziget Könyvkiadó" },
                new Publisher { Id = 6,  DisplayName = "Első Magyar Feng Shui Centrum" },
                new Publisher { Id = 7,  DisplayName = "Lunarimpex Kiadó" },
                new Publisher { Id = 8,  DisplayName = "Műszaki Könyvkiadó" },
                new Publisher { Id = 9,  DisplayName = "Kossuth Kiadó" },
                new Publisher { Id = 10, DisplayName = "Animus Kiadó" },
                new Publisher { Id = 11, DisplayName = "Partvonal Könyvkiadó" },
                new Publisher { Id = 12, DisplayName = "Alexandra Kiadó" },
                new Publisher { Id = 13, DisplayName = "Szaktudás Kiadó Ház" },
                new Publisher { Id = 14, DisplayName = "Typotex Kiadó" },
                new Publisher { Id = 15, DisplayName = "STB Könyvek Könyvkiadó" },
                new Publisher { Id = 16, DisplayName = "Regulus Art Kft." },
                new Publisher { Id = 17, DisplayName = "Officina '96 Kiadó" },
                new Publisher { Id = 18, DisplayName = "Danvantara Kiadó" },
                new Publisher { Id = 19, DisplayName = "Gabo Könyvkiadó, Gulliver Könyvkiadó" },
                new Publisher { Id = 20, DisplayName = "Kairosz Kiadó" },
                new Publisher { Id = 21, DisplayName = "Ankh Kiadó" },
                new Publisher { Id = 22, DisplayName = "L'Harmattan Kiadó" },
                new Publisher { Id = 23, DisplayName = "Akadémiai Kiadó" },
                new Publisher { Id = 24, DisplayName = "Scolar Kiadó" },
                new Publisher { Id = 25, DisplayName = "K.u.K.Kiadó" },
                new Publisher { Id = 26, DisplayName = "Édesvíz Kiadó" },
                new Publisher { Id = 27, DisplayName = "Cartaphilus Könyvkiadó" },
                new Publisher { Id = 28, DisplayName = "Villon Books Kiadó" },
                new Publisher { Id = 29, DisplayName = "Tarandus Kiadó" },
                new Publisher { Id = 30, DisplayName = "Gabo Könyvkiadó" },
                new Publisher { Id = 31, DisplayName = "HVG Kiadó" },
                new Publisher { Id = 32, DisplayName = "Ursus Libris Kiadó" },
                new Publisher { Id = 33, DisplayName = "Európa Könyvkiadó" },
                new Publisher { Id = 34, DisplayName = "Kalligram Könyv - és Lapkiadó" },
                new Publisher { Id = 35, DisplayName = "Szukits Könyvkiadó" },
                new Publisher { Id = 36, DisplayName = "Osiris Kiadó" },
                new Publisher { Id = 37, DisplayName = "Park Könyvkiadó" },
                new Publisher { Id = 38, DisplayName = "Napkút Kiadó" },
                new Publisher { Id = 39, DisplayName = "QLT Műfordító Bt." },
                new Publisher { Id = 40, DisplayName = "Saxum Kiadó" },
                new Publisher { Id = 41, DisplayName = "Magyar Napló Kiadó" },
                new Publisher { Id = 42, DisplayName = "Helikon Kiadó" },
                new Publisher { Id = 43, DisplayName = "Múlt és Jövő Kiadó" },
                new Publisher { Id = 44, DisplayName = "Nemzeti Tankönyvkiadó" },
                new Publisher { Id = 45, DisplayName = "Geographia Kiadó" },
                new Publisher { Id = 46, DisplayName = "Littera Nova Kiadó" },
                new Publisher { Id = 47, DisplayName = "Napvilág Kiadó" },
                new Publisher { Id = 48, DisplayName = "Képzőművészeti Kiadó" },
                new Publisher { Id = 49, DisplayName = "Gondolat Kiadó" },
                new Publisher { Id = 50, DisplayName = "Gazdasági Versenyhivatal Versenykultúra Központ" },
                new Publisher { Id = 51, DisplayName = "Mezőgazda Kiadó" },
                new Publisher { Id = 52, DisplayName = "Pilis - Vet Kiadó" },
                new Publisher { Id = 53, DisplayName = "Noran Kiadó" },
                new Publisher { Id = 54, DisplayName = "Delta Vision Kiadó" },
                new Publisher { Id = 55, DisplayName = "BBS - INFO Kft." },
                new Publisher { Id = 56, DisplayName = "Dialóg Campus Kiadó" },
                new Publisher { Id = 57, DisplayName = "Slovart Kiadó" },
                new Publisher { Id = 58, DisplayName = "Magvető Könyvkiadó" },
                new Publisher { Id = 59, DisplayName = "Ulpius - ház Könyvkiadó" },
                new Publisher { Id = 60, DisplayName = "I.A.T.Kiadó" },
                new Publisher { Id = 61, DisplayName = "Beholder Kiadó" },
                new Publisher { Id = 62, DisplayName = "Art Nouveau Kiadó" },
                new Publisher { Id = 63, DisplayName = "JLX Kiadó" },
                new Publisher { Id = 64, DisplayName = "Illia & Co.Kiadó" },
                new Publisher { Id = 65, DisplayName = "Kalandor Könyvkiadó" },
                new Publisher { Id = 66, DisplayName = "Agave Könyvek" },
                new Publisher { Id = 67, DisplayName = "Metropolis Media" },
                new Publisher { Id = 68, DisplayName = "Kelly Kiadó" },
                new Publisher { Id = 69, DisplayName = "Athenaeum 2000 Kiadó" },
                new Publisher { Id = 70, DisplayName = "I.P.C.Könyvek" },
                new Publisher { Id = 71, DisplayName = "PolgART Lap - és Könyvkiadó" },
                new Publisher { Id = 72, DisplayName = "Geopen Könyvkiadó" },
                new Publisher { Id = 73, DisplayName = "Tericum Kiadó" },
                new Publisher { Id = 74, DisplayName = "Fumax" },
                new Publisher { Id = 75, DisplayName = "Goodinvest Kft." },
                new Publisher { Id = 76, DisplayName = "General Press Kiadó" }
            );
        }
    }
}
