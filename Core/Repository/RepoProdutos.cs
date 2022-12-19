using Core.Config;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public class RepoProdutos : RepoGeneric<Produtos>, IProdutos
    {
        private readonly DbContextOptions<ContextInit> _optionsBuilder;
        public RepoProdutos()
        {
            _optionsBuilder = new DbContextOptions<ContextInit>();
        }

        public async Task ExcluirProduto(int id)
        {
            Produtos Prod = new Produtos();
            using (var data = new ContextInit(_optionsBuilder))
            {
                Prod = await data.Set<Produtos>().FindAsync(id);

                if (Prod.situacao != Convert.ToByte(false))
                {
                    Prod.situacao = Convert.ToByte(false);            //false = inativo
                    data.Set<Produtos>().Update(Prod);
                    await data.SaveChangesAsync();
                }
            }
        }
    }
}
