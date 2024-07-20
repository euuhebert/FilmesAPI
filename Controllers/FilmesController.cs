using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Models;
using FilmesAPI.Data;

namespace FilmesAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class FilmesController : ControllerBase
{
    private FilmeContext _context;

    public FilmesController(FilmeContext context)
    {
        _context = context;
    }
    

    [HttpPost]
    public IActionResult AdicionarFilme([FromBody] Filme filme)
    {
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return  CreatedAtAction(nameof(RecuperaFilmeId), new { filme.Id }, filme);
    }

    [HttpGet]
    public IEnumerable<Filme> RecuperaFilme([FromQuery]int skip = 0, [FromQuery] int take=50)
    {
        return _context.Filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaFilmeId(int id)
    {
      var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
      if (filme == null) return NotFound();
      return Ok(filme);
    }

    
}
