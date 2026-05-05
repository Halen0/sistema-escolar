using System;
using System.Collections.Generic;

namespace SistemaEscolar.Models;

public partial class Estudiante
{
    public int Id { get; set; }

    public string Matricula { get; set; } = null!;

    public int? IdUsuarios { get; set; }

    public virtual ICollection<Calificacione> Calificaciones { get; set; } = new List<Calificacione>();

    public virtual Usuario? Usuarios { get; set; }
}
