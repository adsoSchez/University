using System;
using System.Collections.Generic;

namespace Universi.Models;

public partial class Curso
{
    public int CursoId { get; set; }

    public string Nombre { get; set; } = null!;

    public int Creditos { get; set; }

    public string? Profesor { get; set; }

    public virtual ICollection<Inscripcione> Inscripciones { get; set; } = new List<Inscripcione>();
}
