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
    public class EditorialesController : ApiController
    {
        private IMapper mapper;
        private readonly EditorialService editorialService = new EditorialService(new EditorialRepository(LibrosContext.Create()));

        public EditorialesController() 
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var editoriales = await editorialService.GetAll();
            var editorialesDTO = editoriales.Select(x => mapper.Map<EditorialDTO>(x));

            return Ok(editorialesDTO);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(string id)
        {
            var editorial = await editorialService.GetById(id);
            if (editorial == null)
                return NotFound();

            var editorialDTO = mapper.Map<EditorialDTO>(editorial);

            return Ok(editorialDTO);
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostEditorial(EditorialDTO editorialDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var editorial = mapper.Map<Editorial>(editorialDTO);
                editorial = await editorialService.Insert(editorial);
                return Ok(editorial);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> PutAutor(EditorialDTO editorialDTO, string id)
        {
            //Validacion del estado del modelo
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //validacion de coherencia de id
            if (id == null || editorialDTO.id_editorial != id)
                return BadRequest();

            var flag = await editorialService.GetById(id);

            //verificacion de existencia
            if (flag == null)
                return NotFound();

            try
            {
                //validar y conversion
                var editorial = mapper.Map<Editorial>(editorialDTO);
                editorial = await editorialService.Update(editorial);
                return Ok(editorial);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeletAutor(string id)
        {
            var flag = await editorialService.GetById(id);

            //verificacion de existencia
            if (flag == null)
                return NotFound();

            try
            {
                if (await editorialService.DeleteCheckOnEntity(id))
                    await editorialService.Delete(id);
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