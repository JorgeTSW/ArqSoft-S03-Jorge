using CatalogoApp.Application.Services;
using CatalogoApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Presentation.Controllers;

public class UserController : Controller
{
    private readonly UserService _service;

    public UserController(UserService service)
    {
        _service = service;
    }

    // GET: /Usuario/Register
    public IActionResult Register() => View();

    // POST: /Usuario/Register
    [HttpPost]
    public IActionResult Register(User user)
    {
        if (_service.Registrar(user))
        {
            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("UserNombre", user.Nombre);
            return RedirectToAction("Index", "Catalogo");
        }
        ViewBag.Error = "El email ya está registrado.";
        return View();
    }

    // GET: /Usuario/Login
    public IActionResult Login() => View();

    // POST: /Usuario/Login
    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        var user = _service.Login(email, password);
        if (user != null)
        {
            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("UserNombre", user.Nombre);
            return RedirectToAction("Index", "Catalogo");
        }
        ViewBag.Error = "Email o contraseña incorrectos.";
        return View();
    }

    // GET: /Usuario/Logout
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Catalogo");
    }
}