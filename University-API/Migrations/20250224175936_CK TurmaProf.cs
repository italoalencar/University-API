using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University_API.Migrations
{
    public partial class CKTurmaProf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "turma_professor_id_turma_fkey",
                table: "turma_professor");

            migrationBuilder.DropForeignKey(
                name: "turma_professor_matricula_prof_fkey",
                table: "turma_professor");

            migrationBuilder.DropIndex(
                name: "IX_turma_professor_id_turma",
                table: "turma_professor");

            migrationBuilder.AlterColumn<string>(
                name: "matricula_prof",
                table: "turma_professor",
                type: "character varying(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(6)",
                oldMaxLength: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id_turma",
                table: "turma_professor",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_turma_professor",
                table: "turma_professor",
                columns: new[] { "id_turma", "matricula_prof" });

            migrationBuilder.AddForeignKey(
                name: "turma_professor_id_turma_fkey",
                table: "turma_professor",
                column: "id_turma",
                principalTable: "turmas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "turma_professor_matricula_prof_fkey",
                table: "turma_professor",
                column: "matricula_prof",
                principalTable: "professores",
                principalColumn: "matricula",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "turma_professor_id_turma_fkey",
                table: "turma_professor");

            migrationBuilder.DropForeignKey(
                name: "turma_professor_matricula_prof_fkey",
                table: "turma_professor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_turma_professor",
                table: "turma_professor");

            migrationBuilder.AlterColumn<string>(
                name: "matricula_prof",
                table: "turma_professor",
                type: "character varying(6)",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(6)",
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<int>(
                name: "id_turma",
                table: "turma_professor",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_turma_professor_id_turma",
                table: "turma_professor",
                column: "id_turma");

            migrationBuilder.AddForeignKey(
                name: "turma_professor_id_turma_fkey",
                table: "turma_professor",
                column: "id_turma",
                principalTable: "turmas",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "turma_professor_matricula_prof_fkey",
                table: "turma_professor",
                column: "matricula_prof",
                principalTable: "professores",
                principalColumn: "matricula");
        }
    }
}
