namespace ProdutosAPI.Models;

public class Produto
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public decimal Preco { get; private set; }
    public int Estoque { get; private set; }

    public Produto(int id, string nome, decimal preco, int estoque)
    {
        Id = id;
        Nome = nome;
        Preco = preco;
        Estoque = estoque;
    }

    public override string ToString()
    {
        return $"| Produto: {Id} " +
               $"| Nome: {Nome} " +
               $"| Preço: {Preco} " +
               $"| Estoque: {Estoque}";
    }
}
