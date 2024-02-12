using API_Libros_BL.Data;
using API_Libros_BL.DTO;
using API_Libros_BL.Models;
using API_Libros_BL.Repositories.Implements;
using API_Libros_BL.Services;
using API_Libros_BL.Services.Implements;
using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace API_Libros.Controllers
{
    
    public class LibrosController : ApiController
    {
        private IMapper mapper;
        private readonly LibroService libroService = new LibroService(new LibroRepository(LibrosContext.Create()));

        public LibrosController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var libros = await libroService.GetAll();
            var LibroDTO = libros.Select(x => mapper.Map<LibroDTO>(x));

            return Ok(LibroDTO);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(string id)
        {
            var libro = await libroService.GetById(id);
            if (libro == null)
                return NotFound();

            var libroDTO = mapper.Map<LibroDTO>(libro);

            return Ok(libroDTO);
        }   

        [HttpPost]
        public async Task<IHttpActionResult> PostAutor(LibroDTO libroDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var libro = mapper.Map<Libro>(libroDTO);
                libro = await libroService.Insert(libro);
                return Ok(libro);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> PutAutor(LibroDTO libroDTO, string id)
        {
            //Validacion del estado del modelo
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //validacion de coherencia de id
            if (id == null || libroDTO.id_libro != id)
                return BadRequest();

            var flag = await libroService.GetById(id);

            //verificacion de existencia
            if (flag == null)
                return NotFound();

            try
            {
                //validar y conversion
                var libro = mapper.Map<Libro>(libroDTO);
                libro = await libroService.Update(libro);
                return Ok(libro);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeletAutor(string id)
        {
            var flag = await libroService.GetById(id);

            //verificacion de existencia
            if (flag == null)
                return NotFound();

            try
            {
                if (await libroService.DeleteCheckOnEntity(id))
                    await libroService.Delete(id);
                else
                    throw new Exception("Existen llaves foraneas");
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}