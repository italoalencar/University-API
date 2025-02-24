using Microsoft.EntityFrameworkCore;
using University_API.Models;

namespace University_API.Data
{
    public partial class UniversityContext : DbContext
    {
        public UniversityContext()
        {
        }

        public UniversityContext(DbContextOptions<UniversityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aluno> Alunos { get; set; } = null!;
        public virtual DbSet<Curso> Cursos { get; set; } = null!;
        public virtual DbSet<Disciplina> Disciplinas { get; set; } = null!;
        public virtual DbSet<HorarioTurma> HorarioTurmas { get; set; } = null!;
        public virtual DbSet<Matricula> Matriculas { get; set; } = null!;
        public virtual DbSet<Nota> Notas { get; set; } = null!;
        public virtual DbSet<PreRequisito> PreRequisitos { get; set; } = null!;
        public virtual DbSet<Professor> Professores { get; set; } = null!;
        public virtual DbSet<Turma> Turmas { get; set; } = null!;
        public virtual DbSet<TurmaProfessor> TurmaProfessores { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum("situacao_type", new[] { "ativo", "inativo", "formado" })
                .HasPostgresEnum("status_type", new[] { "em andamento", "concluida", "reprovada", "trancada", "suprimida" });

            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.HasKey(e => e.Matricula)
                    .HasName("alunos_pkey");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Alunos)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("alunos_id_curso_fkey");
            });

            modelBuilder.Entity<Disciplina>(entity =>
            {
                entity.HasKey(e => e.Cod)
                    .HasName("disciplinas_pkey");
            });

            modelBuilder.Entity<HorarioTurma>(entity =>
            {
                entity.HasOne(d => d.IdTurmaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdTurma)
                    .HasConstraintName("horario_turma_id_turma_fkey");
            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.HasOne(d => d.IdTurmaNavigation)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.IdTurma)
                    .HasConstraintName("matriculas_id_turma_fkey");

                entity.HasOne(d => d.MatriculaAlunoNavigation)
                    .WithMany(p => p.Matriculas)
                    .HasForeignKey(d => d.MatriculaAluno)
                    .HasConstraintName("matriculas_matricula_aluno_fkey");
            });

            modelBuilder.Entity<PreRequisito>(entity =>
            {
                entity.HasOne(d => d.CodDisciplinaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CodDisciplina)
                    .HasConstraintName("pre_requisitos_cod_disciplina_fkey");

                entity.HasOne(d => d.CodPreRequisitoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CodPreRequisito)
                    .HasConstraintName("pre_requisitos_cod_pre_requisito_fkey");

                entity.HasKey(p => new { p.CodDisciplina, p.CodPreRequisito });
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.HasKey(e => e.Matricula)
                    .HasName("professores_pkey");
            });

            modelBuilder.Entity<Turma>(entity =>
            {
                entity.HasOne(d => d.CodDisciplinaNavigation)
                    .WithMany(p => p.Turmas)
                    .HasForeignKey(d => d.CodDisciplina)
                    .HasConstraintName("turmas_cod_disciplina_fkey");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Turmas)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("turmas_id_curso_fkey");
            });

            modelBuilder.Entity<TurmaProfessor>(entity =>
            {
                entity.HasOne(d => d.IdTurmaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdTurma)
                    .HasConstraintName("turma_professor_id_turma_fkey");

                entity.HasOne(d => d.MatriculaProfNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MatriculaProf)
                    .HasConstraintName("turma_professor_matricula_prof_fkey");

                entity.HasKey(tp => new { tp.IdTurma, tp.MatriculaProf });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
