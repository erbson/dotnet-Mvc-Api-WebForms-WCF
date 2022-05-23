<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Cliente.aspx.cs" Inherits="ClienteWebForms.Cliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="Scripts/Maskara.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.11/jquery.mask.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.5.1/js/bootstrap-datepicker.min.js"></script>

    <script type="text/javascript">
        $(function () {
            $('#inputDataExpedicao').datepicker({ format: 'dd/mm/yyyy', autoclose: true });
            $('#inputDataNascimento').datepicker({ format: 'd/m/yyyy', autoclose: true });
            $("#inputCPF").mask("999.999.999-99");


        });

        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("você Deseja Relmente Excluir o Cadastro?")) {
                confirm_value.value = "Sim";
            } else {
                confirm_value.value = "Nao";
            }
            document.forms[0].appendChild(confirm_value);
        }

    </script>
    <style>
        #MainContent_GridView1 > tbody > tr:nth-child(1) > th:nth-child(4) {
            padding-right: 200px !important;
        }

        #MainContent_GridView1 > tbody > tr:nth-child(1) > th:nth-child(13) {
            padding-right: 150px !important;
        }

        #MainContent_GridView1 > tbody > tr:nth-child(1) > th:nth-child(17) {
            padding-right: 150px;
        }

        #MainContent_inputUF {
            width: 150px;
        }
        
    </style>

    <div class="espco" style="height: 30px;"></div>
    <div class="container">

        <script>
            (document).ready(function () {
                $("#MainContent_inputCPF").mask("999.999.999-99");

            });
            function ValidaCFP(varlo2) {

                var valor = document.getElementById("MainContent_inputCPF").value;

                var data =
                {
                    cpf: valor
                };
                $.ajax({
                    url: "Cliente.aspx/ValidarCpf",
                    data: JSON.stringify(data),
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (retorno) {
                        if (retorno.d == false) {
                            document.getElementById("MainContent_inputCPF").value = "";
                        } else {
                            $("#MainContent_inputCPF").mask("999.999.999-99");
                        }

                    },
                    error: function (req, status, error) {
                        alert(error);
                    }
                });
            }

        </script>
        <form>

            <div class="form-row">
                <input type="hidden" id="codigo" name="codigo" value="<%# Eval("id") %>">

                <div class="form-group col-md-4">
                    <label for="inputCPF">CPF *</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldCPF"
                        ControlToValidate="inputcpf"
                        Display="Static"
                        ErrorMessage="* cpf valido é obrigatorio"
                        runat="server" Font-Strikeout="False" ForeColor="Red" />
                    <input id="inputCPF" type="text" class="form-control" onblur="ValidaCFP(this,event)" runat="server" />
                </div>
                <div class="form-group col-md-8">
                    <label for="inputNome">Nome *</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldNome"
                        ControlToValidate="inputNome"
                        Display="Static"
                        ErrorMessage="* campos obrigatorios!"
                        runat="server" Font-Strikeout="False" ForeColor="Red" />
                    <input type="text" class="form-control" id="inputNome" runat="server" placeholder="Nome" style="width: 4000px;">
                </div>

            </div>
            <div class="form-row">
                <div class="form-group col-md-3">
                    <label for="inputRg">RG</label>
                    <input type="text" class="form-control" runat="server" id="inputRG">
                </div>
                <div class="form-group col-md-3">
                    <label for="inputEstado">Data Expedição</label>
                    <input type="date" class="form-control" runat="server" name="NameDataExpedicao" id="inputDataExpedicao">
                </div>
                <div class="form-group col-md-3">
                    <label for="inputOrgaoExpedicao">Orgão Expedição</label>
                    <input type="text" class="form-control" runat="server" id="inputOrgaoExpedicao">
                </div>

                <div class="form-group col-md-3">
                    <label for="inputUfExpedicao">UF Expedição</label>
                    <select id="inputUfExpedicao" class="form-control" runat="server">
                        <option selected>Escolher...</option>
                        <option value="AC">Acre</option>
                        <option value="AL">Alagoas</option>
                        <option value="AP">Amapá</option>
                        <option value="AM">Amazonas</option>
                        <option value="BA">Bahia</option>
                        <option value="CE">Ceará</option>
                        <option value="ES">Espírito Santo</option>
                        <option value="GO">Goiás</option>
                        <option value="MA">Maranhão</option>
                        <option value="MT">Mato Grosso</option>
                        <option value="MS">Mato Grosso do Sul</option>
                        <option value="MG">Minas Gerais</option>
                        <option value="PA">Pará</option>
                        <option value="PB">Paraíba</option>
                        <option value="PR">Paraná</option>
                        <option value="PE">Pernambuco</option>
                        <option value="PI">Piauí</option>
                        <option value="RJ">Rio de Janeiro</option>
                        <option value="RN">Rio Grande do Norte</option>
                        <option value="RS">Rio Grande do Sul</option>
                        <option value="RO">Rondônia</option>
                        <option value="RR">Roraima</option>
                        <option value="SC">Santa Catarina</option>
                        <option value="SP">São Paulo</option>
                        <option value="SE">Sergipe</option>
                        <option value="TO">Tocantins</option>
                    </select>
                </div>
            </div>
            <div class="form-row">

                <div class="form-group col-md-4">
                    <label for="inputDataNascimento">Data de Nascimento *</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldDataNascimento"
                        ControlToValidate="inputDataNascimento"
                        Display="Static"
                        ErrorMessage="*"
                        runat="server" Font-Strikeout="False" ForeColor="Red" />

                    <asp:RegularExpressionValidator
                        ID="RegularExpressionValidator1"
                        runat="server"
                        ErrorMessage=" Data invalida"
                        ControlToValidate="inputDataNascimento"
                        ValidationExpression="^\d{4}[\-\/\s]?((((0[13578])|(1[02]))[\-\/\s]?(([0-2][0-9])|(3[01])))|(((0[469])|(11))[\-\/\s]?(([0-2][0-9])|(30)))|(02[\-\/\s]?[0-2][0-9]))$"
                        ForeColor="Red"
                        ToolTip="Digite um CEP ( 8 dígitos numéricos)">
                    </asp:RegularExpressionValidator>

                    <input type="date" class="form-control" id="inputDataNascimento" name="NameDataNascimento" runat="server" placeholder="Data de Nascimento..">
                </div>
                <div class="form-group col-md-4">
                    <label for="inputUfExpedicao">Sexo *</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldSexo"
                        ControlToValidate="inputSexo"
                        Display="Static"
                        ErrorMessage="*"
                        runat="server" Font-Strikeout="False" ForeColor="Red" />

                    <select id="inputSexo" class="form-control" runat="server">
                        <option selected>Escolher...</option>
                        <option value="Masculino">Masculino</option>
                        <option value="Feminino">Feminino</option>
                    </select>
                </div>
                <div class="form-group col-md-4">
                    <label for="inputExtadoCivil">Estado Civil *</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldinputExtadoCivil"
                        ControlToValidate="inputExtadoCivil"
                        Display="Static"
                        ErrorMessage="*"
                        runat="server" Font-Strikeout="False" ForeColor="Red" />

                    <select id="inputExtadoCivil" class="form-control" runat="server">
                        <option selected>Escolher...</option>
                        <option value="Solteiro">Solteiro</option>
                        <option value="Casado">Casado</option>
                        <option value="Viúvo">Viúvo</option>
                        <option value="Separado judicialmente">Separado judicialmente</option>
                        <option value="Divorciado">Divorciado</option>
                    </select>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-1">
                    <label for="inputCep">CEP *</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldinputCep"
                        ControlToValidate="inputCep"
                        Display="Static"
                        ErrorMessage="*"
                        runat="server" Font-Strikeout="False" ForeColor="Red" />

                    <input type="text" class="form-control" runat="server" id="inputCep" placeholder="CEP..">
                </div>
                <div class="form-group col-md-3">
                    <label for="inputRua">Rua *</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldinputRua"
                        ControlToValidate="inputRua"
                        Display="Static"
                        ErrorMessage="*"
                        runat="server" Font-Strikeout="False" ForeColor="Red" />

                    <input type="text" class="form-control" id="inputRua" runat="server" placeholder="Rua..">
                </div>
                <div class="form-group col-md-1">
                    <label for="inputNumero">Numero</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldinputNumero"
                        ControlToValidate="inputNumero"
                        Display="Static"
                        ErrorMessage="*"
                        runat="server" Font-Strikeout="False" ForeColor="Red" />

                    <input type="text" class="form-control" id="inputNumero" runat="server" placeholder="Numero..">
                </div>

                <div class="form-group col-md-2">
                    <label for="inputCep">Complemento</label>
                    <input type="text" class="form-control" id="inputComplemento" runat="server" placeholder="Complemento..">
                </div>
                <div class="form-group col-md-2">
                    <label for="inputBairro">Bairro *</label>
                    <asp:RequiredFieldValidator ID="RequiredFielinputBairro"
                        ControlToValidate="inputBairro"
                        Display="Static"
                        ErrorMessage="*"
                        runat="server" Font-Strikeout="False" ForeColor="Red" />
                    <input type="text" class="form-control" id="inputBairro" runat="server" placeholder="Bairro..">
                </div>

                <div class="form-group col-md-2">
                    <label for="inputCidade">Cidade *</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldinputCidade"
                        ControlToValidate="inputCidade"
                        Display="Static"
                        ErrorMessage="*"
                        runat="server" Font-Strikeout="False" ForeColor="Red" />

                    <input type="text" class="form-control" id="inputCidade" runat="server" placeholder="Cidade..">
                </div>

                <div class="form-group col-md-1">
                    <label for="inputUF">UF *</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldinputUF"
                        ControlToValidate="inputUF"
                        Display="Static"
                        ErrorMessage="*"
                        runat="server" Font-Strikeout="False" ForeColor="Red" />
                    <select id="inputUF" runat="server" class="form-control">
                        <option selected>Selecione a UF.</option>
                        <option value="AC">Acre</option>
                        <option value="AL">Alagoas</option>
                        <option value="AP">Amapá</option>
                        <option value="AM">Amazonas</option>
                        <option value="BA">Bahia</option>
                        <option value="CE">Ceará</option>
                        <option value="ES">Espírito Santo</option>
                        <option value="GO">Goiás</option>
                        <option value="MA">Maranhão</option>
                        <option value="MT">Mato Grosso</option>
                        <option value="MS">Mato Grosso do Sul</option>
                        <option value="MG">Minas Gerais</option>
                        <option value="PA">Pará</option>
                        <option value="PB">Paraíba</option>
                        <option value="PR">Paraná</option>
                        <option value="PE">Pernambuco</option>
                        <option value="PI">Piauí</option>
                        <option value="RJ">Rio de Janeiro</option>
                        <option value="RN">Rio Grande do Norte</option>
                        <option value="RS">Rio Grande do Sul</option>
                        <option value="RO">Rondônia</option>
                        <option value="RR">Roraima</option>
                        <option value="SC">Santa Catarina</option>
                        <option value="SP">São Paulo</option>
                        <option value="SE">Sergipe</option>
                        <option value="TO">Tocantins</option>
                    </select>
                </div>
            </div>
        </form>

        <asp:Button ID="Button1" class="btn btn-primary" runat="server" OnClick="Button1_Click" Text="SALVAR" Width="140px" />
        <asp:Button ID="Button2" class="btn btn-danger" runat="server" Height="35px" OnClick="Button2_Click" OnClientClick="Confirm()" Text="EXCLUIR" Width="135px" />
        <asp:TextBox ID="txCodigo" runat="server" Visible="False"></asp:TextBox>

        <div id="mensagens" runat="server">
            <h3 id="Mensagem" runat="server" class="alert alert-info"></h3>
        </div>


        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateSelectButton="True" Wrap="false" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Codigo"
                        InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="cpf" HeaderText="CPF"></asp:BoundField>
                    <asp:BoundField DataField="Nome" HeaderText="Nome"></asp:BoundField>
                    <asp:BoundField DataField="rg" HeaderText="RG"></asp:BoundField>
                    <asp:BoundField DataField="Data_Expedicao" HeaderText="Data Expedição" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
                    <asp:BoundField DataField="Orgaao_Expedicao" HeaderText="Orgão Expedição"></asp:BoundField>
                    <asp:BoundField DataField="UF_Expedicao" HeaderText="UF Expedição"></asp:BoundField>
                    <asp:BoundField DataField="Data_Nascimento" HeaderText="Data de Nascimento" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
                    <asp:BoundField DataField="Sexo" HeaderText="Sexo"></asp:BoundField>
                    <asp:BoundField DataField="Estado_Civil" HeaderText="Estado Civil"></asp:BoundField>
                    <asp:BoundField DataField="cep" HeaderText="CEP"></asp:BoundField>
                    <asp:BoundField DataField="Rua" HeaderText="Rua" ItemStyle-Width="220px"></asp:BoundField>
                    <asp:BoundField DataField="Numero" HeaderText="Numero"></asp:BoundField>
                    <asp:BoundField DataField="complemento" HeaderText="Complemento"></asp:BoundField>
                    <asp:BoundField DataField="Bairro" HeaderText="Complemento"></asp:BoundField>
                    <asp:BoundField DataField="Cidade" HeaderText="Cidade"></asp:BoundField>
                    <asp:BoundField DataField="uf" HeaderText="UF"></asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
