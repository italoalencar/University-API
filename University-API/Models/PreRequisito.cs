using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace University_API.Models
{
    [Keyless]
    [Table("pre_requisitos")]
    public partial class PreRequisito
    {
        [Column("cod_disciplina")]
        [StringLength(10)]
        public string? CodDisciplina { get; set; }
        [Column("cod_pre_requisito")]
        [StringLength(10)]
        public string? CodPreRequisito { get; set; }

        [ForeignKey("CodDisciplina")]
        public virtual Disciplina? CodDisciplinaNavigation { get; set; }
        [ForeignKey("CodPreRequisito")]
        public virtual Disciplina? CodPreRequisitoNavigation { get; set; }
    }
}
