using BlibliotecaApp.Models;
using BlibliotecaApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BlibliotecaApp.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService = new ClienteService();

        // GET: Cliente
        public async Task<ActionResult> MainCliente()
        {
            bool AuxC = TempData["AuxC"] != null ? (bool)TempData["AuxC"] : true;

            List<ClienteModel> clientesList = await _clienteService.ListaClientes();
            return View(clientesList);
        }

        public async Task<ActionResult> FormularioCliente(string id)
        {
            var ASUX = id;
            ClienteModel clienteModel = new ClienteModel();
            bool AuxC = TempData["AuxC"] != null ? (bool)TempData["AuxC"] : true;


            if (id != null)
            {
                ViewBag.Acction = "Editar Cliente";
                AuxC = !AuxC;
                TempData["AuxC"] = AuxC;
                clienteModel = await _clienteService.BuscarCliente(id);
            }
            else
            {
                ViewBag.Acction = "Nuevo Cliente";
                AuxC = AuxC;
                TempData["AuxC"] = AuxC;
            }

            return View(clienteModel);
        }

        [HttpPost]
        public async Task<ActionResult> GuardarCliente(ClienteModel clienteModel)
        {
            bool response = false;
            bool AuxC = TempData["AuxC"] != null ? (bool)TempData["AuxC"] : true;
            var auxAAAA = AuxC;

            if (AuxC)
            {
                response = await _clienteService.GuardarCliente(clienteModel);
            }
            else
            {
                response = await _clienteService.EditarCliente(clienteModel);
            }

            if (response)
            {
                return RedirectToAction("MainCliente");
            }
            else
            {
                return RedirectToAction("MainCliente");
            }
        }


        [HttpPost]
        public async Task<ActionResult> EliminarCliente(string id)
        {
            var response = await _clienteService.EliminarCliente(id);
            if (response)
            {
                return RedirectToAction("MainCliente");
            }
            else
            {
                return RedirectToAction("MainCliente");
            }
        }



    }
}