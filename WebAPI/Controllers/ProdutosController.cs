using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        public readonly IProdutos _IProdutos;
        public readonly IMapper _IMapper;


        public ProdutosController(IProdutos IProdutos, IMapper IMapper)
        {
            _IProdutos = IProdutos;
            _IMapper = IMapper;
        }

        [HttpPost("/AdicionarProduto")]
        public async Task AdicionarProduto(ProdutosViewModel Produto)
        {
            var ProdutoMap = _IMapper.Map<Produtos>(Produto);
            await _IProdutos.Adicionar(ProdutoMap);
        }

        [HttpPost("/AtualizarProduto")]
        public async Task AtualizarProduto(ProdutosViewModel Produto)
        {
            var ProdutoMap = _IMapper.Map<Produtos>(Produto);
            await _IProdutos.Atualizar(ProdutoMap);
        }

        [HttpPost("/Excluir")]
        public async Task Excluir( int idProduto)
        {
            await _IProdutos.ExcluirProduto(idProduto);
        }

        [HttpPost("/BuscarProduto")]
        public async Task<ProdutosViewModel> BuscarProduto(int codigoProd)
        {
            var Produto = await _IProdutos.BuscaPorCodigo(codigoProd);
            var clienteMap = _IMapper.Map<ProdutosViewModel>(Produto);
            return clienteMap;
        }

        [HttpPost("/ListarProdutos")]
        public async Task<List<ProdutosViewModel>> ListarProdutos()
        {
            var Produto = await _IProdutos.ListaCompleta();
            var clienteMap = _IMapper.Map<List<ProdutosViewModel>>(Produto);
            return clienteMap;
        }

    }
}
