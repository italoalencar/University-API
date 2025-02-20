using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace University_API.DTOs;

public record CreateCursoDTO(string Nome, int CargaHoraria, string UnidadeAcademica, string Campus);
