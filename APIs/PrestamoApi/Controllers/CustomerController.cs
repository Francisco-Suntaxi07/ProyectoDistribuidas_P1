using Microsoft.AspNetCore.Mvc;
using PrestamoApi.DAO;
using PrestamoApi.Model;

namespace PrestamoApi.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController:ControllerBase
    {
        [HttpGet("all")]
        public async Task<ActionResult<List<CustomerModel>>> findAllCustomers()
        {
            var customerDao = new CustomerDao();
            var list = await customerDao.findAllCustomers();

            if (list == null || list.Count == 0)
            {
                return NoContent();
            }

            return Ok(list);
        }

        [HttpGet("find/{id}")]
        public async Task<ActionResult<CustomerModel>> findCustomerById(string id)
        {
            var customerDao = new CustomerDao();
            var customer = await customerDao.findCustomerById(id);

            if (customer.id_cliente == null)
            {
                return NotFound(new { message = $"No se encontró el cliente con el ID: {id}." });
            }

            return customer;
        }

        [HttpPost("save")]
        public async Task<ActionResult<LoanModel>> saveLoan([FromBody] CustomerModel customerModel)
        {
            try
            {
                // Verificar si el objeto del body tiene todos los datos
                if (customerModel == null || customerModel.id_cliente == null || customerModel.id_cliente == "" || customerModel.nombre_cliente == null)
                {
                    return BadRequest(new { message = "La solicitud no contiene datos válidos" });
                }

                var customerDao = new CustomerDao();

                // Verificar si el objeto existe antes del  guardado
                var existingCustomer = await customerDao.findCustomerById(customerModel.id_cliente);
                if (existingCustomer.id_cliente != null)
                {
                    return BadRequest(new { message = $"El préstamo con el ID: {customerModel.id_cliente} ya existe." });
                }

                await customerDao.saveCustomer(customerModel);

                return Ok(customerModel);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = "Revise bien el  ingreso de los datos. Internal Server Error." });
            }

        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> updateCustomerById(string id, [FromBody] CustomerModel customerModel)
        {
            var customerDao = new CustomerDao();

            try
            {
                // Verificar si el objeto existe antes de modificar
                var existingCustomer = await customerDao.findCustomerById(id);
                if (existingCustomer.id_cliente == null || existingCustomer.id_cliente != id)
                {
                    return NotFound(new { message = $"No se encontró el préstamo con el ID: {id}. Revisa tus datos." });
                }

                await customerDao.updateCustomerById(customerModel);
                return Ok(new { message = $"El cliente de ID: {customerModel.id_cliente} fue actualizado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = "Revise bien el  ingreso de los datos." });
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> deleteCustomerById(string id)
        {
            var customerDao = new CustomerDao();

            // Verificar si el objeto existe antes de la eliminación
            var existingCustomer = await customerDao.findCustomerById(id);
            if (existingCustomer.id_cliente == null)
            {
                return NotFound(new { message = $"No se encontró el cliente con el ID: {id} proporcionado para su eliminación." });
            }

            await customerDao.deleteCustomerById(id);

            return Ok(new { message = $"El cliente con ID {id} fue eliminado correctamente." });
        }
    }

}


