using Atividade_05.Models;
using Microsoft.AspNetCore.Mvc;
namespace Atividade_05.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private static List<Produto> produtos = new List<Produto>();

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(produtos);
    }

    [HttpGet("{codigo}")]
    public IActionResult Get(string codigo)
    {
        var produto = produtos.FirstOrDefault(p => p.CodigoProduto == codigo);

        if (produto == null)
        {
            return NotFound("Produto não encontrado.");
        }

        return Ok(produto);
    }

    [HttpPost]
    public IActionResult Post(Produto produto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (produtos.Any(p => p.CodigoProduto == produto.CodigoProduto))
        {
            return BadRequest("Este código de produto já está cadastrado.");
        }

        produtos.Add(produto);

        return Ok(produto);
    }

    [HttpPut("{codigo}")]
    public IActionResult Put(string codigo, Produto produtoAtualizado)
    {
        var produto = produtos.FirstOrDefault(p => p.CodigoProduto == codigo);

        if (produto == null)
        {
            return NotFound("Produto não encontrado.");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        produto.Descricao = produtoAtualizado.Descricao;
        produto.Preco = produtoAtualizado.Preco;
        produto.Estoque = produtoAtualizado.Estoque;

        return Ok(produto);
    }

    [HttpDelete("{codigo}")]
    public IActionResult Delete(string codigo)
    {
        var produto = produtos.FirstOrDefault(p => p.CodigoProduto == codigo);

        if (produto == null)
        {
            return NotFound("Produto não encontrado.");
        }

        produtos.Remove(produto);

        return Ok("Produto excluído com sucesso.");
    }
}
