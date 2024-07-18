using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Models;

namespace FilmesAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class FilmesController : ControllerBase
{
    private static int id = 0;
    private static List<Filme> filmes = new List<Filme>();

    [HttpPost]
    public IActionResult AdicionarFilme([FromBody] Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
        return  CreatedAtAction(nameof(RecuperaFilmeId), new { filme.Id }, filme);
    }

    [HttpGet]
    public IEnumerable<Filme> RecuperaFilme([FromQuery]int skip = 0, [FromQuery] int take=50)
    {
        return filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaFilmeId(int id)
    {
      var filme = filmes.FirstOrDefault(filme => filme.Id == id);
      if (filme == null) return NotFound();
      return Ok(filme);
    }

    
}
