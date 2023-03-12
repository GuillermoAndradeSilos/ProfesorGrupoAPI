using Microsoft.AspNetCore.Mvc;
using ProfesorGrupoAPI.Models;
using ProfesorGrupoAPI.Repositories;

namespace ProfesorGrupoAPI.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class TutoresController : ControllerBase
    {
        private readonly Sistem21PrimariaContext context;
        private readonly Repository<Alumno> repositoryalumno;
        private readonly Repository<Tutor> repositorytutor;

        public TutoresController(Sistem21PrimariaContext cx)
        {
            this.context = cx;
            repositoryalumno = new Repository<Alumno>(context);
            repositorytutor = new Repository<Tutor>(context);
        }
        //[HttpGet]
        public IActionResult Get()
        {
            var tutores = repositorytutor.GetAll();
            return Ok(tutores);
        }
        //[HttpGet("{id}:int")]
        //public IActionResult GetTutor(int id)
        //{
        //    var tutores = repositorytutor.GetAll();
        //    return Ok(tutores);
        //}
        [HttpPost]
        public IActionResult Post(Tutor t)
        {
            if (string.IsNullOrWhiteSpace(t.Nombre))
                return BadRequest("Favor de escribir el nombre del tutor.");
            if (string.IsNullOrWhiteSpace(t.Direccion))
                return BadRequest("Favor de escribir la dirección del tutor.");
            if (string.IsNullOrWhiteSpace(t.Telefono.ToString()))
                return BadRequest("Favor de escribir el teléfono del tutor.");

            t.Id = 0;
            repositorytutor.Insert(t);
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(Tutor t)
        {
            var tutor = repositorytutor.GetById(t.Id);
            if (tutor == null)
                return NotFound();
            if (string.IsNullOrWhiteSpace(t.Direccion))
                return BadRequest("Favor de escribir la dirección del tutor.");
            if (string.IsNullOrWhiteSpace(t.Telefono.ToString()))
                return BadRequest("Favor de escribir el teléfono del tutor.");
            tutor.Direccion = t.Direccion;
            tutor.Telefono = t.Telefono;

            repositorytutor.Update(tutor);
            return Ok();
        }
    }
}
