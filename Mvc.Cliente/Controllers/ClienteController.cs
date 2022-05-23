using Mvc.Cliente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Cliente.Controllers
{
   
    public class ClienteController : Controller
    {
        private readonly RepositorioCliente _repositorio = new RepositorioCliente();
        [ActionName("index")]
        public async Task<ActionResult> Index()
        {
            List<Mvc.Cliente.Models.Cliente> clientes = new List<Models.Cliente>();
            var lista = _repositorio.BuscaTodosClientesAsync();
            foreach (var item in await lista)
            {
                clientes.Add(item);

            }
            return View(clientes.AsEnumerable());
        }


        
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<ActionResult> Create_PostAsync(Mvc.Cliente.Models.Cliente cliente)
        {
             var Sucesso = await _repositorio.InsereClienteAsync(cliente);

                if (Sucesso)
                {
                    return RedirectToAction("index");

                }
                else
                {
                    return RedirectToAction("index");
                }
            
            
        }

        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync(int id)
        {
           

            List<Mvc.Cliente.Models.Cliente> clientes = new List<Models.Cliente>();
            var lista = _repositorio.BuscaTodosClientesAsync();
            foreach (var item in await lista)
            {
                clientes.Add(item);

            }
            return View(clientes.Single(x => x.Id == id));
        }

        [HttpPost]
        [ActionName("Edit")]
        public async Task<ActionResult> Edit_PostAsync(Mvc.Cliente.Models.Cliente cliente)
        {

            if (ModelState.IsValid)
            {
                 _repositorio.AtualizaClienteAsync(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            List<Mvc.Cliente.Models.Cliente> clientes = new List<Models.Cliente>();
            var lista = _repositorio.BuscaTodosClientesAsync();
            foreach (var item in await lista)
            {
                clientes.Add(item);

            }
            return View(clientes.Single(x => x.Id == id));
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            _repositorio.RemoveClienteAsync(id);
            return RedirectToAction("Index");
        }


    }
}