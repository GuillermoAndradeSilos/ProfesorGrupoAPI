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
        public IActionResult Get()
        {
            var alumno = repository.GetAll();
            return Ok(alumno);
        }
        [HttpPost]
        public IActionResult Post(Alumno a)
        {
            if (string.IsNullOrWhiteSpace(a.Nombre))
                return BadRequest("Favor de escribir el nombre del alumno");
            if (string.IsNullOrWhiteSpace(a.Direccion))
                return BadRequest("Favor de escribir la dirección del alumno");
            a.Id = 0;
            repository.Insert(a);
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(Alumno a)
        {
            if (string.IsNullOrWhiteSpace(a.Nombre))
                return BadRequest("Favor de escribir el nombre del alumno");
            if (string.IsNullOrWhiteSpace(a.Direccion))
                return BadRequest("Favor de escribir la dirección del alumno");
            
            //repository.Insert(a);
            return Ok();
        }
    }
}