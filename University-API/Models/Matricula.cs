using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace University_API.Models
{
    [Table("matriculas")]
    public partial class Matricula
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("matricula_aluno")]
        [StringLength(6)]
        public string? MatriculaAluno { get; set; }
        [Column("id_turma")]
        public int? IdTurma { get; set; }
        [Column("data_matricula")]
        public DateTime? DataMatricula { get; set; }

        [ForeignKey("IdTurma")]
        [InverseProperty("Matriculas")]
        public virtual Turma? IdTurmaNavigation { get; set; }
        [ForeignKey("MatriculaAluno")]
        [InverseProperty("Matriculas")]
        public virtual Aluno? MatriculaAlunoNavigation { get; set; }
    }
}
