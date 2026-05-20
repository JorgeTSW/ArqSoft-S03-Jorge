using CatalogoApp.Domain.Interfaces;
using CatalogoApp.Domain.Models;

namespace CatalogoApp.Application.Services;

public class ReviewService
{
    private readonly IReviewRepository _repo;

    public ReviewService(IReviewRepository repo)
    {
        _repo = repo;
    }

    public IEnumerable<Review> ObtenerReviews(int itemId) =>
        _repo.ObtenerPorItem(itemId);

    public double ObtenerPromedio(int videojuegoId) =>
        _repo.PromedioRating(videojuegoId);

    public void AgregarReview(Review review)
    {
        if (review.Rating < 1 || review.Rating > 5)
            throw new ArgumentException("El rating debe estar entre 1 y 5.");

        _repo.Agregar(review);
    }
}