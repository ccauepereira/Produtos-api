using System.Net;
using Microsoft.AspNetCore.Mvc;
using ProdutosAPI.DTOs;
using ProdutosAPI.Exceptions;
using ProdutosAPI.Models;
using ProdutosAPI.Services;

namespace ProdutosAPI.Controllers;

[ApiController]
[Route("api/produtos")]
public class ProdutosController : ControllerBase
{
    private readonly ProdutoService _produtoService;
    
    public ProdutosController(ProdutoService _produtoService)
    {
        this._produtoService = _produtoService;
    }

    [HttpGet]
    public IActionResult Listar()
    {
        List<Produto> list = _produtoService.Listar();
        return Ok(list);
    }

    [HttpGet("{id}")]
    public IActionResult Buscar(int id)
    {
        try
        {
            var produto = _produtoService.Buscar(id);
            return Ok(produto);
        }
        catch (ProdutoNaoEncontradoException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult Criar([FromBody] CriarProdutoDto dto)
    {
        _produtoService.Criar(dto.Nome, dto.Preco, dto.Estoque);
        return Created("/api/produtos", dto);
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(int id, [FromBody] AtualizarProdutoDto dto)
    {
        try
        {
            _produtoService.Atualizar(id, dto.Nome, dto.Preco, dto.Estoque);
            return NoContent();
        }
        catch (ProdutoNaoEncontradoException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpDelete("{id}")]
    public IActionResult Deleta(int id)
    {
        try
        {
            _produtoService.Deletar(id);
            return NoContent();
        }
        catch (ProdutoNaoEncontradoException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
}