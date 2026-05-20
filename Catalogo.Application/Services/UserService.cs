using Catalogo.Domain.Models;
using Catalogo.Domain.Interfaces;

namespace Catalogo.Application.Services;

public class UsuarioService
{
    private readonly IUserRepository _repo;

    public UsuarioService(IUserRepository repo)
    {
        _repo = repo;
    }

    public User? Login(string email, string password)
    {
        var usuario = _repo.ObtenerPorEmail(email);
        if (usuario == null || usuario.Password != password)
            return null;
        return usuario;
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