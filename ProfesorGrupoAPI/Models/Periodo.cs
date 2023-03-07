using System;
using System.Collections.Generic;

namespace ProfesorGrupoAPI.Models;

public partial class Periodo
{
    public int Id { get; set; }

    public short Año { get; set; }

    public virtual ICollection<Calificacion> Calificacion { get; } = new List<Calificacion>();

    public virtual ICollection<DocenteAlumno> DocenteAlumno { get; } = new List<DocenteAlumno>();

    public virtual ICollection<DocenteGrupo> DocenteGrupo { get; } = new List<DocenteGrupo>();
}
