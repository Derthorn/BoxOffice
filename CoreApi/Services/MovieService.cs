using System.Text.Json;
using CoreApi.Models;
using MovieRepository;

namespace CoreApi.Services;

public class MovieService : IMovieService
{
    private static IMovieRepo _movieRepo;
    private IEnumerable<Movie> _movies;

    public MovieService(IMovieRepo movieRepo)
    {
        _movieRepo = movieRepo;
        _movies = JsonSerializer.Deserialize<Movie[]>(_movieRepo.Get());
    }

    public IEnumerable<Movie> Get()
    {
        return _movies;
    }

    public Movie Get(Guid id)
    {
        return _movies.FirstOrDefault(m => m.Id == id);
    }

    public Movie Search(string query)
    {
        var movie = _movies.First(q => q.Title.ToLower().Equals(query.ToLower()));
        return movie;
    }

    IEnumerable<Movie> IMovieService.SearchByGenre(string[] query)
    {
        return SearchByGenre(query);
    }

    public Movie Put(Movie movie)
    {
        if (movie.Id == Guid.Empty) movie.Id = Guid.NewGuid();

        var putMovieWasSuccessful = _movieRepo.Put(JsonSerializer.Serialize(movie));
        if (putMovieWasSuccessful)
        {
            var temp = _movies.ToList();
            temp.Add(movie);
            _movies = temp;
        }
        return putMovieWasSuccessful ? movie : null;
    }

    public Movie Rate(Guid id, int rating)
    {
        if (rating < 0 || rating > 10) return null;
        var movie = Get(id);
        
        //This is just an assumption - in reality this problem should be solved in the external repository.
        movie.Rating = ((movie.Rating * movie.Ratings) + rating) / (movie.Ratings +1);
        movie.Ratings += 1;

        return Put(movie);
    }

    public Movie[] SearchByGenre(string[] query)
    {
        return _movies.Where(q =>
        {
            return query.All(genre => q.Genre.Contains(genre));
        }).ToArray();;
    }
}