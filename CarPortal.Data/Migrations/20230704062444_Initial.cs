using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarPortal.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EngineTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Makes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MakeId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Models_Makes_MakeId",
                        column: x => x.MakeId,
                        principalTable: "Makes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    EngineTypeId = table.Column<int>(type: "int", nullable: false),
                    ConditionId = table.Column<int>(type: "int", nullable: false),
                    ManufactureYear = table.Column<int>(type: "int", maxLength: 2023, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Conditions_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "Conditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_EngineTypes_EngineTypeId",
                        column: x => x.EngineTypeId,
                        principalTable: "EngineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 7, 4, 6, 24, 43, 657, DateTimeKind.Utc).AddTicks(9227))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offers_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoPath = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    OfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cars" },
                    { 2, "SUVs" },
                    { 3, "Motors" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Black" },
                    { 2, "White" },
                    { 3, "Silver" },
                    { 4, "Gray" },
                    { 5, "Red" },
                    { 6, "Blue" },
                    { 7, "Brown" },
                    { 8, "Green" },
                    { 9, "Yellow" },
                    { 10, "Orange" },
                    { 11, "Purple" },
                    { 12, "Pink" },
                    { 13, "Gold" },
                    { 14, "Beige" },
                    { 15, "Bronze" },
                    { 16, "Copper" },
                    { 17, "Maroon" },
                    { 18, "Navy" },
                    { 19, "Turquoise" },
                    { 20, "Teal" }
                });

            migrationBuilder.InsertData(
                table: "Conditions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "New" },
                    { 2, "Used" },
                    { 3, "For parts" }
                });

            migrationBuilder.InsertData(
                table: "EngineTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Petrol" },
                    { 2, "Diesel" },
                    { 3, "Electric" },
                    { 4, "Hybrid" }
                });

            migrationBuilder.InsertData(
                table: "Makes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "all" },
                    { 2, "Alfa Romeo" },
                    { 3, "Aston Martin" },
                    { 4, "Audi" },
                    { 5, "Bentley" },
                    { 6, "BMW" },
                    { 7, "Citroen" },
                    { 8, "Dacia" },
                    { 9, "DS" },
                    { 10, "Ferrari" },
                    { 11, "Fiat" },
                    { 12, "Ford" }
                });

            migrationBuilder.InsertData(
                table: "Makes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 13, "Honda" },
                    { 14, "Hyundai" },
                    { 15, "Infiniti" },
                    { 16, "Jaguar" },
                    { 17, "Jeep" },
                    { 18, "Kia" },
                    { 19, "Lamborghini" },
                    { 20, "Land Rover" },
                    { 21, "Lexus" },
                    { 22, "Lotus" },
                    { 23, "Maserati" },
                    { 24, "Mazda" },
                    { 25, "McLaren" },
                    { 26, "Mercedes - Benz" },
                    { 27, "Mini" },
                    { 28, "Mitsubishi" },
                    { 29, "Nissan" },
                    { 30, "Peugeot" },
                    { 31, "Porsche" },
                    { 32, "Renault" },
                    { 33, "Rolls - Royce" },
                    { 34, "Seat" },
                    { 35, "Skoda" },
                    { 36, "Smart" },
                    { 37, "Subaru" },
                    { 38, "Suzuki" },
                    { 39, "Tesla" },
                    { 40, "Toyota" },
                    { 41, "Volkswagen" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Blagoevgrad" },
                    { 2, "Burgas" },
                    { 3, "Dobrich" },
                    { 4, "Gabrovo" },
                    { 5, "Grad Sofia" },
                    { 6, "Khaskoro" },
                    { 7, "Kurdzhali" },
                    { 8, "Kyustendil" },
                    { 9, "Lovech" },
                    { 10, "Montana" },
                    { 11, "Pazardzhik" },
                    { 12, "Pernik" },
                    { 13, "Pleven" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 14, "Plovdiv" },
                    { 15, "Razgrad" },
                    { 16, "Ruse" },
                    { 17, "Shumen" },
                    { 18, "Silistra" },
                    { 19, "Sliven" },
                    { 20, "Smolyan" },
                    { 21, "Sofia" },
                    { 22, "Stara Zagora" },
                    { 23, "Turgorishte" },
                    { 24, "Varna" },
                    { 25, "Veliko Turnovo" },
                    { 26, "Vidin" },
                    { 27, "Vratsa" },
                    { 28, "Yambol" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegionId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("3ba0e94f-d15f-4911-9bd0-e10e9d89397f"), 0, "53142987-5248-498a-8376-a60fba1d58f4", "ceca@lepa.sr", false, false, null, "CECA@LEPA.SR", "CECA@LEPA.SR", null, null, false, 1, null, false, "ceca@lepa.sr" });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "CategoryId", "MakeId", "Name" },
                values: new object[,]
                {
                    { 1, 1, 2, "Giulia Quadrifoglio" },
                    { 2, 1, 2, "155 Q4" },
                    { 3, 1, 2, "159" },
                    { 4, 1, 3, "DBS Volante" },
                    { 5, 1, 3, "DB11" },
                    { 6, 1, 4, "TT" },
                    { 7, 2, 4, "Q7" },
                    { 8, 2, 4, "Q8" },
                    { 9, 1, 4, "A3" },
                    { 10, 1, 4, "A4" },
                    { 11, 1, 4, "A6" },
                    { 12, 1, 4, "S3" },
                    { 13, 1, 4, "S4" },
                    { 14, 1, 4, "S6" },
                    { 15, 1, 4, "RS3" },
                    { 16, 1, 4, "RS4" },
                    { 17, 1, 4, "RS6" },
                    { 18, 1, 5, "Continental GT" },
                    { 19, 1, 5, "Mulsanne" },
                    { 20, 1, 6, "M2" },
                    { 21, 1, 6, "M3" },
                    { 22, 1, 6, "M4" },
                    { 23, 1, 6, "M5" },
                    { 24, 1, 6, "M6" },
                    { 25, 1, 6, "M8" },
                    { 26, 2, 6, "X1" },
                    { 27, 2, 6, "X2" },
                    { 28, 2, 6, "X3" },
                    { 29, 2, 6, "X4" },
                    { 30, 2, 6, "X5" },
                    { 31, 2, 6, "X6" },
                    { 32, 2, 6, "X7" },
                    { 33, 1, 7, "C1" },
                    { 34, 1, 7, "C2" },
                    { 35, 1, 7, "C3" },
                    { 36, 1, 7, "C4" },
                    { 37, 2, 8, "Sandero" },
                    { 38, 2, 8, "Duster" },
                    { 39, 2, 9, "7 CROSSBACK" },
                    { 40, 1, 9, "5LS" },
                    { 41, 1, 10, "488" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "CategoryId", "MakeId", "Name" },
                values: new object[,]
                {
                    { 42, 1, 10, "Portofino" },
                    { 43, 1, 10, "458 Italia" },
                    { 44, 1, 11, "Punto" },
                    { 45, 1, 11, "500" },
                    { 46, 1, 12, "Fiesta" },
                    { 47, 1, 12, "Mustang" },
                    { 48, 1, 13, "Sivic" },
                    { 49, 1, 13, "Pilot" },
                    { 50, 1, 14, "Elantra" },
                    { 51, 2, 14, "Tucson" },
                    { 52, 1, 15, "Q50" },
                    { 53, 2, 15, "QX50" },
                    { 54, 1, 16, "F-TYPE" },
                    { 55, 1, 16, "XF" },
                    { 56, 2, 16, "F-PACE" },
                    { 57, 2, 17, "Compass" },
                    { 58, 2, 17, "Cherokee" },
                    { 59, 1, 18, "K5" },
                    { 60, 2, 18, "Sportage" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "ColorId", "ConditionId", "EngineTypeId", "ManufactureYear", "ModelId" },
                values: new object[] { 1, 1, 1, 1, 2021, 1 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "ColorId", "ConditionId", "EngineTypeId", "ManufactureYear", "ModelId" },
                values: new object[] { 2, 5, 2, 2, 2006, 6 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "ColorId", "ConditionId", "EngineTypeId", "ManufactureYear", "ModelId" },
                values: new object[] { 3, 3, 3, 3, 2000, 3 });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "CarId", "Description", "OwnerId", "Price", "Title" },
                values: new object[] { new Guid("87745040-aaf7-426e-a211-d86d80085213"), 3, "Experience the epitome of automotive innovation with our brand new car. With its captivating design, advanced technology, and unparalleled performance, this vehicle sets new standards in the world of automobiles. Get ready to embark on a thrilling journey like never before.", new Guid("3ba0e94f-d15f-4911-9bd0-e10e9d89397f"), 200m, "Test3" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "CarId", "Description", "OwnerId", "Price", "Title" },
                values: new object[] { new Guid("a754b9a5-01b2-4661-bee3-eaf37e717c36"), 2, "Experience the epitome of automotive innovation with our brand new car. With its captivating design, advanced technology, and unparalleled performance, this vehicle sets new standards in the world of automobiles. Get ready to embark on a thrilling journey like never before.", new Guid("3ba0e94f-d15f-4911-9bd0-e10e9d89397f"), 2000m, "Test2" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "CarId", "Description", "OwnerId", "Price", "Title" },
                values: new object[] { new Guid("ecc6f335-d9d0-4a1b-bb97-3a8e44ffe3aa"), 1, "Experience the epitome of automotive innovation with our brand new car. With its captivating design, advanced technology, and unparalleled performance, this vehicle sets new standards in the world of automobiles. Get ready to embark on a thrilling journey like never before.", new Guid("3ba0e94f-d15f-4911-9bd0-e10e9d89397f"), 20000m, "Test1" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "OfferId", "PhotoPath" },
                values: new object[] { 1, new Guid("ecc6f335-d9d0-4a1b-bb97-3a8e44ffe3aa"), "OfferImages/test1.jpeg" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "OfferId", "PhotoPath" },
                values: new object[] { 2, new Guid("a754b9a5-01b2-4661-bee3-eaf37e717c36"), "OfferImages/test2.jpg" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "OfferId", "PhotoPath" },
                values: new object[] { 3, new Guid("87745040-aaf7-426e-a211-d86d80085213"), "OfferImages/test3.jpg" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RegionId",
                table: "AspNetUsers",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ColorId",
                table: "Cars",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ConditionId",
                table: "Cars",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_EngineTypeId",
                table: "Cars",
                column: "EngineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ModelId",
                table: "Cars",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_OfferId",
                table: "Images",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_CategoryId",
                table: "Models",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_MakeId",
                table: "Models",
                column: "MakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CarId",
                table: "Offers",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_OwnerId",
                table: "Offers",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.DropTable(
                name: "EngineTypes");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Makes");
        }
    }
}
