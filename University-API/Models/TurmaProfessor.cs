using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace University_API.Models
{
    [Keyless]
    [Table("turma_professor")]
    public partial class TurmaProfessor
    {
        [Column("id_turma")]
        public int? IdTurma { get; set; }
        [Column("matricula_prof")]
        [StringLength(6)]
        public string? MatriculaProf { get; set; }

        [ForeignKey("IdTurma")]
        public virtual Turma? IdTurmaNavigation { get; set; }
        [ForeignKey("MatriculaProf")]
        public virtual Professor? MatriculaProfNavigation { get; set; }
    }
}
