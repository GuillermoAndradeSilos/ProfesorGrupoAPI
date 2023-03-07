using System;
using System.Collections.Generic;

namespace ProfesorGrupoAPI.Models;

public partial class TipoAsignatura
{
    public int Id { get; set; }

    public string TipoAsignatura1 { get; set; } = null!;

    public virtual ICollection<Asignatura> Asignatura { get; } = new List<Asignatura>();
}
