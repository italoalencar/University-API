using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace University_API.Models
{
    [Table("disciplinas")]
    public partial class Disciplina
    {
        public Disciplina()
        {
            Turmas = new HashSet<Turma>();
        }

        [Key]
        [Column("cod")]
        [StringLength(10)]
        public string Cod { get; set; } = null!;
        [Column("nome")]
        [StringLength(50)]
        public string Nome { get; set; } = null!;
        [Column("carga_horaria")]
        public int? CargaHoraria { get; set; }
        [Column("ementa")]
        [StringLength(255)]
        public string? Ementa { get; set; }

        [InverseProperty("CodDisciplinaNavigation")]
        public virtual ICollection<Turma> Turmas { get; set; }
    }
}
