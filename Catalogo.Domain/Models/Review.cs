namespace CatalogoApp.Domain.Models;

public class Review
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public int UserId { get; set; }
    public string NombreUser { get; set; } = string.Empty;
    public string Comentario { get; set; } = string.Empty;
    public int Rating { get; set; } // 1 a 5
}