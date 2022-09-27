using CoreApi.Models;

namespace CoreApi.Services;

public interface IMovieService
{
    public IEnumerable<Movie> Get();
    public Movie Get(Guid id);

    public Movie Search(string query);
    public IEnumerable<Movie> SearchByGenre(string[] query);
    public Movie Put(Movie movie);
    public Movie Rate(Guid id, int rating);
}