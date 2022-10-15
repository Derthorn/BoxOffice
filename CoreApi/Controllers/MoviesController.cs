using CoreApi.Models;
using CoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{

    private readonly IMovieService _movieService;

    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
    }
    
    [HttpGet]
    public List<Movie> Get()
    {
        return _movieService.Get().ToList();
    }
    
    [HttpGet("{id}")]
    public Movie Get(Guid id)
    {
        return _movieService.Get(id);
    }
    
    [HttpPut]
    public Movie Put([FromBody] Movie movie)
    {
        return _movieService.Put(movie);
    }

    [HttpGet("[action]/{id}/{rating}")]
    public Movie Rate(Guid id, int rating)
    {
        return id == Guid.Empty ? null : _movieService.Rate(id, rating);
    }
    
    [HttpGet("[action]/{query}")]
    public Movie Search(string query)
    {
        return string.IsNullOrEmpty(query) ? null : _movieService.Search(query);
    }

    [HttpGet("[action]/{query}")]
    public List<Movie> SearchByGenre(string[] query)
    {
        return _movieService.SearchByGenre(query).ToList();
    }

}