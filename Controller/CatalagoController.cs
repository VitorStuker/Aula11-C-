using Microsoft.AspNetCore.Mvc;

using DemoWebServiceEntityFramework2.Data;
using DemoWebServiceEntityFramework2.DTOs;
using DemoWebServiceEntityFramework2.Models;

namespace DemoWebServiceEntityFramework2.Controllers;

[ApiController]
[Route("controller")]

public class CatalagoController : ControllerBase
{
    private readonly ILogger<CatalagoController> _logger;
    private readonly IProdutoRepository _produtoRepository;

    public CatalagoController(ILogger<CatalagoController> logger, IProdutoRepository produtoRepository)
    {
        _logger = logger;
        _produtoRepository = produtoRepository;
    }

    //GET /catalogo
    [HttpGet]
    public async Task<IEnumerable<ProdutoDTO>> GetAll()
    {
        var produtos = await _produtoRepository.GetAllAsync();
        return produtos.Select(ProdutoDTO.FromProduto);
    }

    [HttpGet("{id}")]  //GET /catalogo/1

    public async Task<ActionResult<ProdutoDTO>> GetById(int id)
    {
        var produto = await _produtoRepository.GetAsync(id);
        return ProdutoDTO.FromProduto(produto);
    }
}