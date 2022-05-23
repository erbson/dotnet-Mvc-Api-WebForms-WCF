using Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Cliente.Controllers
{
    public class ClienteController : ApiController
    {
        static readonly ICliente _cliente = new ClienteRepositorio();
        public HttpResponseMessage GetClientes()
        {
            var listaCliente = _cliente.BuscaTodosClientes();

            return Request.CreateResponse<List<Entity.Cliente>>(HttpStatusCode.OK, listaCliente);
        }

        public HttpResponseMessage PostCliente(Entity.Cliente cliente)
        {
            bool resultado = _cliente.InsereCliente(cliente);
            if (resultado)
            {
                var response = Request.CreateResponse<Entity.Cliente>(HttpStatusCode.Created, cliente);
                return response;
            }
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Não foi possivel inserir o cadastro");
            }

        }
        public HttpResponseMessage PutCliente(Entity.Cliente cliente)
        {
            bool resultado = _cliente.AtualizaCliente(cliente);
            if (resultado)
            {
                var response = Request.CreateResponse<Entity.Cliente>(HttpStatusCode.Created, cliente);
                return response;
            }
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Não foi possivel Atualizar o cadastro");
            }

        }
        [HttpDelete]
        public HttpResponseMessage DeleteCliente(int id)
        {
            bool resultado = _cliente.RemoveCliente(id);
            if (resultado)
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }


    }
}
