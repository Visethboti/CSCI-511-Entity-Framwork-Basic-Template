using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSCI511_Project_4.Migrations
{
    public partial class StartingOut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    Did = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DogName = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.Did);
                });

            migrationBuilder.CreateTable(
                name: "Veterinarians",
                columns: table => new
                {
                    Vid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinarians", x => x.Vid);
                });

            migrationBuilder.CreateTable(
                name: "Examines",
                columns: table => new
                {
                    Vid = table.Column<int>(type: "INTEGER", nullable: false),
                    Did = table.Column<int>(type: "INTEGER", nullable: false),
                    Fee = table.Column<int>(type: "INTEGER", nullable: false),
                    VeterinarianVid = table.Column<int>(type: "INTEGER", nullable: false),
                    DogDid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examines", x => new { x.Vid, x.Did });
                    table.ForeignKey(
                        name: "FK_Examines_Dogs_DogDid",
                        column: x => x.DogDid,
                        principalTable: "Dogs",
                        principalColumn: "Did",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Examines_Veterinarians_VeterinarianVid",
                        column: x => x.VeterinarianVid,
                        principalTable: "Veterinarians",
                        principalColumn: "Vid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Examines_DogDid",
                table: "Examines",
                column: "DogDid");

            migrationBuilder.CreateIndex(
                name: "IX_Examines_VeterinarianVid",
                table: "Examines",
                column: "VeterinarianVid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Examines");

            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "Veterinarians");
        }
    }
}
