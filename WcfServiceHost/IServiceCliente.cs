using Entity;
using Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceHost
{

    [ServiceContract]
    public interface IServiceCliente
    {
        [OperationContract]
        List<Cliente> BuscaTodosClientes();
        [OperationContract]
        bool InsereCliente(Cliente cliente);
        [OperationContract]
        bool RemoveCliente(int id);
        [OperationContract]
        bool AtualizaCliente(Cliente cliente);
        [OperationContract]
        bool ClienteExiste(int id);

    }

}
