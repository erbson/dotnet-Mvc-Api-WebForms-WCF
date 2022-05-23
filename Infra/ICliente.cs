using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
   public interface ICliente 
    {
        List<Cliente> BuscaTodosClientes();
        bool InsereCliente(Cliente cliente);
        bool RemoveCliente(int id);
        bool AtualizaCliente(Cliente cliente);
    }
}
