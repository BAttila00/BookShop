using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookShop.Dal.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(maxLength: 100, nullable: false),
                    City = table.Column<string>(maxLength: 100, nullable: false),
                    ZIP = table.Column<string>(maxLength: 100, nullable: false),
                    Street = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(maxLength: 100, nullable: false),
                    FriendlyUrl = table.Column<string>(maxLength: 100, nullable: true),
                    PhotoUrl = table.Column<string>(maxLength: 100, nullable: true),
                    About = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(maxLength: 50, nullable: false),
                    FriendlyUrl = table.Column<string>(maxLength: 50, nullable: true),
                    ParentCategoryId = table.Column<int>(nullable: true),
                    Order = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category",
                        column: x => x.ParentCategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(maxLength: 100, nullable: false),
                    FriendlyUrl = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    MembershipID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    FriendlyUrl = table.Column<string>(maxLength: 100, nullable: true),
                    CategoryID = table.Column<int>(nullable: false),
                    PublisherID = table.Column<int>(nullable: false),
                    Subtitle = table.Column<string>(maxLength: 100, nullable: true),
                    CoverUrl = table.Column<string>(maxLength: 100, nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    DiscountPrice = table.Column<int>(nullable: true),
                    PublishYear = table.Column<int>(nullable: false),
                    PageNumber = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    SumRating = table.Column<int>(nullable: false),
                    RatingCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Category",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Book_Publisher",
                        column: x => x.PublisherID,
                        principalTable: "Publisher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    BillingAddressId = table.Column<int>(nullable: true),
                    ShippingAddressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Address_BillingAddressId",
                        column: x => x.BillingAddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Address_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAddress",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddress", x => new { x.UserId, x.AddressId });
                    table.ForeignKey(
                        name: "FK_UserAddress_Address",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserAddress_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthor",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthor", x => new { x.BookId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_BookAuthor_Author",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookAuthor_Book",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_oduct",
                        column: x => x.BookID,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_Book",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rating_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginalBookId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    DiscountedPrice = table.Column<decimal>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "About", "DisplayName", "FriendlyUrl", "PhotoUrl" },
                values: new object[,]
                {
                    { 1, null, "Lam Kam Chuen Mester", null, null },
                    { 96, null, "George R.R.Martin", null, null },
                    { 97, null, "Kövesi Péter", null, null },
                    { 98, null, "R.A.Salvatore", null, null },
                    { 99, null, "Raymond E.Feist", null, null },
                    { 100, null, "Szappanos Gábor", null, null },
                    { 101, null, "Király - Acampora Anikó", null, null },
                    { 95, null, "Raymond E.Feist, Steve Stirling", null, null },
                    { 102, null, "Egon Erwin Kisch", null, null },
                    { 104, null, "Kresley Cole", null, null },
                    { 105, null, "Bertrice Small", null, null },
                    { 106, null, "Julius J.Coach", null, null },
                    { 107, null, "Pedro Almodóvar", null, null },
                    { 108, null, "Cathryn Cooper", null, null },
                    { 109, null, "Carlos Ruiz Zafón", null, null },
                    { 103, null, "Szendrődy Szonja", null, null },
                    { 94, null, "J.R.R.Tolkien", null, null },
                    { 93, null, "Steven Erikson", null, null },
                    { 92, null, "Vlagyimir Szorokin", null, null },
                    { 77, null, "Csurgó Sándor", null, null },
                    { 78, null, "Dóry Béla", null, null },
                    { 79, null, "Enzo Gallori", null, null },
                    { 80, null, "Tóth Gábor", null, null },
                    { 81, null, "Vajta Gábor", null, null },
                    { 82, null, "I.N.Smeretle", null, null },
                    { 83, null, "Monika Offenberger", null, null },
                    { 84, null, "Sarah, dr.Brewer", null, null },
                    { 85, null, "Róbert Ceman", null, null },
                    { 86, null, "Ljudmila Ulickaja", null, null },
                    { 87, null, "Fábián Janka", null, null },
                    { 88, null, "Jonathan Safran Foer", null, null },
                    { 89, null, "Elif Shafak", null, null },
                    { 90, null, "Singer Arje Iván", null, null },
                    { 91, null, "Büky Anna", null, null },
                    { 110, null, "Stieg Larsson", null, null },
                    { 76, null, "Kopátsy Sándor", null, null },
                    { 111, null, "Szalai Vivien", null, null },
                    { 113, null, "Joanne Fluke", null, null },
                    { 134, null, "Steve Berry", null, null },
                    { 135, null, "Zima Szabolcs", null, null },
                    { 136, null, "Frei Tamás", null, null },
                    { 137, null, "Árpa Attila", null, null },
                    { 138, null, "Sam Barone", null, null },
                    { 139, null, "Andrew Sanders", null, null },
                    { 133, null, "Kathy Reichs", null, null },
                    { 140, null, "Tracy Chevalier", null, null },
                    { 142, null, "André Castelot", null, null },
                    { 143, null, "J.M.G.Le Clézio", null, null },
                    { 144, null, "Roberta Rich", null, null },
                    { 145, null, "C.W.Gortner", null, null },
                    { 146, null, "Oliver Bowden", null, null },
                    { 147, null, "Juli Zeh", null, null },
                    { 141, null, "Christian Jacq", null, null },
                    { 132, null, "Bíró Szabolcs", null, null },
                    { 131, null, "Joe Hill", null, null },
                    { 130, null, "Jónás Zsolt", null, null },
                    { 115, null, "Arthur Bernéde", null, null },
                    { 116, null, "Ross Macdonald", null, null },
                    { 117, null, "Bernard Knight", null, null },
                    { 118, null, "Agatha Christie", null, null },
                    { 119, null, "Linda Castillo", null, null },
                    { 120, null, "Martin Delrio", null, null },
                    { 121, null, "Philip K.Dick", null, null },
                    { 122, null, "Alan E.Nourse, William S.Burroughs", null, null },
                    { 123, null, "Robert Charles Wilson", null, null },
                    { 124, null, "Arkagyij Sztrugackij, Borisz Sztrugackij", null, null },
                    { 125, null, "Arthur C.Clarke, Stephen Baxter", null, null },
                    { 126, null, "Szergej Lukjanyenko", null, null },
                    { 127, null, "Frank Herbert", null, null },
                    { 128, null, "Nathan Archer", null, null },
                    { 129, null, "Lisa Jackson", null, null },
                    { 112, null, "George P.Pelecanos", null, null },
                    { 75, null, "N.Gregory Mankiw", null, null },
                    { 114, null, "Gerritsen Tess", null, null },
                    { 73, null, "Simon Bishop, Mike Walker", null, null },
                    { 22, null, "Kalo Jenő", null, null },
                    { 23, null, "Buji Ferenc", null, null },
                    { 24, null, "Késmárki László", null, null },
                    { 25, null, "Koffi Kwahulé", null, null },
                    { 26, null, "Madách Imre", null, null },
                    { 27, null, "Spiró György", null, null },
                    { 21, null, "Julia Parker, Derek Parker", null, null },
                    { 28, null, "Isa Schneider", null, null },
                    { 30, null, "Alfred Jarry", null, null },
                    { 31, null, "Faludy György", null, null },
                    { 32, null, "Paulinyi Tamás", null, null },
                    { 33, null, "Brian Haughton", null, null },
                    { 34, null, "Ronald H.Hulnick, Mary R.Hulnick", null, null },
                    { 74, null, "Csáki György", null, null },
                    { 29, null, "Solara", null, null },
                    { 20, null, "Bakos Attila", null, null },
                    { 19, null, "Robert Powell", null, null },
                    { 18, null, "Tai San", null, null },
                    { 3, null, "Ernest J.Eitel", null, null },
                    { 4, null, "Simon Brown", null, null },
                    { 5, null, "François Villon", null, null },
                    { 6, null, "Sándor László, Pocsai Katalin", null, null },
                    { 7, null, "Raymond Lo", null, null },
                    { 8, null, "Jes T.Y.Lim", null, null },
                    { 9, null, "Fekete Zoltán, Zalay Miklós", null, null },
                    { 10, null, "Gill Hale, Mark Evans", null, null },
                    { 11, null, "Szilvásy Judit", null, null },
                    { 12, null, "Stanislav Grof, Christina Grof", null, null },
                    { 13, null, "Judy Allen", null, null },
                    { 14, null, "Jhampa Shaneman, Jan V.Angel", null, null },
                    { 15, null, "Horváth Andrea", null, null },
                    { 16, null, "Claus Reimann", null, null },
                    { 17, null, "Tomasz Lem", null, null },
                    { 35, null, "José ifj.Silva, Ed ifj.Bernd", null, null },
                    { 36, null, "Lou Aronica, Ken, Sir Robinson", null, null },
                    { 37, null, "Charles T.Tart", null, null },
                    { 38, null, "Lisa Rogak", null, null },
                    { 58, null, "Andrási Tiborné, Czeglédy István, dr.Czeglédy Istvánné", null, null },
                    { 59, null, "Berkes Klára", null, null },
                    { 60, null, "Tony Crilly", null, null },
                    { 61, null, "Stuart Clark", null, null },
                    { 62, null, "Katona Gyula Y., Recski András, Szabó Csaba", null, null },
                    { 63, null, "Obádovics J.Gyula", null, null },
                    { 64, null, "Halász Ágnes", null, null },
                    { 65, null, "Theodore Gray", null, null },
                    { 66, null, "Lente Gábor, Kovács Lajos, Gunda Tamás, Csupor Dezső", null, null },
                    { 67, null, "Kremmer Tibor, Torkos Kornél", null, null },
                    { 68, null, "Adam Smith", null, null },
                    { 69, null, "Zugorné Rácz Éva", null, null },
                    { 70, null, "Stefan Kassay", null, null },
                    { 71, null, "Kornai János", null, null },
                    { 72, null, "Galbács Péter", null, null },
                    { 57, null, "Arany János", null, null },
                    { 2, null, "Susanne Schumacher", null, null },
                    { 56, null, "Dsida Jenő", null, null },
                    { 54, null, "Röhrig Géza", null, null },
                    { 39, null, "Kornis Mihály", null, null },
                    { 40, null, "Börcsök László", null, null },
                    { 41, null, "Veszprémi Tamás", null, null },
                    { 42, null, "Pierre Merle", null, null },
                    { 43, null, "Komáromi Gabriella", null, null },
                    { 44, null, "Ingmar Bergman", null, null },
                    { 45, null, "Oliver Sacks", null, null },
                    { 46, null, "Ámosz Oz", null, null },
                    { 47, null, "Alexander Brody", null, null },
                    { 48, null, "Cecilie Loveid", null, null },
                    { 49, null, "Jon Fosse", null, null },
                    { 50, null, "Alighieri Dante", null, null },
                    { 51, null, "Arthur Miller", null, null },
                    { 52, null, "dr.Popper Péter", null, null },
                    { 53, null, "Tom Bryan", null, null },
                    { 55, null, "William Shakespeare", null, null }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "DisplayName", "FriendlyUrl", "Order", "ParentCategoryId" },
                values: new object[,]
                {
                    { 9, "Tankönyvek", null, "02", null },
                    { 14, "Regény", null, "03", null },
                    { 1, "Ezoterika", null, "00", null },
                    { 5, "Irodalom", null, "01", null }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "DisplayName", "FriendlyUrl" },
                values: new object[,]
                {
                    { 73, "Tericum Kiadó", null },
                    { 53, "Noran Kiadó", null },
                    { 52, "Pilis - Vet Kiadó", null },
                    { 51, "Mezőgazda Kiadó", null },
                    { 50, "Gazdasági Versenyhivatal Versenykultúra Központ", null },
                    { 49, "Gondolat Kiadó", null },
                    { 48, "Képzőművészeti Kiadó", null },
                    { 47, "Napvilág Kiadó", null },
                    { 46, "Littera Nova Kiadó", null },
                    { 45, "Geographia Kiadó", null },
                    { 44, "Nemzeti Tankönyvkiadó", null },
                    { 43, "Múlt és Jövő Kiadó", null },
                    { 42, "Helikon Kiadó", null },
                    { 41, "Magyar Napló Kiadó", null },
                    { 40, "Saxum Kiadó", null },
                    { 39, "QLT Műfordító Bt.", null },
                    { 54, "Delta Vision Kiadó", null },
                    { 74, "Fumax", null },
                    { 55, "BBS - INFO Kft.", null },
                    { 57, "Slovart Kiadó", null },
                    { 72, "Geopen Könyvkiadó", null },
                    { 71, "PolgART Lap - és Könyvkiadó", null },
                    { 70, "I.P.C.Könyvek", null },
                    { 69, "Athenaeum 2000 Kiadó", null },
                    { 68, "Kelly Kiadó", null },
                    { 67, "Metropolis Media", null },
                    { 66, "Agave Könyvek", null },
                    { 65, "Kalandor Könyvkiadó", null },
                    { 64, "Illia & Co.Kiadó", null },
                    { 63, "JLX Kiadó", null },
                    { 62, "Art Nouveau Kiadó", null },
                    { 61, "Beholder Kiadó", null },
                    { 60, "I.A.T.Kiadó", null },
                    { 59, "Ulpius - ház Könyvkiadó", null },
                    { 58, "Magvető Könyvkiadó", null },
                    { 38, "Napkút Kiadó", null },
                    { 56, "Dialóg Campus Kiadó", null },
                    { 37, "Park Könyvkiadó", null },
                    { 35, "Szukits Könyvkiadó", null },
                    { 14, "Typotex Kiadó", null },
                    { 13, "Szaktudás Kiadó Ház", null },
                    { 12, "Alexandra Kiadó", null },
                    { 11, "Partvonal Könyvkiadó", null },
                    { 10, "Animus Kiadó", null },
                    { 9, "Kossuth Kiadó", null },
                    { 8, "Műszaki Könyvkiadó", null },
                    { 7, "Lunarimpex Kiadó", null },
                    { 6, "Első Magyar Feng Shui Centrum", null },
                    { 5, "Sziget Könyvkiadó", null },
                    { 4, "Hajja és Fiai Könyvkiadó", null },
                    { 3, "Csengőkert Könyvkiadó", null },
                    { 2, "Terc Kiadó", null },
                    { 1, "Bioenergetic Kiadó", null },
                    { 75, "Goodinvest Kft.", null },
                    { 15, "STB Könyvek Könyvkiadó", null },
                    { 16, "Regulus Art Kft.", null },
                    { 17, "Officina '96 Kiadó", null },
                    { 18, "Danvantara Kiadó", null },
                    { 34, "Kalligram Könyv - és Lapkiadó", null },
                    { 33, "Európa Könyvkiadó", null },
                    { 32, "Ursus Libris Kiadó", null },
                    { 31, "HVG Kiadó", null },
                    { 30, "Gabo Könyvkiadó", null },
                    { 29, "Tarandus Kiadó", null },
                    { 28, "Villon Books Kiadó", null },
                    { 36, "Osiris Kiadó", null },
                    { 27, "Cartaphilus Könyvkiadó", null },
                    { 25, "K.u.K.Kiadó", null },
                    { 24, "Scolar Kiadó", null },
                    { 23, "Akadémiai Kiadó", null },
                    { 22, "L'Harmattan Kiadó", null },
                    { 21, "Ankh Kiadó", null },
                    { 20, "Kairosz Kiadó", null },
                    { 19, "Gabo Könyvkiadó, Gulliver Könyvkiadó", null },
                    { 26, "Édesvíz Kiadó", null },
                    { 76, "General Press Kiadó", null }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "DisplayName", "FriendlyUrl", "Order", "ParentCategoryId" },
                values: new object[,]
                {
                    { 2, "Feng shui", null, "00.01", 1 },
                    { 19, "Sci-fi", null, "03.05", 14 },
                    { 18, "Krimi", null, "03.04", 14 },
                    { 17, "Erotikus", null, "03.03", 14 },
                    { 16, "Fantasy", null, "03.02", 14 },
                    { 15, "Családregény", null, "03.01", 14 },
                    { 13, "Biológia", null, "02.04", 9 },
                    { 20, "Thriller", null, "03.06", 14 },
                    { 12, "Közgazdaságtudomány", null, "02.03", 9 },
                    { 10, "Matematika", null, "02.01", 9 },
                    { 8, "Vers, eposz", null, "01.03", 5 },
                    { 7, "Dráma, színmű", null, "01.02", 5 },
                    { 6, "Életrajz", null, "01.01", 5 },
                    { 4, "Parapszichológia", null, "00.03", 1 },
                    { 3, "Horoszkóp, asztrológia", null, "00.02", 1 },
                    { 11, "Kémia", null, "02.02", 9 },
                    { 21, "Történelmi", null, "03.07", 14 }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "CategoryID", "CoverUrl", "DiscountPrice", "FriendlyUrl", "PageNumber", "Price", "PublishYear", "PublisherID", "RatingCount", "ShortDescription", "Subtitle", "SumRating", "Title" },
                values: new object[,]
                {
                    { 1, 2, null, null, null, 168, 3200, 2004, 1, 0, "Személyes feng shui tanácsadó elmagyarázza a feng shui alapelveit, ugyanakkor új dimenziókat tár fel az érdeklődők számára.Megmutatja, miként befolyásolják egyéni jellemvonásaink a környezetünkhöz való viszonyunkat.A kínai zodiákust tanulmányozva nagyobb önismeretre tehetünk szert, jobban megérthetjük belső erősségeinket.Tudásunkat a \"nyolc körre\" és a nyolc báguára alkalmazva harmóniában élhetünk környezetünkkel, elősegíthetjük személyes fejlődésünket.[br] A könnyen érthető, ábrákkal és fotókkal gazdagon illusztrált könyv segítségével megismerhetjük és elsajátíthatjuk a feng shuit, egészen az alapoktól; ellenőrizhetjük, hogy otthonunk energiamezői harmóniában állnak - e saját energiamintáinkkal; fokozhatjuk hatékonyságunkat munkánk során; bátran használhatjuk a kínai zodiákust baráti, családi és munkakapcsolataink jobb megértéséhez.", "Hogyan éljünk egészségesen és harmonikusan", 0, "Személyes feng shui tanácsadó" },
                    { 106, 16, null, null, null, 1256, 3999, 2011, 12, 0, null, null, 0, "A Kaszás vihara A Malazai Bukottak Könyvének regéje VII." },
                    { 107, 16, null, null, null, 316, 2900, 2012, 33, 0, null, "vagy: Oda - vissza", 0, "A Hobbit" },
                    { 108, 16, null, null, null, 368, 1998, 2004, 61, 0, null, "A Résháború legendája sorozat", 0, "Sebes Jimmy" },
                    { 109, 16, null, null, null, 672, 2999, 2004, 12, 0, null, "A Malazai Bukottak Könyvének regéje II.", 0, "Tremorlor kapuja" },
                    { 110, 16, null, null, null, 1216, 3499, 2012, 12, 0, null, "A tűz és jég dala III.", 0, "Kardok vihara" },
                    { 111, 16, null, null, null, 276, 3450, 2011, 29, 0, null, null, 0, "A Pilis - összeesküvés" },
                    { 112, 16, null, null, null, 504, 2490, 2007, 54, 0, null, null, 0, "Vérkőföldek királya Zsoldosok sorozat III.kötete" },
                    { 91, 16, null, null, null, 344, 2490, 2004, 54, 0, null, "Sötételf - trilógia II.könyv", 0, "Száműzött" },
                    { 113, 16, null, null, null, 528, 2998, 2007, 61, 0, null, null, 0, "Törött korona" },
                    { 114, 17, null, null, null, 192, 2990, 2011, 29, 0, null, "Erotikus történelmi kalandregény", 0, "A királynő mélyén" },
                    { 116, 17, null, null, null, 224, 2999, 2010, 60, 0, null, "XXI.századi dekameron", 0, "Pasipanoptikum" },
                    { 117, 17, null, null, null, 160, 1790, 2012, 38, 0, null, "Regény", 0, "A leánycsősz" },
                    { 118, 17, null, null, null, 288, 2499, 2011, 62, 0, null, null, 0, "A vadászó préda Mit ér a nő a húspiacon?" },
                    { 119, 17, null, null, null, 448, 3499, 2011, 59, 0, null, null, 0, "Vámpírzóna  Halhatatlanok alkonyat után sorozat 5." },
                    { 120, 17, null, null, null, 310, 2990, 2011, 11, 0, null, null, 0, "Szenvedélyes örömök Erotika és bujaság" },
                    { 121, 17, null, null, null, 432, 2950, 2012, 24, 0, null, null, 0, "Nonstop szerelem" },
                    { 115, 16, null, null, null, 896, 2999, 2012, 12, 0, null, null, 0, "Varjak lakomája A tűz és jég dala IV." },
                    { 105, 15, null, null, null, 316, 2480, 2007, 49, 0, null, null, 0, "Bro útja" },
                    { 104, 15, null, null, null, 212, 2990, 2012, 60, 0, null, null, 0, "Éjszaka történt" },
                    { 103, 15, null, null, null, 272, 2699, 2012, 12, 0, null, null, 0, "Igazgató úr A Kispesti Textilgyár igazgatójának igaz története" },
                    { 84, 13, null, null, null, 172, 2200, 2001, 51, 0, null, null, 0, "Gyógynövény embernek, állatnak, növénynek" },
                    { 86, 13, null, null, null, 206, 4200, 2010, 51, 0, null, null, 0, "Vadbiológiai olvasókönyv" },
                    { 87, 13, null, null, null, 240, 3500, 2010, 51, 0, null, null, 0, "Emlős ragadozók Magyarországon" },
                    { 88, 13, null, null, null, 232, 5990, 2010, 9, 0, null, "Az élet kémiai alapjai, az evolúció törvényei, a jövő nagy reményei és aggodalmai", 0, "Genetika - Képes enciklopédia" },
                    { 89, 13, null, null, null, 160, 1450, 2004, 52, 0, null, "A genetikailag módosított élelmiszerek kockázatai", 0, "Génháború" },
                    { 90, 13, null, null, null, 304, 2800, 2004, 53, 0, null, "A klónozást bemutató CD - filmmelléklettel", 0, "Egy klónozó vallomásai" },
                    { 92, 13, null, null, null, 210, 1970, 2012, 55, 0, null, "Gén, ember, társadalom", 0, "Az élet alapkérdései" },
                    { 93, 13, null, null, null, 128, 1980, 2006, 56, 0, null, null, 0, "Nautilus és Sapiens Bevezetés az evolúcióelméletbe" },
                    { 94, 13, null, null, null, 224, 6990, 2011, 30, 0, null, "Bevezetés az emberi anatómiába", 0, "Az emberi test" },
                    { 95, 13, null, null, null, 186, 2999, 2006, 57, 0, null, "Földrajzi enciklopédia", 0, "Élő természet: Állatvilág" },
                    { 96, 15, null, null, null, 504, 3490, 2006, 58, 0, null, null, 0, "Kukockij esetei" },
                    { 97, 15, null, null, null, 512, 3499, 2011, 59, 0, null, null, 0, "Emma lánya" },
                    { 98, 15, null, null, null, 388, 2990, 2009, 27, 0, null, "A 2 Oscar - díjra jelölt film alapjául szolgáló regény", 0, "Rém hangosan és irtó közel" },
                    { 99, 15, null, null, null, 384, 3499, 2011, 59, 0, null, null, 0, "Az angyalos ház" },
                    { 100, 15, null, null, null, 384, 3499, 2011, 59, 0, null, null, 0, "Emma fiai" },
                    { 101, 15, null, null, null, 408, 3499, 2011, 59, 0, null, null, 0, "Emma szerelme" },
                    { 102, 15, null, null, null, 472, 3600, 2009, 33, 0, null, null, 0, "Az isztambuli fattyú" },
                    { 122, 17, null, null, null, 208, 1900, 2011, 27, 0, null, "Egy pornósztár vallomásai", 0, "Patty Diphusa" },
                    { 85, 12, null, null, null, 112, 1800, 2010, 20, 0, null, null, 0, "Szivárványkönyv Közjótan és magyar nemzetgazdaság" },
                    { 123, 17, null, null, null, 336, 2790, 2011, 63, 0, null, null, 0, "Pajkos mesék 4.Erotikus történetek" },
                    { 124, 18, null, null, null, 668, 3999, 2010, 59, 0, null, null, 0, "Angyali játszma" },
                    { 147, 20, null, null, null, 504, 3200, 2012, 33, 0, null, null, 0, "Szarvak" },
                    { 148, 20, null, null, null, 336, 3499, 2012, 59, 0, null, null, 0, "Sub Rosa" },
                    { 149, 20, null, null, null, 560, 3499, 2012, 59, 0, null, null, 0, "Csont és bőr" },
                    { 150, 20, null, null, null, 344, 2490, 2004, 69, 0, null, null, 0, "Sasok és angyalok" },
                    { 151, 20, null, null, null, 656, 3999, 2010, 59, 0, null, null, 0, "A velencei árulás" },
                    { 152, 20, null, null, null, 302, 3499, 2012, 59, 0, null, null, 0, "A makedón összeesküvés" },
                    { 153, 20, null, null, null, 624, 3499, 2011, 59, 0, null, null, 0, "A Bankár" },
                    { 146, 20, null, null, null, 368, 2490, 2007, 54, 0, null, null, 0, "Túlpart" },
                    { 154, 20, null, null, null, 400, 3499, 2012, 59, 0, null, null, 0, "Holtomiglan" },
                    { 156, 21, null, null, null, 296, 2900, 2004, 71, 0, null, "Zsidó és római levelek a II.századból", 0, "Férjem, Bár Kochbá" },
                    { 157, 21, null, null, null, 296, 2990, 2009, 72, 0, null, null, 0, "A hölgy és az egyszarvú" },
                    { 158, 21, null, null, null, 208, 2600, 2007, 33, 0, null, "Legújabb egyiptomi elbeszélések", 0, "Milyen édes az élet a pálmafák árnyékában" },
                    { 159, 21, null, null, null, 524, 3600, 2008, 33, 0, null, "Habsburg pár Mexikó trónján", 0, "Miksa és Sarolta" },
                    { 160, 21, null, null, null, 568, 2800, 2008, 33, 0, null, null, 0, "Körforgás" },
                    { 161, 21, null, null, null, 280, 3570, 2011, 73, 0, null, null, 0, "A velencei bába" },
                    { 162, 21, null, null, null, 552, 3970, 2011, 73, 0, null, null, 0, "Medici Katalin vallomásai" },
                    { 155, 21, null, null, null, 624, 3498, 2010, 70, 0, null, null, 0, "A birodalom hajnala" },
                    { 145, 20, null, null, null, 464, 2980, 2012, 68, 0, null, null, 0, "A gonosz csábítása" },
                    { 144, 19, null, null, null, 260, 2890, 2011, 35, 0, null, null, 0, "Predator: Betondzsungel" },
                    { 143, 19, null, null, null, 330, 3600, 2004, 35, 0, null, "4.kötet", 0, "A Dűne istencsászára" },
                    { 125, 18, null, null, null, 624, 3290, 2012, 10, 0, null, null, 0, "A tetovált lány A nemzetközi bestseller Millennium - trilógia első kötete" },
                    { 127, 18, null, null, null, 360, 2699, 2010, 12, 0, null, null, 0, "A pokol tornácán" },
                    { 128, 18, null, null, null, 304, 2590, 2010, 64, 0, null, null, 0, "Szemérmes barack és gyilkosság  Hannah Swensen titokzatos esetei 7." },
                    { 129, 18, null, null, null, 480, 3499, 2011, 59, 0, null, null, 0, "A bűnös" },
                    { 130, 18, null, null, null, 260, 2000, 2012, 25, 0, null, "A Louvre fantomja", 0, "Belphegor" },
                    { 131, 18, null, null, null, 440, 2600, 2012, 33, 0, null, null, 0, "A másik férfi" },
                    { 132, 18, null, null, null, 320, 1890, 2004, 65, 0, null, "John koroner nyomoz", 0, "Nincs menedék" },
                    { 133, 18, null, null, null, 320, 2200, 2010, 33, 0, null, null, 0, "Halál a felhők között" },
                    { 134, 18, null, null, null, 304, 2800, 2012, 76, 0, null, null, 0, "Megtört csend" },
                    { 135, 19, null, null, null, 224, 2490, 2004, 54, 0, null, null, 0, "A holtak szolgálata Northwind trilógia III.kötet" },
                    { 136, 19, null, null, null, 224, 2880, 2012, 66, 0, null, null, 0, "A Frolix - 8 küldötte" },
                    { 137, 19, null, null, null, 288, 2990, 2010, 67, 0, null, "Az igazi Blade Runner", 0, "Pengefutár" },
                    { 138, 19, null, null, null, 288, 2990, 2011, 67, 0, null, null, 0, "Örvény" },
                    { 139, 19, null, null, null, 368, 2990, 2011, 67, 0, null, null, 0, "Nyugtalanság" },
                    { 140, 19, null, null, null, 400, 3490, 2011, 67, 0, null, null, 0, "Régmúlt napok fénye" },
                    { 141, 19, null, null, null, 432, 2990, 2007, 67, 0, null, null, 0, "Pörgés" },
                    { 142, 19, null, null, null, 444, 2990, 2007, 67, 0, null, "Az őrség - tetralógia első kötete", 0, "Éjszakai őrség" },
                    { 126, 17, null, null, null, 224, 2699, 2011, 62, 0, null, "Egy magyar luxusprostituált és egy budai milliárdos története", 0, "Drága kéj" },
                    { 83, 12, null, null, null, 360, 3990, 2011, 23, 0, null, "A minőség társadalma", 0, "Új közgazdaságtan" },
                    { 82, 12, null, null, null, 640, 5980, 2011, 36, 0, null, null, 0, "A közgazdaságtan alapjai" },
                    { 81, 12, null, null, null, 400, 4200, 2011, 47, 0, null, null, 0, "A nemzetközi és a világgazdaságtan alapjai" },
                    { 30, 4, null, null, null, 224, 2200, 2011, 25, 0, null, "... egy orvosnő szemével", 0, "Kísértetek, rejtelmek, átkok" },
                    { 31, 4, null, null, null, 286, 2990, 2006, 26, 0, null, "Útlevél az új világba", 0, "Belépési pont" },
                    { 34, 4, null, null, null, 228, 3450, 2012, 29, 0, null, "Pszi - akták", 0, "Az igazság odaát van" },
                    { 35, 4, null, null, null, 224, 3500, 2011, 30, 0, null, null, 0, "Paranormális erők kézikönyve" },
                    { 36, 4, null, null, null, 260, 3290, 2012, 26, 0, null, "A spirituális pszichológia lényege", 0, "Lelkedhez hűen" },
                    { 37, 4, null, null, null, 272, 2499, 2010, 12, 0, null, "Használjuk mentális erőnket, hogy sikeresek legyünk az élet minden területén!", 0, "Érzékeken túli észlelés José Silva módszerével" },
                    { 38, 4, null, null, null, 336, 3900, 2010, 31, 0, null, "Fedezd fel, mire születtél, és minden megváltozik", 0, "Az alkotó elem" },
                    { 14, 4, null, null, null, 144, 4990, 2007, 11, 0, null, "Különös jelenségek, furcsa babonák és ősi rejtélyek", 0, "Megmagyarázhatatlan jelenségek enciklopédiája" },
                    { 39, 4, null, null, null, 384, 4300, 2010, 32, 0, null, "A tudomány és a spiritualitás találkozása a paranormális jelenségek bizonyítékainak fényében", 0, "A materializmus vége" },
                    { 21, 6, null, null, null, 144, 4990, 2010, 17, 0, null, null, 0, "Sütő András világa" },
                    { 40, 6, null, null, null, 408, 3500, 2010, 33, 0, null, "Stephen King élete", 0, "Kísértetszív" },
                    { 41, 6, null, null, null, 264, 2900, 2007, 34, 0, null, "Képeskönyv", 0, "Egy csecsemő emlékiratai(CD - ROM melléklettel)" },
                    { 44, 6, null, null, null, 356, 3500, 2012, 33, 0, null, "Egy szenvedélyes élet", 0, "Robert Merle" },
                    { 45, 6, null, null, null, 392, 2980, 2011, 36, 0, null, null, 0, "Lázár Ervin élete és munkássága" },
                    { 46, 6, null, null, null, 480, 3500, 2011, 33, 0, null, null, 0, "Laterna magica" },
                    { 47, 6, null, null, null, 300, 2500, 2006, 37, 0, null, null, 0, "Fél lábbal a földön" },
                    { 18, 6, null, null, null, 256, 2500, 2010, 14, 0, null, null, 0, "Földközeli kalandok" },
                    { 13, 4, null, null, null, 256, 2890, 2010, 10, 0, "A könyv a holotróp légzéstechnika elméletét és gyakorlatát összegzi.A pszichoterápia és az önmegismerés ezen új módszere magába foglalja a mélylélektan különféle irányzatainak elemeit, emellett merít a modern tudatkutatásból, a kulturális antropológiából és a keleti spirituális gyakorlatokból is.[br] A technikát kidolgozó szerzők esetleírásokkal is alátámasztják a holotróp légzés sokrétű terápiás, valamint az önmegismerést, belső fejlődést elősegítő hatását.", "Holotróp légzéstechnika - az öngyógyítás új útja", 0, "Transzlégzés" },
                    { 26, 3, null, null, null, 290, 4800, 2012, 21, 0, null, null, 0, "Ájurvédikus asztrológia és marmapunktúra" },
                    { 25, 3, null, null, null, 354, 3900, 2012, 20, 0, null, "Az asztrológia belső rendje", 0, "Harmonia Universalis" },
                    { 2, 2, null, null, null, 128, 4900, 2008, 2, 0, "Képzelje azt, hogy kertje egy ruhadarab.A kertnek a ruhadarabhoz hasonlóan \"jól kell állnia\" tulajdonosának.Nézzen egy kicsit más szemmel kertjére, erkélyére vagy teraszára. Minden a helyén van? Tükrözi - e a kert a személyiségét?[br] A kötet segít elmélyedni a feng shui nyújtotta lehetőségekben.Ne gondoljon azonnal teljes átalakításra, éppen az óvatos, kisebb javítások a feng shui erősségei. Varázsolja kertjét oázissá, engedje szabadon szárnyalni képzeletét, váljon eggyé a természettel.Tanuljon mások tapasztalatából, olyan emberekéből, akik már rátaláltak a feng shuira, a harmónia és életöröm forrására.", "Ötletek kertekhez, teraszokhoz, erkélyekhez ", 0, "Az én feng shui-kertem" },
                    { 3, 2, null, null, null, 80, 699, 2012, 3, 0, "Az ember, az ember által létrehozott környezet, valamint a természet összhangjának több évezredes kínai tudománya már a 19.század közepe óta ismert a nyugati világban. Odaadó hívei a szabályrendszer szigorú betartásával alakítják életüket, lakókörnyezetüket, de még bírálói is kénytelenek elismerni, a megállapítások mélyén bonyolult összefüggések rejlenek.[br] [br] A feng shui nem csupán a lakberendezés ügyes tudománya: jelen van benne az animizmus, a taoizmus, a konfucianizmus és a buddhizmus jónéhány eszméje. Rávilágít a látszólag egymástól távol álló dolgok közötti összefüggésekre, fellebbenti a fátylat a misztikus összefüggésekről, rendszerbe foglalva állítja elénk a hajdanvolt bölcsek megfigyeléseit, a geomanciával, numerológiával és asztrológiával foglalkozó tudósok megállapításait.", "A természet és az egyensúly kínai tudományával kapcsolatos alapvető tudnivalók", 0, "Feng Shui" },
                    { 4, 2, null, null, null, 160, 3990, 2009, 4, 0, "Fengsuj a gyakorlatban[br]- Olyan ősi filozófiát mutat be, melynek követésével irányíthatjuk a pozitív és a negatív energiákat, és ezzel megváltoztathatjuk életünket és sorsunkat.[br]- Praktikus tanácsokkal lát el otthonunk helyiségeinek elhelyezését és berendezését illetően, melyek segíthetnek céljaink megvalósításában, vágyaink kiteljesítésében.[br]- Bemutatja, hogyan tehetjük kellemesebbé otthonunkat és hogyan javíthatunk általános közérzetünkön a megfelelő színek, anyagok és más díszítőelemek kiválasztásával.[br]- A lakás ideális berendezésére vonatkozó javaslatokkal hozzásegít a jó kapcsolatok, a jól menő üzlet kiépítéséhez, a kielégítő szexuális élethez, a jó egészséghez.", null, 0, "Fengsuj a gyakorlatban" },
                    { 6, 2, null, null, null, 152, 2100, 2006, 1, 0, "Az elmúlt évezredek során Kelet nagy bölcsei számos tanítással és igazsággal gazdagították az emberiséget. Azt tartották, hogy fejlődésünk célja a tökéletes emberi állapot, a megvilágosodás elérése. A jó energiatérrel, élő és éltető energiákkal rendelkező építmények, helyiségek nagymértékben elősegítik ezt a folyamatot.[br] A feng-shui, ami alapjában véve annyit jelent, hogy az ember összhangban él az őt körülvevő világgal, ennek megvalósításához nyújt aktív és tudatos segítséget.[br] A könyv két szerzője feng - shui mester, szakértő.Munkájukkal egy, az ősi tudásra épülő, de a nyugati életvitel számára is elfogadható új sorozat első kötetét alkották meg.Céljuk, hogy mindazok kezébe és otthonába elkerülhessenek ezek a tanítások, akik szeretnek tanulni, és szívesen tökéletesítik önmagukat, környezetüket valamint kíváncsiak a \"miértekre\".", "Első kötet -Alapfogalmak I.", 0, "A nyugati környezetben is használható Feng - Shui" },
                    { 7, 2, null, null, null, 228, 2780, 2005, 6, 0, "Könyvem első részében a Négyoszlopos Sorsmeghatározás különleges módszerét mutatom be, ami újdonság a Kínán kívül élők számára. A Négyoszlopos Sorsmeghatározás klasszikus sorselemzési eljárás, pontos, időpontok szerint behatárolható képet ad az ember képességeiről, lehetőségeiről, élete szerencsés és balszerencsés időszakairól.A technikát néhány híresség és befolyásos politikus sorsának elemzéseivel illusztrálom. Közlöm előzetes jóslataimat az amerikai - iraki összecsapások kimeneteléről az 1990 - 91 - es Öbölháborúban, megtudhatják mekkora szerepe volt az események végeredményére id. Bush elnök és Saddam Hussein sorsának és szerencséjének. Kiderül, milyen végzetes okok vezettek Marilyn Monroe halálához.S amint Karen Carpenter és John Lennon fiatalon elhunyt művészek tragikus sorsának okai, úgy Margaret Thatcher és Mihail Gorbacsov politikai karrierjének alakulása is kikövetkeztethető Sorsuk Négyoszlopából, valamint Szerencseoszlopaikból.[br] A könyv második részében a Feng Shui rejtett szépségeivel foglalkozom, s igyekszem bemutatni a tan kevéssé ismert összefüggéseit és módszereit.Hongkong híres épületeinek Feng Shui elemzésén túl, számos érdekes példán mutatom be, mi mindenre jó a Feng Shui. Szeretném, ha Olvasóim e különleges technika ismeretében boldogabban élhetnének. (Raymond Lo)", "A Repülő csillagok és a kínai sorselemzés művészete", 0, "A Feng shui és a siker titka térben és időben" },
                    { 8, 2, null, null, null, 140, 3580, 2004, 7, 0, "A távol-keleti kertépítés mind a hobbi-, mind a profi kertész számára olyan elmélyült, mégis egyszerű alapelvekkel szolgál, amelyek segítségével szívvel-lélekkel belevethetjük magunkat az érzékeket gyönyörködtető és üdítő légkörű kert megteremtésébe.[br] Szinte az egész világot beutaztam fengshui - és energetikai szakértőként, és szomorúan kellett tapasztalnom, hogy elveszett az a fő cél, amiért az épületeket, illetve a kerteket építjük - tudniillik, hogy olyan energiával és élettel teli helyet hozzunk létre, ahol feltöltődünk és visszanyerjük életkedvünket. (...) A könyvemben bemutatott ázsiai kertkialakítási és fengshui - alapelveket bármelyik kertben alkalmazhatjuk típustól és nagyságtól függetlenül, legyen az egy virágos láda az ablakunkban vagy egy park.Különös hangsúlyt helyeztem a kövek kiválasztására és elhelyezésére, ahogy azt a taoisták és a zen követői alkalmazták.A \"Beszélgessünk a növényekkel\" című fejezetben leírtak elolvasása után pedig úgy tekintünk majd a növényekre, ahogy eddig még soha.", "A taoizmus és a zen a kertművelésben", 0, "Feng Shui és kert" },
                    { 10, 2, null, null, null, 120440, 2588, 2002, 7, 0, "E könyvben az üzleti Feng Shui gyakorlati művelésének különböző szempontjait és irányelveit igyekszem érthetően felvázolni, hogy a kedves Olvasó az eddig talán kevésbé ismert szempontokról is áttekintést szerezhessen. Ezáltal elkerülheti a hibákat és adott esetben orvosolhatja a bajt, amelyek miatt szembekerülhetett munkatársaival. Még abban az esetben is, ha elbizonytalanodna, mert üzlete nem megy olyan jól, mint ahogy mehetne, az üzleti Feng Shui kínálta kiváló ötletek kimozdítják az energiát pangó helyzetéből, és a kívánt folyásirányba terelik.", null, 0, "Feng Shui az irodában és az üzleti életben" },
                    { 11, 2, null, null, null, 512, 7990, 2009, 9, 0, "Az egészség és a jó közérzet ismereteinek tárháza.[br] - Irányítsd ősi technikákkal és évszázadok bölcsességével tested, lelked és otthonod különleges erőit és tulajdonságait.[br] - Részletes útmutatások a feng shui ősi kínai művészetéhez, gyakorlati tanácsok az elvek alkalmazásához a nyugalmas terek és lelkileg tápláló környezet megteremtése érdekében.[br] - Tisztítsd meg a teret, ahol élsz vagy dolgozol.A tömjén és más füstölők, a víz és a hang erejének egyszerű eszközeivel megmozgathatod a stagnáló energiákat, és otthonodban tavaszi nagytakarítást végezhetsz.[br] - Mindaz, amit tudnod kell ahhoz, hogy otthonodat nyugalommal és kiegyensúlyozott energiával telt, pozitív térré változtasd.", "1800 képpel illusztrált gyakorlati útmutató", 0, "A feng shui nagykönyve" },
                    { 12, 2, null, null, null, 152, 1990, 2008, 6, 0, "Ebben a könyvben különleges tematikával mutatom be a Feng Shui egy kis szeletét. Mint látható, a könyv két részből áll. Az egyik fele a nőknek, a másik a férfiaknak szól. Természetesen a nőknek is hasznos - sőt ajánlott - a férfiaknak írt oldalakat elolvasni, hiszen nem ugyanazt a témát magyarázom el kétféleképpen. A témaválasztás is más és más. Nagyon szeretném, ha mind a nők, mind a férfiak - akik eddig kétkedve fogadták a Feng Shuit - kicsit jobban belelátnának e filozófia működésébe.(a Szerző)", null, 0, "Feng Shui nőknek - Feng Shui férfiaknak" },
                    { 15, 3, null, null, null, 360, 2799, 2010, 12, 0, null, "Horoszkópelemzés buddhista megközelítésben", 0, "Buddhizmus és asztrológia" },
                    { 16, 3, null, null, null, 88, 1750, 2003, 13, 0, null, null, 0, "Asztrológiaiskola II.Tarot és kínai jóstanfolyamok" },
                    { 17, 3, null, null, null, 276, 2800, 2004, 1, 0, null, null, 0, "Mély forrás A pszichológiai asztrológia tizenkét archetípusa" },
                    { 19, 3, null, null, null, 296, 499, 2009, 15, 0, null, null, 0, "Kínai örökhoroszkóp Tervezze meg jövőjét!" },
                    { 20, 3, null, null, null, 228, 3590, 2011, 16, 0, null, null, 0, "A zodiákus története" },
                    { 22, 3, null, null, null, 208, 2850, 2011, 18, 0, null, "A Dzsotir Vidjá az ősi indiai asztrológia tanítása", 0, "Asztro pszichológia" },
                    { 23, 3, null, null, null, 496, 9900, 2011, 19, 0, null, "Hiteles és átfogó útmutató az asztrológia tudományához", 0, "Parker Asztrológia" },
                    { 24, 3, null, null, null, 240, 2600, 2011, 1, 0, null, "Az orvosi asztrológia kézikönyve II.kötet", 0, "A gyógyulás szelencéje" },
                    { 48, 6, null, null, null, 864, 3500, 2010, 33, 0, null, null, 0, "Szeretetről, sötétségről" },
                    { 49, 6, null, null, null, 320, 2900, 2011, 34, 0, null, "Hunyady Sándor arcképe", 0, "A bolygó fénye" },
                    { 27, 7, null, null, null, 222, 2500, 2012, 22, 0, null, "Drámák", 0, "Big Shoot" },
                    { 28, 7, null, null, null, 320, 4990, 2011, 23, 0, null, null, 0, "Az ember tragédiája Jankovics Marcell animációs filmváltozatának képeivel" },
                    { 65, 10, null, null, null, 216, 1470, 2004, 8, 0, null, null, 0, "Matematika 4.Tankönyv, I.kötet" },
                    { 66, 10, null, null, null, 56, 890, 2008, 44, 0, null, null, 0, "Szöveges ki(s)számoló feladatok 3.osztályosoknak" },
                    { 67, 10, null, null, null, 208, 3500, 2011, 45, 0, null, null, 0, "Nagy kérdések: Matematika" },
                    { 68, 10, null, null, null, 208, 3500, 2011, 45, 0, null, null, 0, "Nagy kérdések: Világegyetem" },
                    { 69, 10, null, null, null, 192, 2900, 2006, 14, 0, null, null, 0, "A számítástudomány alapjai" },
                    { 70, 10, null, null, null, 336, 2990, 2009, 24, 0, null, null, 0, "Valószínűségszámítás és matematikai statisztika" },
                    { 71, 10, null, null, null, 180, 6800, 2012, 46, 0, null, "A rózsaablakok titkai", 0, "A szépség geometriája, a geometria szépsége" },
                    { 43, 11, null, null, null, 520, 9950, 2008, 23, 0, null, null, 0, "Általános kémia" },
                    { 72, 11, null, null, null, 240, 5999, 2011, 17, 0, null, "Kalandozás a Világegyetem atomjai között", 0, "Kémiai elemek" },
                    { 73, 11, null, null, null, 596, 4200, 2011, 23, 0, null, "Tévhitek, félreértések, magyarázatok", 0, "Száz kémiai mítosz" },
                    { 74, 11, null, null, null, 280, 5200, 2010, 23, 0, null, null, 0, "Elválasztástechnikai módszerek elmélete és gyakorlata" },
                    { 75, 12, null, null, null, 1196, 5800, 2011, 47, 0, null, "Az eredeti, teljes szöveg új kiadása", 0, "Vizsgálódás a nemzetek jólétének természetéről és okairól I - II." },
                    { 76, 12, null, null, null, 168, 2910, 2003, 48, 0, null, null, 0, "Gazdasági kislexikon és képletgyűjtemény" },
                    { 77, 12, null, null, null, 706, 8000, 2012, 49, 0, null, "Vállalkozói környezet - A tulajdonszerkezet változása a gazdasági átmenet időszakában", 0, "Vállalat és vállalkozás" },
                    { 78, 12, null, null, null, 672, 4990, 2012, 34, 0, null, null, 0, "A szocialista rendszer" },
                    { 79, 12, null, null, null, 420, 4600, 2012, 23, 0, null, null, 0, "Aktív szabályozás vagy gazdaságpolitikai nihilizmus?" },
                    { 80, 12, null, null, null, 804, 6000, 2011, 50, 0, null, "Alapfogalmak, alkalmazások és mérési módszerek", 0, "Az európai közösségi versenyjog közgazdaságtana" },
                    { 64, 10, null, null, null, 304, 2020, 2008, 8, 0, null, null, 0, "Matematika 6.tankönyv, bővített változat" },
                    { 163, 21, null, null, null, 474, 3790, 2011, 74, 0, null, null, 0, "Assassin's Creed: Testvériség" },
                    { 42, 10, null, null, null, 214, 1190, 2002, 35, 0, null, null, 0, "Érettségi, felvételi feladatok: Matematika" },
                    { 63, 8, null, null, null, 208, 1480, 1999, 5, 0, null, null, 0, "Kínai és japán költők" },
                    { 29, 7, null, null, null, 320, 3750, 2012, 24, 0, null, null, 0, "Drámák V.Az Árpád - ház - A békecsászár - Príma környék" },
                    { 32, 7, null, null, null, 144, 1990, 2011, 27, 0, null, "Schall Eszter rajzaival", 0, "Két ÜBÜ - dráma" },
                    { 50, 7, null, null, null, 564, 3700, 2010, 33, 0, null, "Mai francia drámák", 0, "Művészet" },
                    { 51, 7, null, null, null, 88, 1490, 2012, 38, 0, null, "Színdarab 4 részben, 35 jelenetben", 0, "Maria Quisling" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "CategoryID", "CoverUrl", "DiscountPrice", "FriendlyUrl", "PageNumber", "Price", "PublishYear", "PublisherID", "RatingCount", "ShortDescription", "Subtitle", "SumRating", "Title" },
                values: new object[,]
                {
                    { 52, 7, null, null, null, 416, 3900, 2012, 39, 0, null, "Hat színmű", 0, "Valaki jön majd" },
                    { 53, 7, null, null, null, 280, 3990, 2012, 29, 0, null, null, 0, "Pokol" },
                    { 54, 7, null, null, null, 144, 1950, 2011, 24, 0, null, null, 0, "Üvegcserepek" },
                    { 55, 7, null, null, null, 288, 2800, 2011, 40, 0, null, "Színes pokol - Útvesztő - Isten komédiásai", 0, "A pokol színei" },
                    { 59, 7, null, null, null, 232, 1980, 2005, 5, 0, null, null, 0, "Goethe Hölderlin Heine versei" },
                    { 5, 8, null, null, null, 176, 1650, 1999, 5, 0, "François Villon válogatott versei.", null, 0, "François Villon versei" },
                    { 33, 8, null, null, null, 272, 2980, 2003, 28, 0, null, null, 0, "Európai költők antológiája" },
                    { 56, 8, null, null, null, 88, 1260, 2010, 41, 0, null, null, 0, "A csörgőkígyó útja" },
                    { 57, 8, null, null, null, 264, 3990, 2010, 42, 0, null, "Kínai, indiai, görög, latin, angol, francia, német, olasz, spanyol, román, dél - amerikai...", 0, "Száz vers" },
                    { 58, 8, null, null, null, 112, 1900, 2010, 43, 0, null, null, 0, "Honvágy" },
                    { 60, 8, null, null, null, 240, 1980, 2003, 5, 0, null, null, 0, "Dalok és szonettek" },
                    { 61, 8, null, null, null, 264, 2380, 2003, 5, 0, null, null, 0, "Dsida Jenő versei" },
                    { 62, 8, null, null, null, 160, 1650, 2002, 5, 0, null, null, 0, "Arany János balladái" },
                    { 9, 10, null, null, null, 360, 2050, 2006, 8, 0, null, "Példatár", 0, "Többváltozós függvények analízise - Bolyai - könyvek" },
                    { 164, 21, null, null, null, 480, 3790, 2011, 75, 0, null, null, 0, "Assassin's Creed: Reneszánsz" }
                });

            migrationBuilder.InsertData(
                table: "BookAuthor",
                columns: new[] { "BookId", "AuthorId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 109, 93 },
                    { 110, 96 },
                    { 111, 97 },
                    { 112, 98 },
                    { 113, 99 },
                    { 115, 96 },
                    { 114, 100 },
                    { 116, 101 },
                    { 117, 102 },
                    { 118, 103 },
                    { 119, 104 },
                    { 120, 105 },
                    { 121, 106 },
                    { 122, 107 },
                    { 123, 108 },
                    { 108, 95 },
                    { 107, 94 },
                    { 106, 93 },
                    { 91, 98 },
                    { 89, 80 },
                    { 90, 81 },
                    { 92, 82 },
                    { 93, 83 },
                    { 94, 84 },
                    { 95, 85 },
                    { 95, 86 },
                    { 126, 111 },
                    { 97, 87 },
                    { 99, 87 },
                    { 100, 87 },
                    { 101, 87 },
                    { 102, 89 },
                    { 103, 90 },
                    { 104, 91 },
                    { 105, 92 },
                    { 98, 88 },
                    { 88, 79 },
                    { 124, 109 },
                    { 127, 112 },
                    { 148, 132 },
                    { 149, 133 },
                    { 150, 147 },
                    { 151, 134 },
                    { 152, 135 },
                    { 153, 136 },
                    { 154, 137 },
                    { 155, 138 },
                    { 156, 139 },
                    { 157, 140 },
                    { 158, 141 },
                    { 159, 142 },
                    { 160, 143 },
                    { 161, 144 },
                    { 162, 145 },
                    { 147, 131 },
                    { 146, 130 },
                    { 145, 129 },
                    { 144, 128 },
                    { 128, 113 },
                    { 129, 114 },
                    { 130, 115 },
                    { 131, 116 },
                    { 132, 117 },
                    { 133, 118 },
                    { 134, 119 },
                    { 125, 110 },
                    { 135, 120 },
                    { 137, 122 },
                    { 138, 123 },
                    { 139, 124 },
                    { 140, 125 },
                    { 141, 123 },
                    { 142, 126 },
                    { 143, 127 },
                    { 136, 121 },
                    { 84, 77 },
                    { 85, 78 },
                    { 83, 76 },
                    { 14, 13 },
                    { 30, 28 },
                    { 31, 29 },
                    { 34, 32 },
                    { 35, 33 },
                    { 36, 34 },
                    { 37, 35 },
                    { 38, 36 },
                    { 39, 37 },
                    { 18, 17 },
                    { 40, 42 },
                    { 41, 39 },
                    { 44, 42 },
                    { 45, 43 },
                    { 46, 44 },
                    { 13, 12 },
                    { 26, 24 },
                    { 25, 23 },
                    { 24, 22 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 10, 8 },
                    { 47, 45 },
                    { 11, 10 },
                    { 15, 14 },
                    { 16, 15 },
                    { 17, 16 },
                    { 19, 18 },
                    { 20, 19 },
                    { 22, 20 },
                    { 23, 21 },
                    { 12, 11 },
                    { 48, 46 },
                    { 49, 47 },
                    { 27, 25 },
                    { 68, 61 },
                    { 69, 62 },
                    { 70, 63 },
                    { 71, 64 },
                    { 43, 41 },
                    { 72, 65 },
                    { 73, 66 },
                    { 67, 60 },
                    { 74, 67 },
                    { 76, 69 },
                    { 77, 70 },
                    { 78, 71 },
                    { 79, 72 },
                    { 80, 73 },
                    { 81, 74 },
                    { 82, 75 },
                    { 75, 68 },
                    { 163, 146 },
                    { 66, 59 },
                    { 42, 40 },
                    { 28, 26 },
                    { 29, 27 },
                    { 32, 30 },
                    { 51, 48 },
                    { 52, 49 },
                    { 53, 50 },
                    { 54, 51 },
                    { 64, 58 },
                    { 55, 52 },
                    { 33, 31 },
                    { 56, 53 },
                    { 58, 54 },
                    { 60, 55 },
                    { 61, 56 },
                    { 62, 57 },
                    { 9, 9 },
                    { 5, 5 },
                    { 164, 146 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_CategoryID",
                table: "Book",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Book_PublisherID",
                table: "Book",
                column: "PublisherID");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_AuthorId",
                table: "BookAuthor",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentCategoryId",
                table: "Category",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_BookID",
                table: "Comment",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserID",
                table: "Comment",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_BillingAddressId",
                table: "Order",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShippingAddressId",
                table: "Order",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_BookId",
                table: "OrderItem",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_BookId",
                table: "Rating",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_UserId",
                table: "Rating",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_AddressId",
                table: "UserAddress",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthor");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "UserAddress");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Publisher");
        }
    }
}
