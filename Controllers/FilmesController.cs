using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Models;
using FilmesAPI.Data;
using AutoMapper;
using FilmesAPI.Data.Dtos;

namespace FilmesAPI.Controllers;


[
    ApiController]
[Route("[controller]")]
public class FilmesController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public FilmesController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpPost]
    public IActionResult AdicionarFilme([FromBody] CreateFilmeDto filmeDto)
    {

        Filme filme = _mapper.Map<Filme>(filmeDto);
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
