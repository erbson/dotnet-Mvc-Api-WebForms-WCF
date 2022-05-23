using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [DataContract]
    public partial class Cliente
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string cpf { get; set; }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public string Rg { get; set; }
        [DataMember]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data_Expedicao { get; set; }
        [DataMember]
        public string Orgaao_Expedicao { get; set; }
        [DataMember]
        public string UF_Expedicao { get; set; }
        [DataMember]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data_Nascimento { get; set; }
        [DataMember]
        public string Sexo { get; set; }
        [DataMember]
        public string Estado_Civil { get; set; }
        [DataMember]
        public string Cep { get; set; }
        [DataMember]
        public string Rua { get; set; }
        [DataMember]
        public string Numero { get; set; }
        [DataMember]
        public string Complemento { get; set; }
        [DataMember]
        public string Bairro { get; set; }
        [DataMember]
        public string Cidade { get; set; }
        [DataMember]
        public string UF { get; set; }
    
    }
}
