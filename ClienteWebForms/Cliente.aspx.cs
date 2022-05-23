using Entity;
using Infra;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteWebForms
{
    public partial class Cliente : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            mensagens.Visible = false;
            LoadGrid();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            int codigo = (string.IsNullOrEmpty(txCodigo.Text)) ? 0 : Int32.Parse(txCodigo.Text);
            string strDataExpedicao = ConvertDate(inputDataExpedicao.Value);
            string strDataNascimento = ConvertDate(inputDataNascimento.Value);
            Entity.Cliente cliente = new Entity.Cliente();
            ServiceReference1.ServiceClienteClient clienteService = new ServiceReference1.ServiceClienteClient();
            cliente.Nome = inputNome.Value;
            cliente.cpf = inputCPF.Value;
            cliente.Rg = inputRG.Value;
            DateTime DateExpedicao = DateTime.ParseExact(strDataExpedicao, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            cliente.Data_Expedicao = DateExpedicao.Date;
            cliente.Orgaao_Expedicao = inputOrgaoExpedicao.Value;
            cliente.UF_Expedicao = inputUfExpedicao.Value;
            DateTime DateNascimento = Convert.ToDateTime(strDataNascimento);
            cliente.Data_Nascimento = DateNascimento.Date;
            cliente.Sexo = inputSexo.Value;
            cliente.Estado_Civil = inputExtadoCivil.Value;
            cliente.Cep = inputCep.Value;
            cliente.Rua = inputRua.Value;
            cliente.Numero = inputNumero.Value;
            cliente.Complemento = inputComplemento.Value;
            cliente.Bairro = inputBairro.Value;
            cliente.Cidade = inputCidade.Value;
            cliente.UF = inputUF.Value;
            if (clienteService.ClienteExiste(codigo))
            {
                cliente.Id = codigo;

                if (clienteService.AtualizaCliente(cliente))
                {
                    mensagens.Visible = true;
                    Mensagem.InnerText = "Dados atualizados com Sucesso!";
                    LoadGrid();
                    LimpaGrid();
                }

            }
            else
            {
                if (clienteService.InsereCliente(cliente))
                {
                    mensagens.Visible = true;
                    Mensagem.InnerText = "Cliente Cadastrado com Sucesso";
                    LoadGrid();
                    LimpaGrid();
                }

            }
        }

        void LoadGrid()
        {
            ServiceReference1.ServiceClienteClient cliente = new ServiceReference1.ServiceClienteClient();
            GridView1.DataSource = cliente.BuscaTodosClientes();
            GridView1.DataBind();

        }
        void LimpaGrid()
        {
            txCodigo.Text = "";
            inputCPF.Value = "";
            inputNome.Value = "";
            inputRG.Value = "";
            inputDataExpedicao.Value = "";
            inputOrgaoExpedicao.Value = "";
            inputUfExpedicao.Value = "";
            inputDataNascimento.Value = "";
            inputSexo.Value = "";
            inputExtadoCivil.Value ="";
            inputCep.Value = "";
            inputRua.Value = "";
            inputNumero.Value = "";
            inputComplemento.Value = "";
            inputBairro.Value = "";
            inputCidade.Value = "";
            inputUF.Value = "";

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txCodigo.Text = GridView1.SelectedRow.Cells[1].Text;
            inputCPF.Value = GridView1.SelectedRow.Cells[2].Text;
            inputNome.Value = GridView1.SelectedRow.Cells[3].Text;

            inputRG.Value = GridView1.SelectedRow.Cells[4].Text;
            // Response.Write("NameDataExpedicao"] = GridView1.SelectedRow.Cells[5].Text;
            inputDataExpedicao.Value = ConvertDate(GridView1.SelectedRow.Cells[5].Text, true);
            inputOrgaoExpedicao.Value = GridView1.SelectedRow.Cells[6].Text;
            inputUfExpedicao.Value = GridView1.SelectedRow.Cells[7].Text;
            inputDataNascimento.Value = ConvertDate(GridView1.SelectedRow.Cells[8].Text, true);
            inputSexo.Value = GridView1.SelectedRow.Cells[9].Text;
            inputExtadoCivil.Value = GridView1.SelectedRow.Cells[10].Text;
            inputCep.Value = GridView1.SelectedRow.Cells[11].Text;
            inputRua.Value = GridView1.SelectedRow.Cells[12].Text;
            inputNumero.Value = GridView1.SelectedRow.Cells[13].Text;
            inputComplemento.Value = GridView1.SelectedRow.Cells[14].Text;
            inputBairro.Value = GridView1.SelectedRow.Cells[15].Text;
            inputCidade.Value = GridView1.SelectedRow.Cells[16].Text;
            inputUF.Value = GridView1.SelectedRow.Cells[17].Text;

        }

        static string ConvertDate(string Databootstrap, bool seleciona = false)
        {

            string Ano, Mes, Dia, dataConvertida;
            Ano = Databootstrap.Substring(0, 4);
            Mes = Databootstrap.Substring(5, 2);
            Dia = Databootstrap.Substring(8, 2);
            if (seleciona)
            {
                Dia = Databootstrap.Substring(0, 2);
                Mes = Databootstrap.Substring(3, 2);
                Ano = Databootstrap.Substring(6, 4);

                return dataConvertida = Ano + "-" + Mes + "-" + Dia;

            }
            return dataConvertida = Dia + "/" + Mes + "/" + Ano;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ServiceReference1.ServiceClienteClient clienteService = new ServiceReference1.ServiceClienteClient();
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Sim")
            {

                if (clienteService.RemoveCliente(Int32.Parse(txCodigo.Text)))
                {
                    mensagens.Visible = true;
                    Mensagem.InnerText = "Cadastro excluido com Sucesso";
                    LimpaGrid();
                    LoadGrid();

                }

            }

        }

        [WebMethod]
        public static bool ValidarCpf(string cpf)
        {

            if (!Valida.Cpf(cpf))
            {

                return false;
            }
            return true;
        }
    }
}