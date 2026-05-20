using CatalogoApp.Domain.Models;
using CatalogoApp.Domain.Interfaces;

namespace CatalogoApp.Application.Services;

public class UserService
{
    private readonly IUserRepository _repo;

    public UserService(IUserRepository repo)
    {
        _repo = repo;
    }

    public User? Login(string email, string password)
    {
        var user = _repo.ObtenerPorEmail(email);
        if (user == null || user.Password != password)
            return null;
        return user;
    }

    public bool Registrar(User user)
    {
        if (_repo.ExisteEmail(user.Email))
            return false;
        _repo.Agregar(user);
        return true;
    }

    public User? ObtenerPorId(int id) => _repo.ObtenerPorId(id);
}