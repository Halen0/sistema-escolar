using System;
using System.Collections.Generic;

namespace SistemaEscolar.Models;

public partial class Calificacione
{
    public int Id { get; set; }

    public int? IdMateria { get; set; }

    public int? IdEstudiante { get; set; }

    public int Calificacion { get; set; }

    public virtual Estudiante? Estudiantes { get; set; }

    public virtual Materia? Materias { get; set; }
}
