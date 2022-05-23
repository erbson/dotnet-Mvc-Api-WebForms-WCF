using Infra;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceHost
{


    public class ServiceCliente : IServiceCliente
    {
        ClienteRepositorio _cliente = new ClienteRepositorio();
        public ServiceCliente(ClienteRepositorio clienteRepositorio)
        {
            _cliente = clienteRepositorio;
        }
        public ServiceCliente()
        {

        }
        public bool AtualizaCliente(Cliente cliente)
        {
            return _cliente.AtualizaCliente(cliente);
        }

        public List<Cliente> BuscaTodosClientes()
        {
            return _cliente.BuscaTodosClientes();
        }

        public bool InsereCliente(Cliente cliente)
        {
            return _cliente.InsereCliente(cliente);
        }

        public bool RemoveCliente(int id)
        {
            return _cliente.RemoveCliente(id);
        }


        public bool ClienteExiste(int id)
        {
            return _cliente.ClienteExiste(id);


        }
    }
}
