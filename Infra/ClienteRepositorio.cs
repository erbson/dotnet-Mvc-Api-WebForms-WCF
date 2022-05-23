using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
    public class ClienteRepositorio : ICliente
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Cadastro;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public bool AtualizaCliente(Cliente cliente)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE [dbo].[cliente]");
            sb.Append($"   SET [cpf] = '{cliente.cpf.Replace(".", string.Empty).Replace("-", string.Empty)}' ");
            sb.Append($"      ,[Nome] = '{cliente.Nome}' ");
            sb.Append($"      ,[Rg] = '{cliente.Rg}' ");
            sb.Append($"      ,[Data_Expedicao] = '{cliente.Data_Expedicao.ToString("yyyy-MM-dd HH:mm:ss.fff")}'");
            sb.Append($"      ,[Orgao_Expedidor] = '{cliente.Orgaao_Expedicao}' ");
            sb.Append($"      ,[UF_Expedicao] = '{cliente.UF_Expedicao}' ");
            sb.Append($"      ,[Data_Nascimento] = '{cliente.Data_Nascimento.ToString("yyyy-MM-dd HH:mm:ss.fff")}'");
            sb.Append($"      ,[Sexo] = '{cliente.Sexo}'");
            sb.Append($"      ,[Estado_Civil] = '{cliente.Estado_Civil}' ");
            sb.Append($"      ,[cep] = '{cliente.Cep}'");
            sb.Append($"      ,[Rua] = '{cliente.Rua}' ");
            sb.Append($"      ,[Numero] = '{cliente.Numero}' ");
            sb.Append($"      ,[Complemento] = '{cliente.Complemento}' ");
            sb.Append($"      ,[Bairro] = '{cliente.Bairro}' ");
            sb.Append($"      ,[Cidade] = '{cliente.Cidade}' ");
            sb.Append($"      ,[UF] = '{cliente.UF}' ");
            sb.Append($" WHERE id = {cliente.Id}");

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sb.ToString(), con);
            cmd.CommandType = CommandType.Text;
            con.Open();

            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                return true;

            }

            else
            {
                return false;

            }

        }

        public List<Cliente> BuscaTodosClientes()
        {

            string sql = "SELECT id,cpf,Nome,Rg, Data_Expedicao,Orgao_Expedidor AS Orgaao_Expedicao,UF_Expedicao,Data_Nascimento,Sexo,Estado_Civil,cep,Rua,Numero,Complemento,Bairro,Cidade,UF FROM CLIENTE";

            var listCliente = new List<Cliente>();

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var cliente = new Cliente();

                cliente.Id = Int32.Parse(dr["id"].ToString());
                cliente.cpf = dr["cpf"].ToString();
                cliente.Nome = dr["Nome"].ToString();
                cliente.Rg = dr["Rg"].ToString();
                cliente.Data_Expedicao = dr.GetDateTime(4);
                cliente.Orgaao_Expedicao = dr["Orgaao_Expedicao"].ToString();
                cliente.UF_Expedicao = dr["UF_Expedicao"].ToString();
                cliente.Data_Nascimento = dr.GetDateTime(7);
                cliente.Sexo = dr["Sexo"].ToString();
                cliente.Estado_Civil = dr["Estado_Civil"].ToString();
                cliente.Cep = dr["cep"].ToString();
                cliente.Rua = dr["Rua"].ToString();
                cliente.Numero = dr["Numero"].ToString();
                cliente.Complemento = dr["Complemento"].ToString();
                cliente.Bairro = dr["Complemento"].ToString();
                cliente.Cidade = dr["Cidade"].ToString();
                cliente.UF = dr["uf"].ToString();
                listCliente.Add(cliente);

            }
            return listCliente;
        }

        public List<T> BuscaTodosClientes<T>()
        {
            throw new NotImplementedException();
        }

        public bool InsereCliente(Cliente cliente)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO [dbo].[Cliente]");
            sb.Append("           ([cpf]");
            sb.Append("           ,[Nome]");
            sb.Append("           ,[Rg]");
            sb.Append("           ,[Data_Expedicao]");
            sb.Append("           ,[Orgao_Expedidor]");
            sb.Append("           ,[UF_Expedicao]");
            sb.Append("           ,[Data_Nascimento]");
            sb.Append("           ,[Sexo]");
            sb.Append("           ,[Estado_Civil]");
            sb.Append("           ,[Cep]");
            sb.Append("           ,[Rua]");
            sb.Append("           ,[Numero]");
            sb.Append("           ,[Complemento]");
            sb.Append("           ,[Bairro]");
            sb.Append("           ,[Cidade]");
            sb.Append("           ,[Uf])");
            sb.Append("     VALUES");
            sb.Append($"           ('{cliente.cpf.Replace(".", string.Empty).Replace("-", string.Empty)}'");
            sb.Append($"           ,'{cliente.Nome}'");
            sb.Append($"           ,'{cliente.Rg}'");
            sb.Append($"           ,'{cliente.Data_Expedicao.ToString("yyyy-MM-dd HH:mm:ss.fff")}'");
            sb.Append($"           ,'{cliente.Orgaao_Expedicao}'");
            sb.Append($"           ,'{cliente.UF_Expedicao}'");
            sb.Append($"           ,'{cliente.Data_Nascimento.ToString("yyyy-MM-dd HH:mm:ss.fff")}'");
            sb.Append($"           ,'{cliente.Sexo}'");
            sb.Append($"           ,'{cliente.Estado_Civil}'");
            sb.Append($"           ,'{cliente.Cep}'");
            sb.Append($"           ,'{cliente.Rua}'");
            sb.Append($"           ,'{cliente.Numero}'");
            sb.Append($"           ,'{cliente.Complemento}'");
            sb.Append($"           ,'{cliente.Bairro}'");
            sb.Append($"           ,'{cliente.Cidade}'");
            sb.Append($"           ,'{cliente.UF}')");

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sb.ToString(), con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    return true;

                }

                else
                {
                    return false;

                }


            }
            catch (Exception ex)
            {
                return false;

            }
            finally
            {

                con.Close();

            }

        }

        public bool RemoveCliente(int id)
        {

            string sql = $"DELETE FROM CLIENTE WHERE ID ={id}";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                return true;

            }

            else
            {
                return false;

            }



        }

        public bool ClienteExiste(int id)
        {
            string sql = $"SELECT id FROM CLIENTE WHERE ID ={id}";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                return true;
            }
            return false;
        }


    }
}
