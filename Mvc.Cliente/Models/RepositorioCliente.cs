using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Cliente.Models
{
    public class RepositorioCliente 
    {
        string url = "http://localhost:61461/";
        public async Task<bool> AtualizaClienteAsync(Cliente cliente)
        {
            List<Cliente> clientes = new List<Cliente>();
            var contentString = new StringContent(JsonConvert.SerializeObject(cliente), System.Text.Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                HttpResponseMessage resposta = await client.PutAsync(new Uri(url + "api/Cliente/PutCliente"), contentString);
                if (resposta.IsSuccessStatusCode)
                {
                    return resposta.IsSuccessStatusCode;

                }
                else
                {
                    return resposta.IsSuccessStatusCode;

                }

            }

        }

        public async Task<List<Cliente>> BuscaTodosClientesAsync()
        {
            List<Cliente> clientes = new List<Cliente>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                HttpResponseMessage resposta = await client.GetAsync("api/Cliente/GetClientes");
                if (resposta.IsSuccessStatusCode)
                {
                    var resultado = resposta.Content.ReadAsStringAsync().Result;

                    clientes = JsonConvert.DeserializeObject<List<Cliente>>(resultado);
                }
                else
                {
                    clientes = null;
                }
                return clientes;

            }
        }



        public async Task<bool> InsereClienteAsync(Cliente cliente)
        {
            List<Cliente> clientes = new List<Cliente>();
            var contentString = new StringContent(JsonConvert.SerializeObject(cliente), System.Text.Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                HttpResponseMessage resposta = await client.PostAsync(new Uri(url+ "api/Cliente/PostCliente"), contentString);
                if (resposta.IsSuccessStatusCode)
                {
                    return resposta.IsSuccessStatusCode;

                }
                else
                {
                    return resposta.IsSuccessStatusCode;

                }

            }
        }
        public async Task<bool> RemoveClienteAsync(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                
                using (var resultado = await client.DeleteAsync(new Uri(url + "api/Cliente/DeleteCliente/?id=" + id.ToString())))
                {
                  
                    if (resultado.IsSuccessStatusCode)
                    {

                        return resultado.IsSuccessStatusCode;
                    }
                    else
                    {
                        return resultado.IsSuccessStatusCode;

                    }
                  
                }
             

            }

        }
    }
    
}