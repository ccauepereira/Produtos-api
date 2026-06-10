using System.Linq;
using System.Collections.Generic;
using ProdutosAPI.Exceptions;
using ProdutosAPI.Models;

namespace ProdutosAPI.Repositories;

public partial class InMemoryProdutoRepository : IProdutoRepository
{
    private Dictionary<int, Produto> _produtos = new Dictionary<int, Produto>();

    public void Salvar(Produto p)
    {
        _produtos.Add(p.Id, p);
    }

    public Produto BuscarPorId(int id)
    {
        if (_produtos.TryGetValue(id, out var produtos))
        {
            return produtos;
        }

        throw new ProdutoNaoEncontradoException(id);
    }

    public List<Produto> ListarTodos()
    {
        return _produtos.Values.ToList();
    }

    public void Atualizar(Produto p)
    {
        if (_produtos.TryGetValue(p.Id, out var produtosExiste))
        {
            _produtos[p.Id] = p;
            return;
        }

        throw new ProdutoNaoEncontradoException(p.Id);
    }

    public void Deletar(int id)
    { 
        if (_produtos.TryGetValue(id, out var produtoDeletar))
        {
            _produtos.Remove(id);
            return;
        }
        throw new ProdutoNaoEncontradoException(id);
    }
    
}