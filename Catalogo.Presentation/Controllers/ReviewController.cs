using CatalogoApp.Application.Services;
using CatalogoApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoApp.Presentation.Controllers;

public class ReviewController : Controller
{
    private readonly ReviewService _reviewService;

    public ReviewController(ReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    // POST: /Review/Agregar
    [HttpPost]
    public IActionResult Agregar(Review review)
    {
        var userId = HttpContext.Session.GetInt32("UserId");
        var userNombre = HttpContext.Session.GetString("UserNombre");

        if (userId == null)
            return RedirectToAction("Login", "Usuario");

        review.UserId = userId.Value;
        review.NombreUser = userNombre!;

        _reviewService.AgregarReview(review);
        return RedirectToAction("Detalle", "Catalogo", new { id = review.ItemId });
    }
}