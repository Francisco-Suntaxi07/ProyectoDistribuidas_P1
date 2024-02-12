using Microsoft.AspNetCore.Mvc;
using PrestamoApi.DAO;
using PrestamoApi.Model;

namespace PrestamoApi.Controllers
{
    [ApiController]
    [Route("api/loan")]
    public class LoanController:ControllerBase
    {
        [HttpGet("all")]
        public async Task<ActionResult<List<LoanModel>>> findAllLoans()
        { 
            var loanDao = new LoanDao();
            var list = await loanDao.findAllLoans();

            if(list == null || list.Count == 0)
            {
                return NoContent();
            }
            return Ok(list);
        }

        [HttpGet("find/{id}")]
        public async Task<ActionResult<LoanModel>> findLoanById(string id)
        {
            var loanDao = new LoanDao();
            var loan = await loanDao.findLoanById(id);
            if (loan.id_prestamo == null)
            {
                return NotFound(new { message = $"No se encontró el préstamo con el ID: {id}." } );
            }

            return Ok(loan);
        }

        [HttpPost("save")]
        public async Task<ActionResult<LoanModel>> saveLoan([FromBody] LoanModel loanModel)
        {
            try
            {
                // Verificar si el objeto del body tiene todos los datos
                if (loanModel == null || loanModel.id_prestamo == null || loanModel.id_prestamo == "" || (loanModel.id_cliente == null && loanModel.id_libro == null))
                {
                    return BadRequest(new { message = "La solicitud no contiene datos válidos" });
                }

                var loanDao = new LoanDao();

                // Verificar si el objeto existe antes del  guardado
                var existingLoan = await loanDao.findLoanById(loanModel.id_prestamo);
                if (existingLoan.id_prestamo != null)
                {
                    return BadRequest(new { message = $"El préstamo con el ID: {loanModel.id_prestamo} ya existe." });
                }

                await loanDao.saveLoan(loanModel);

                return Ok(loanModel);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = "Revise bien el  ingreso de los datos. Internal Server Error." });
            }
            
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> updateLoanById(string id, [FromBody] LoanModel loanModel)
        {
            var loanDao = new LoanDao();

            try 
            {
                // Verificar si el objeto existe antes de modificar
                var existingLoan = await loanDao.findLoanById(id);
                if (existingLoan.id_prestamo == null || loanModel.id_prestamo != id)
                {
                    return NotFound(new { message = $"No se encontró el préstamo con el ID: {id}. Revisa tus datos." });
                }

                await loanDao.updateLoanById(loanModel);
                return Ok(new { message = $"El prestamo de ID: {loanModel.id_prestamo} fue actualizado correctamente."});
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = "Revise bien el  ingreso de los datos." });
            }   
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> deleteLoanById(string id)
        {
            var loanDao = new LoanDao();

            // Verificar si el objeto existe antes de la eliminación
            var existingLoan = await loanDao.findLoanById(id);
            if (existingLoan.id_prestamo == null)
            {
                return NotFound(new { message = $"No se encontró el préstamo con el ID: {id} proporcionado para su eliminación." });
            }

            await loanDao.deleteLoanById(id);

            return Ok(new { message =  $"El préstamo con ID {id} fue eliminado correctamente." });
        }
    }
}
