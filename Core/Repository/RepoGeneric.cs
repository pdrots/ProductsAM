using Core.Config;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public class RepoGeneric<C> : IGeneric<C>, IDisposable where C : class
    {
        private readonly DbContextOptions<ContextInit> _optionsBuilder;
        public RepoGeneric()
        {
            _optionsBuilder = new DbContextOptions<ContextInit>();
        }

        public async Task Adicionar(C Objeto)
        {
            using (var data = new ContextInit(_optionsBuilder))
            {
                await data.Set<C>().AddAsync(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task Atualizar(C Objeto)
        {
            using (var data = new ContextInit(_optionsBuilder))
            {
                data.Set<C>().Update(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task<C> BuscaPorCodigo(int codigoProd)
        {
            using (var data = new ContextInit(_optionsBuilder))
            {
                return await data.Set<C>().FindAsync(codigoProd);
            }
        }

        public async Task Excluir(C Objeto)
        {
            using (var data = new ContextInit(_optionsBuilder))
            {
                data.Set<C>().Remove(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task<List<C>> ListaCompleta()
        {
            using (var data = new ContextInit(_optionsBuilder))
            {
                return await data.Set<C>().AsNoTracking().ToListAsync();
            }

        }


        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);


        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
        #endregion
    }
}
