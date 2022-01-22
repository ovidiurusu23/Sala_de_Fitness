using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sala_de_Fitness.Migrations
{
    public partial class Clienti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(nullable: true),
                    Prenume = table.Column<string>(nullable: true),
                    DataNasterii = table.Column<DateTime>(nullable: false),
                    SalaID = table.Column<int>(nullable: false),
                    InstructorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Client_Instructor_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Instructor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Client_Sala_SalaID",
                        column: x => x.SalaID,
                        principalTable: "Sala",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_InstructorID",
                table: "Client",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_Client_SalaID",
                table: "Client",
                column: "SalaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
