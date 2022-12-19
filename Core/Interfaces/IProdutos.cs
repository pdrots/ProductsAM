using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProdutos : IGeneric<Produtos>
    {
        Task ExcluirProduto(int id);
    }
}
