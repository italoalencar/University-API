using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace University_API.Models
{
    [Table("turmas")]
    public partial class Turma
    {
        public Turma()
        {
            Matriculas = new HashSet<Matricula>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("cod_disciplina")]
        [StringLength(10)]
        public string? CodDisciplina { get; set; }
        [Column("id_curso")]
        public int? IdCurso { get; set; }
        [Column("semestre")]
        [StringLength(6)]
        public string Semestre { get; set; } = null!;
        [Column("max_alunos")]
        public int? MaxAlunos { get; set; }
        [Column("qtde_alunos")]
        public int? QtdeAlunos { get; set; }

        [ForeignKey("CodDisciplina")]
        [InverseProperty("Turmas")]
        public virtual Disciplina? CodDisciplinaNavigation { get; set; }
        [ForeignKey("IdCurso")]
        [InverseProperty("Turmas")]
        public virtual Curso? IdCursoNavigation { get; set; }
        [InverseProperty("IdTurmaNavigation")]
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
