using ProdutosAPI.Models;
using ProdutosAPI.Repositories;

namespace ProdutosAPI.Services;

public class ProdutoService
{
    private readonly IProdutoRepository _produtoRepository;
    private static int contID = 1;

    public ProdutoService(IProdutoRepository _produtoRepository)
    {
        this._produtoRepository = _produtoRepository;
    }

    public void Criar(string nome, decimal preco, int estoque)
    {
        int idGerado = contID;
        contID++;

        Produto novoProduto = new Produto(idGerado, nome, preco, estoque);
        _produtoRepository.Salvar(novoProduto);
    }

    public Produto Buscar(int id)
    {
        return _produtoRepository.BuscarPorId(id);
    }

    public List<Produto> Listar()
    {
        return _produtoRepository.ListarTodos();
    }

    public void Atualizar(int id, string nome, decimal preco, int estoque)
    {
        Produto produto = _produtoRepository.BuscarPorId(id);
        Produto produtoATT = new Produto(id, nome, preco, estoque);
        _produtoRepository.Atualizar(produtoATT);
    }

    public void Deletar(int id)
    {
        _produtoRepository.Deletar(id);
    }
    
}