using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace University_API.Models
{
    [Keyless]
    [Table("horario_turma")]
    public partial class HorarioTurma
    {
        [Column("id_turma")]
        public int? IdTurma { get; set; }
        [Column("dia_semana")]
        [StringLength(15)]
        public string? DiaSemana { get; set; }
        [Column("inicio")]
        public TimeOnly? Inicio { get; set; }
        [Column("termino")]
        public TimeOnly? Termino { get; set; }

        [ForeignKey("IdTurma")]
        public virtual Turma? IdTurmaNavigation { get; set; }
    }
}
