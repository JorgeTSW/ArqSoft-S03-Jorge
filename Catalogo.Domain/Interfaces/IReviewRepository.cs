using CatalogoApp.Domain.Models;

namespace CatalogoApp.Domain.Interfaces;

public interface IReviewRepository
{
    IEnumerable<Review> ObtenerPorItem(int itemId);
    void Agregar(Review review);
    double PromedioRating(int itemId);
}