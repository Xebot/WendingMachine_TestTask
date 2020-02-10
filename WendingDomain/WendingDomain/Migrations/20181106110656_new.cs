using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WendingDomain.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountCoins = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WendingMachine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Balance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WendingMachine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<int>(nullable: false),
                    isAvailable = table.Column<bool>(nullable: false),
                    StorageId = table.Column<int>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coins_Storage_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    isAvailable = table.Column<bool>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    WendingMachineId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drinks_WendingMachine_WendingMachineId",
                        column: x => x.WendingMachineId,
                        principalTable: "WendingMachine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coins_StorageId",
                table: "Coins",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Drinks_WendingMachineId",
                table: "Drinks",
                column: "WendingMachineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coins");

            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "Storage");

            migrationBuilder.DropTable(
                name: "WendingMachine");
        }
    }
}
