using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace University_API.Models
{
    [Table("notas")]
    public partial class Nota
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("id_matricula")]
        public int? IdMatricula { get; set; }
        [Column("tipo")]
        [StringLength(10)]
        public string? Tipo { get; set; }
        [Column("peso")]
        public float? Peso { get; set; }
        [Column("nota")]
        public float? Valor { get; set; }
    }
}
