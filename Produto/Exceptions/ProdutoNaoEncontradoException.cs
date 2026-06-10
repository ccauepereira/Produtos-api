namespace ProdutosAPI.Exceptions;

public class ProdutoNaoEncontradoException : Exception
{
    public ProdutoNaoEncontradoException(int id) : base($"Produto com identificador: {id} não encontrado")

    {
        
    }
}