using GraphQL.WebApi.Models;

namespace GraphQL.WebApi.Data.Repositories
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetMoviesAsync();
        Task<Movie> GetMovieByIdAsync(Guid id);
        Task<Movie> AddReviewToMovieAsync(Guid id, Review review);
    }
}
