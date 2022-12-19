using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    [Table("Produtos")]
    public class Produtos
    {
        public int id { get; set; }
        public int codigoProd { get; set; }
        [Required()]
        public string descricaoProd { get; set; }
        public byte situacao { get; set; }
        public DateTime? dataFabricacao { get; set; }
        public DateTime? dataValidade { get; set; }
        public int? codigoFornecedor { get; set; }
        public string? descricaoFornecedor { get; set; }
        public string? cnpjFornecedor { get; set; }

    }
}
