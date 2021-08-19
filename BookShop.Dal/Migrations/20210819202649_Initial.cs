using Microsoft.EntityFrameworkCore.Migrations;

//Ati: Az adatbázis táblák létrehozásáért felel
namespace BookShop.Dal.Migrations
{
    //Ati: Ez azért lett initial mert Add-Migration Initial parancsot adtunk ki, sztem initial helyett kb bmit írhattunk volna
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Headline = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    DiscountedPrice = table.Column<decimal>(nullable: true),
                    PublishYear = table.Column<int>(nullable: false),
                    NumberOfPages = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
