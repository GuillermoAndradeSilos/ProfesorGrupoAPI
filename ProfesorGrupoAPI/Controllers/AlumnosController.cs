using Microsoft.AspNetCore.Mvc;
using ProfesorGrupoAPI.Models;
using ProfesorGrupoAPI.Repositories;

namespace ProfesorGrupoAPI.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        private readonly Sistem21PrimariaContext context;
        private readonly Repository<Alumno> repository;

        public AlumnosController(Sistem21PrimariaContext cx)
        {
            this.context = cx;
            repository = new Repository<Alumno>(context);
        }
        [HttpGet]
        public IActionResult Get()
        {
            var alumno = repository.GetAll().ToList();
            return Ok(alumno);
        }
        [HttpGet("{id}:int")]
        public IActionResult GetAlumno(int id)
        {
            var alumno = repository.GetById(id);
            return Ok(alumno);
        }
        [HttpPost]
        public IActionResult Post(Alumno a)
        {
            if (string.IsNullOrWhiteSpace(a.Nombre))
                return BadRequest("Favor de escribir el nombre del alumno");
            if (string.IsNullOrWhiteSpace(a.Direccion))
                return BadRequest("Favor de escribir la dirección del alumno");
            if (string.IsNullOrWhiteSpace(a.Curp))
                return BadRequest("Favor de escribir la curp del alumno");
            if (string.IsNullOrWhiteSpace(a.Matricula))
                return BadRequest("Favor de escribir la matrícula del alumno");
            if (a.Peso <= 0 || string.IsNullOrWhiteSpace(a.Peso.ToString()))
                return BadRequest("Favor de escribir el peso del alumno");
            if (a.Estatura <= 0 || string.IsNullOrWhiteSpace(a.Estatura.ToString()))
                return BadRequest("Favor de escribir la estatura del alumno");
            if (a.Edad <= 0 || string.IsNullOrWhiteSpace(a.Edad.ToString()))
                return BadRequest("Favor de escribir la edad del alumno");
            //DateTime aja = a.FechaNacimiento.ToDateTime(TimeOnly.MinValue);
            //TimeSpan edadresultante = DateTime.Now - aja;
            //int anios = (int)(edadresultante.TotalDays / 365.25);
            //if(anios < a.Edad)
            //    return BadRequest("La fecha de nacimiento no concuerda con la edad del alumno");
            a.Id = 0;
            repository.Insert(a);
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(Alumno a)
        {
            var alumno = repository.GetById(a.Id);
            if (alumno == null)
                return NotFound();
            if (string.IsNullOrWhiteSpace(a.Direccion))
                return BadRequest("Favor de escribir la dirección del alumno");
            if (a.Peso <= 0 || string.IsNullOrWhiteSpace(a.Peso.ToString()))
                return BadRequest("Favor de escribir el peso del alumno");
            if (a.Estatura <= 0 || string.IsNullOrWhiteSpace(a.Estatura.ToString()))
                return BadRequest("Favor de escribir la estatura del alumno");
            if (a.Edad <= 0 || string.IsNullOrWhiteSpace(a.Edad.ToString()))
                return BadRequest("Favor de escribir la edad del alumno");
            alumno.Direccion = a.Direccion;
            alumno.Peso = a.Peso;
            alumno.Estatura = a.Estatura;
            alumno.Edad = a.Edad;

            repository.Update(alumno);
            return Ok();
        }
    }
}