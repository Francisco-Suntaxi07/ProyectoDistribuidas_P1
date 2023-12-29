using API_Libros_BL.Data;
using API_Libros_BL.DTO;
using API_Libros_BL.Models;
using API_Libros_BL.Repositories.Implements;
using API_Libros_BL.Services.Implements;
using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace API_Libros.Controllers
{
    public class AutoresController : ApiController
    {
        private IMapper mapper;
        private readonly AutorService autorService = new AutorService(new AutorRepository(LibrosContext.Create()));

        public AutoresController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var autores = await autorService.GetAll();
            var autoresDTO = autores.Select(x => mapper.Map<AutorDTO>(x));
            
            return Ok(autoresDTO);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(string id)
        {
            var autor = await autorService.GetById(id);
            if (autor == null)
                return NotFound();
            
            var autorDTO = mapper.Map<AutorDTO>(autor);

            return Ok(autorDTO);
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostAutor(AutorDTO autorDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
             
            try
            {
                var autor = mapper.Map<Autor>(autorDTO);
                autor = await autorService.Insert(autor);
                return Ok(autor);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }            
        }

        [HttpPut]
        public async Task<IHttpActionResult> PutAutor(AutorDTO autorDTO, string id)
        {
            //Validacion del estado del modelo
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //validacion de coherencia de id
            if (id == null || autorDTO.id_autor != id)
                return BadRequest();

            var flag = await autorService.GetById(id);

            //verificacion de existencia
            if (flag == null)
                return NotFound();

            try
            {
                //validar y conversion
                var autor = mapper.Map<Autor>(autorDTO);
                autor = await autorService.Update(autor);
                return Ok(autor);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeletAutor(string id)
        {
            var flag = await autorService.GetById(id);

            //verificacion de existencia
            if (flag == null)
                return NotFound();

            try
            {
                if (await autorService.DeleteCheckOnEntity(id))
                    await autorService.Delete(id);
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
