using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSCI511_Project_4.Migrations
{
    public partial class StartingOut3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examines_Dogs_DogDid",
                table: "Examines");

            migrationBuilder.DropForeignKey(
                name: "FK_Examines_Veterinarians_VeterinarianVid",
                table: "Examines");

            migrationBuilder.DropIndex(
                name: "IX_Examines_DogDid",
                table: "Examines");

            migrationBuilder.DropIndex(
                name: "IX_Examines_VeterinarianVid",
                table: "Examines");

            migrationBuilder.DropColumn(
                name: "DogDid",
                table: "Examines");

            migrationBuilder.DropColumn(
                name: "VeterinarianVid",
                table: "Examines");

            migrationBuilder.CreateIndex(
                name: "IX_Examines_Did",
                table: "Examines",
                column: "Did");

            migrationBuilder.AddForeignKey(
                name: "FK_Examines_Dogs_Did",
                table: "Examines",
                column: "Did",
                principalTable: "Dogs",
                principalColumn: "Did",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Examines_Veterinarians_Vid",
                table: "Examines",
                column: "Vid",
                principalTable: "Veterinarians",
                principalColumn: "Vid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examines_Dogs_Did",
                table: "Examines");

            migrationBuilder.DropForeignKey(
                name: "FK_Examines_Veterinarians_Vid",
                table: "Examines");

            migrationBuilder.DropIndex(
                name: "IX_Examines_Did",
                table: "Examines");

            migrationBuilder.AddColumn<int>(
                name: "DogDid",
                table: "Examines",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VeterinarianVid",
                table: "Examines",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Examines_DogDid",
                table: "Examines",
                column: "DogDid");

            migrationBuilder.CreateIndex(
                name: "IX_Examines_VeterinarianVid",
                table: "Examines",
                column: "VeterinarianVid");

            migrationBuilder.AddForeignKey(
                name: "FK_Examines_Dogs_DogDid",
                table: "Examines",
                column: "DogDid",
                principalTable: "Dogs",
                principalColumn: "Did",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Examines_Veterinarians_VeterinarianVid",
                table: "Examines",
                column: "VeterinarianVid",
                principalTable: "Veterinarians",
                principalColumn: "Vid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
