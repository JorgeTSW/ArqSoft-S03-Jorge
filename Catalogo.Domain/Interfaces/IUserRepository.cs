using Catalogo.Domain.Models;

namespace Catalogo.Domain.Interfaces;

public interface IUserRepository
{
    User? ObtenerPorEmail(string email);
    User? ObtenerPorId(int id);
    void Agregar(User user);
    bool ExisteEmail(string email);
}