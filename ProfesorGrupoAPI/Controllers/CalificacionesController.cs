using Microsoft.AspNetCore.Mvc;
using ProfesorGrupoAPI.Models;
using ProfesorGrupoAPI.Repositories;

namespace ProfesorGrupoAPI.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class CalificacionesController : ControllerBase
    {
        private readonly Sistem21PrimariaContext context;
        private readonly Repository<Calificacion> repositorycalificaciones;
        private readonly Repository<Alumno> repositoryalumno;

        public CalificacionesController(Sistem21PrimariaContext cx)
        {
            this.context = cx;
            repositorycalificaciones = new Repository<Calificacion>(context);
            repositoryalumno = new Repository<Alumno>(context);
        }
        public IActionResult Get()
        {
            var calificacion = repositorycalificaciones.GetAll().ToList();
            return Ok(calificacion);
        }
        [HttpPost]
        public IActionResult Post(Calificacion c)
        {
            if (c.Calificacion1 < 6 || string.IsNullOrWhiteSpace(c.Calificacion1.ToString()))
                return BadRequest("No repruebes al chamaco, que te pasa?, nos funan los padres");
            if (c.IdAlumno <= 0 || string.IsNullOrWhiteSpace(c.IdAlumno.ToString()))
                return BadRequest("Favor de seleccionar el alumno a calificar");
            if (c.IdAsignatura <= 0 || string.IsNullOrWhiteSpace(c.IdAsignatura.ToString()))
                return BadRequest("Favor de seleccionar la asignatura a calificar");
            if (c.IdPeriodo <= 0 || string.IsNullOrWhiteSpace(c.IdPeriodo.ToString()))
                return BadRequest("Favor de poner el periodo de la calificación");
            c.Id = 0;
            repositorycalificaciones.Insert(c);
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(Calificacion c)
        {
            var calificacion = repositorycalificaciones.GetById(c.Id);
            if (calificacion == null)
                return NotFound();
            if (c.Calificacion1 < 6 || string.IsNullOrWhiteSpace(c.Calificacion1.ToString()))
                return BadRequest("No repruebes al chamaco, que te pasa?, nos funan los padres");
            calificacion.Calificacion1 = c.Calificacion1;

            repositorycalificaciones.Update(calificacion);
            return Ok();
        }
    }
}
