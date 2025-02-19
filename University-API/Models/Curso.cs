using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace University_API.Models
{
    [Table("cursos")]
    public partial class Curso
    {
        public Curso()
        {
            Alunos = new HashSet<Aluno>();
            Turmas = new HashSet<Turma>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("nome")]
        [StringLength(20)]
        public string? Nome { get; set; }
        [Column("carga_horaria")]
        public int? CargaHoraria { get; set; }
        [Column("unidade_academica")]
        [StringLength(20)]
        public string? UnidadeAcademica { get; set; }
        [Column("campus")]
        [StringLength(20)]
        public string? Campus { get; set; }

        [InverseProperty("IdCursoNavigation")]
        public virtual ICollection<Aluno> Alunos { get; set; }
        [InverseProperty("IdCursoNavigation")]
        public virtual ICollection<Turma> Turmas { get; set; }
    }
}
