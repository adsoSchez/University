using System;
using System.Collections.Generic;

namespace Universi.Models;

public partial class Inscripcione
{
    public int InscripcionId { get; set; }

    public int EstudianteId { get; set; }

    public int CursoId { get; set; }

    public DateOnly? FechaInscripcion { get; set; }

    public virtual Curso? Curso { get; set; }
    public virtual Estudiante? Estudiante { get; set; } 
}
