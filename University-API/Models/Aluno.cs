using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace University_API.Models
{
    [Table("alunos")]
    public partial class Aluno
    {
        public Aluno()
        {
            Matriculas = new HashSet<Matricula>();
        }

        [Key]
        [Column("matricula")]
        [StringLength(6)]
        public string Matricula { get; set; } = null!;
        [Column("nome_completo")]
        [StringLength(155)]
        public string NomeCompleto { get; set; } = null!;
        [Column("cpf")]
        [StringLength(11)]
        public string Cpf { get; set; } = null!;
        [Column("id_curso")]
        public int? IdCurso { get; set; }
        [Column("data_nasc")]
        public DateOnly? DataNasc { get; set; }
        [Column("telefone")]
        [StringLength(13)]
        public string? Telefone { get; set; }
        [Column("email")]
        [StringLength(100)]
        public string? Email { get; set; }
        [Column("ano_ingresso")]
        public int? AnoIngresso { get; set; }

        [ForeignKey("IdCurso")]
        [InverseProperty("Alunos")]
        public virtual Curso? IdCursoNavigation { get; set; }
        [InverseProperty("MatriculaAlunoNavigation")]
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
