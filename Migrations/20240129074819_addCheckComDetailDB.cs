using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckComDetail.Migrations
{
    /// <inheritdoc />
    public partial class addCheckComDetailDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComputerInfos",
                columns: table => new
                {
                    ComputerID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComputerModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserBuilding = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserFloor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserZone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerInfos", x => x.ComputerID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComputerInfos");
        }
    }
}
