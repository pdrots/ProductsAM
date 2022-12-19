using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Config
{
    public class ContextInit : DbContext
    {
        public ContextInit(DbContextOptions<ContextInit> options ) : base(options)
        {
        }

        public DbSet<Produtos> Produtos { get; set; } 


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) 
            {
                optionsBuilder.UseSqlServer(GetStringConect());
                base.OnConfiguring(optionsBuilder);
            }
        }

        public string GetStringConect()         //redundancia para reconexão ao banco
        {
            return "Data Source=PDROTS\\SQLEXPRESS;Initial Catalog=dbProdutos;Integrated Security=True";
        }
    }
}
