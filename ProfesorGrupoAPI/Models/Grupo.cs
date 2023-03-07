using System;
using System.Collections.Generic;

namespace ProfesorGrupoAPI.Models;

public partial class Grupo
{
    public int Id { get; set; }

    public string Grado { get; set; } = null!;

    public string Seccion { get; set; } = null!;

    public virtual ICollection<Alumno> Alumno { get; } = new List<Alumno>();

    public virtual ICollection<DocenteGrupo> DocenteGrupo { get; } = new List<DocenteGrupo>();
}
