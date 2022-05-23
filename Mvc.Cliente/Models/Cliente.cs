using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Cliente.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        public string cpf { get; set; }

        public string Nome { get; set; }

        public string Rg { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data_Expedicao { get; set; }

        public string Orgaao_Expedicao { get; set; }

        public string UF_Expedicao { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data_Nascimento { get; set; }

        public string Sexo { get; set; }

        public string Estado_Civil { get; set; }

        public string Cep { get; set; }

        public string Rua { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string UF { get; set; }

    }
}