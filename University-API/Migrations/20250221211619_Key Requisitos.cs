using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace University_API.Migrations
{
    public partial class KeyRequisitos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:situacao_type", "ativo,inativo,formado")
                .Annotation("Npgsql:Enum:status_type", "em andamento,concluida,reprovada,trancada,suprimida");

            migrationBuilder.CreateTable(
                name: "cursos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    carga_horaria = table.Column<int>(type: "integer", nullable: true),
                    unidade_academica = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    campus = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cursos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "disciplinas",
                columns: table => new
                {
                    cod = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    carga_horaria = table.Column<int>(type: "integer", nullable: true),
                    ementa = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("disciplinas_pkey", x => x.cod);
                });

            migrationBuilder.CreateTable(
                name: "notas",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_matricula = table.Column<int>(type: "integer", nullable: true),
                    tipo = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    peso = table.Column<float>(type: "real", nullable: true),
                    nota = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "professores",
                columns: table => new
                {
                    matricula = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    nome_completo = table.Column<string>(type: "character varying(155)", maxLength: 155, nullable: false),
                    cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    area_atuacao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    data_nasc = table.Column<DateOnly>(type: "date", nullable: true),
                    telefone = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: true),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("professores_pkey", x => x.matricula);
                });

            migrationBuilder.CreateTable(
                name: "alunos",
                columns: table => new
                {
                    matricula = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    nome_completo = table.Column<string>(type: "character varying(155)", maxLength: 155, nullable: false),
                    cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    id_curso = table.Column<int>(type: "integer", nullable: true),
                    data_nasc = table.Column<DateOnly>(type: "date", nullable: true),
                    telefone = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: true),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ano_ingresso = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("alunos_pkey", x => x.matricula);
                    table.ForeignKey(
                        name: "alunos_id_curso_fkey",
                        column: x => x.id_curso,
                        principalTable: "cursos",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "pre_requisitos",
                columns: table => new
                {
                    cod_disciplina = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    cod_pre_requisito = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pre_requisitos", x => new { x.cod_disciplina, x.cod_pre_requisito });
                    table.ForeignKey(
                        name: "pre_requisitos_cod_disciplina_fkey",
                        column: x => x.cod_disciplina,
                        principalTable: "disciplinas",
                        principalColumn: "cod",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "pre_requisitos_cod_pre_requisito_fkey",
                        column: x => x.cod_pre_requisito,
                        principalTable: "disciplinas",
                        principalColumn: "cod",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "turmas",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cod_disciplina = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    id_curso = table.Column<int>(type: "integer", nullable: true),
                    semestre = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    max_alunos = table.Column<int>(type: "integer", nullable: true),
                    qtde_alunos = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_turmas", x => x.id);
                    table.ForeignKey(
                        name: "turmas_cod_disciplina_fkey",
                        column: x => x.cod_disciplina,
                        principalTable: "disciplinas",
                        principalColumn: "cod");
                    table.ForeignKey(
                        name: "turmas_id_curso_fkey",
                        column: x => x.id_curso,
                        principalTable: "cursos",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "horario_turma",
                columns: table => new
                {
                    id_turma = table.Column<int>(type: "integer", nullable: true),
                    dia_semana = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    inicio = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    termino = table.Column<TimeOnly>(type: "time without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "horario_turma_id_turma_fkey",
                        column: x => x.id_turma,
                        principalTable: "turmas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "matriculas",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    matricula_aluno = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    id_turma = table.Column<int>(type: "integer", nullable: true),
                    data_matricula = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matriculas", x => x.id);
                    table.ForeignKey(
                        name: "matriculas_id_turma_fkey",
                        column: x => x.id_turma,
                        principalTable: "turmas",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "matriculas_matricula_aluno_fkey",
                        column: x => x.matricula_aluno,
                        principalTable: "alunos",
                        principalColumn: "matricula");
                });

            migrationBuilder.CreateTable(
                name: "turma_professor",
                columns: table => new
                {
                    id_turma = table.Column<int>(type: "integer", nullable: true),
                    matricula_prof = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "turma_professor_id_turma_fkey",
                        column: x => x.id_turma,
                        principalTable: "turmas",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "turma_professor_matricula_prof_fkey",
                        column: x => x.matricula_prof,
                        principalTable: "professores",
                        principalColumn: "matricula");
                });

            migrationBuilder.CreateIndex(
                name: "IX_alunos_id_curso",
                table: "alunos",
                column: "id_curso");

            migrationBuilder.CreateIndex(
                name: "IX_horario_turma_id_turma",
                table: "horario_turma",
                column: "id_turma");

            migrationBuilder.CreateIndex(
                name: "IX_matriculas_id_turma",
                table: "matriculas",
                column: "id_turma");

            migrationBuilder.CreateIndex(
                name: "IX_matriculas_matricula_aluno",
                table: "matriculas",
                column: "matricula_aluno");

            migrationBuilder.CreateIndex(
                name: "IX_pre_requisitos_cod_pre_requisito",
                table: "pre_requisitos",
                column: "cod_pre_requisito");

            migrationBuilder.CreateIndex(
                name: "IX_turma_professor_id_turma",
                table: "turma_professor",
                column: "id_turma");

            migrationBuilder.CreateIndex(
                name: "IX_turma_professor_matricula_prof",
                table: "turma_professor",
                column: "matricula_prof");

            migrationBuilder.CreateIndex(
                name: "IX_turmas_cod_disciplina",
                table: "turmas",
                column: "cod_disciplina");

            migrationBuilder.CreateIndex(
                name: "IX_turmas_id_curso",
                table: "turmas",
                column: "id_curso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "horario_turma");

            migrationBuilder.DropTable(
                name: "matriculas");

            migrationBuilder.DropTable(
                name: "notas");

            migrationBuilder.DropTable(
                name: "pre_requisitos");

            migrationBuilder.DropTable(
                name: "turma_professor");

            migrationBuilder.DropTable(
                name: "alunos");

            migrationBuilder.DropTable(
                name: "turmas");

            migrationBuilder.DropTable(
                name: "professores");

            migrationBuilder.DropTable(
                name: "disciplinas");

            migrationBuilder.DropTable(
                name: "cursos");
        }
    }
}
