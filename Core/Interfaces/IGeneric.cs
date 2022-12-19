using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGeneric<C> where C: class
    {
        Task Adicionar(C Objeto);
        Task Atualizar(C Objeto);
        Task Excluir(C Objeto);
        Task<C> BuscaPorCodigo(int Id);
        Task<List<C>> ListaCompleta();
    }
}
