using ProdutosAPI.Models;

namespace ProdutosAPI.Repositories;

public interface IProdutoRepository
{
    void Salvar(Produto p);
    Produto BuscarPorId(int id);
    List<Produto> ListarTodos();
    void Atualizar(Produto p);
    void Deletar(int id);
}