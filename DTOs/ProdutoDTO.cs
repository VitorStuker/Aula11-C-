using DemoWebServiceEntityFramework2.Models;

namespace DemoWebServiceEntityFramework2.DTOs;
public class ProdutoDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Preco { get; set; }

    public ProdutoDTO(int id, string nome, int preco)
    {
        Id = id;
        Nome = nome;
        Preco = preco/100;
    }

    public static ProdutoDTO FromProduto(Produto produto)
    {
        return new ProdutoDTO(produto.ProdutoId, produto.Nome!, produto.Preco);
    }
}