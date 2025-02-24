using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace University_API.Models
{
    [Table("horario_turma")]
    public partial class HorarioTurma
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
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
