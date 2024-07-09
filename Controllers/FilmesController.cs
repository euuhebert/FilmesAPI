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
    public void AdicionarFilme([FromBody] Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
        Console.WriteLine(filme.Genero);
        Console.WriteLine(filme.Duracao);
        Console.WriteLine(filme.Titulo);
    }

    [HttpGet]
    public List<Filme> RecuperaFilme()
    {
        return filmes;
    }

    [HttpGet("{id}")]
    public Filme? RecuperaFilmeId(int id)
    {
      return filmes.FirstOrDefault(filme => filme.Id == id);
    }
}
