using System;
using System.Collections.Generic;

namespace SistemaEscolar.Models;

public partial class Profesore
{
    public int Id { get; set; }

    public int? IdUsuarios { get; set; }

    public virtual Usuario? Usuarios { get; set; }
}
