using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Models;

namespace FilmesAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class FilmesController : ControllerBase
{
    
    private static List<Filme> filmes = new List<Filme>();

    [HttpPost]
    public void AdicionarFilme([FromBody] Filme filme)
    {
        filmes.Add(filme);
        Console.WriteLine(filme.Genero);
        Console.WriteLine(filme.Duracao);
        Console.WriteLine(filme.Titulo);
    }
}
