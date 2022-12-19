using System;

namespace WebAPI.ViewModels
{
    public class ProdutosViewModel
    {
        public int id { get; set; }
        public int codigoProd { get; set; }
        public string descricaoProd { get; set; }
        public byte situacao { get; set; }
        public DateTime? dataFabricacao { get; set; }
        public DateTime? dataValidade { get; set; }
        public int? codigoFornecedor { get; set; }
        public string? descricaoFornecedor { get; set; }
        public string? cnpjFornecedor { get; set; }
    }
}
