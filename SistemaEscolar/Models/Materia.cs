using System;
using System.Collections.Generic;

namespace SistemaEscolar.Models;

public partial class Materia
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string Materias { get; set; } = null!;

    public int Semestre { get; set; }

    public string? Requisitos { get; set; }

    public virtual ICollection<Calificacione> Calificaciones { get; set; } = new List<Calificacione>();
}
