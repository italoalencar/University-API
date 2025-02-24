using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University_API.Migrations
{
    public partial class PK_HOrarioTurma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "horario_turma",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "horario_turma",
                newName: "Id");
        }
    }
}
