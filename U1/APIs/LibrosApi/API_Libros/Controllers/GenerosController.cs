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
    public class GenerosController : ApiController
    {
        private IMapper mapper;
        private readonly GeneroService generoService = new GeneroService(new GeneroRepository(LibrosContext.Create()));

        public GenerosController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var generos = await generoService.GetAll();
            var generosDTO = generos.Select(x => mapper.Map<GeneroDTO>(x));

            return Ok(generosDTO);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(string id)
        {
            var genero = await generoService.GetById(id);
            if (genero == null)
                return NotFound();

            var generoDTO = mapper.Map<GeneroDTO>(genero);

            return Ok(generoDTO);
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostGenero(GeneroDTO generoDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var genero = mapper.Map<Genero>(generoDTO);
                genero = await generoService.Insert(genero);
                return Ok(genero);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> PutAutor(GeneroDTO generoDTO, string id)
        {
            //Validacion del estado del modelo
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //validacion de coherencia de id
            if (id == null || generoDTO.id_genero != id)
                return BadRequest();

            var flag = await generoService.GetById(id);

            //verificacion de existencia
            if (flag == null)
                return NotFound();

            try
            {
                //validar y conversion
                var genero = mapper.Map<Genero>(generoDTO);
                genero = await generoService.Update(genero);
                return Ok(genero);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeletAutor(string id)
        {
            var flag = await generoService.GetById(id);

            //verificacion de existencia
            if (flag == null)
                return NotFound();

            try
            {
                if (await generoService.DeleteCheckOnEntity(id))
                    await generoService.Delete(id);
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