using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ITLA_TV_PLUS.Models;
using Application.Services;
using Application.ViewModels;
using Database.Contexts;

public class CuentaController : Controller
{
    private readonly UsuarioService _serieservicio;

    public CuentaController(ApplicationContext dbContext)
    {
        _serieservicio = new UsuarioService(dbContext);
    }

    public async Task<IActionResult> Index()
    {
        return View(await _serieservicio.GetAllViewModel());
    }

    public IActionResult Create()
    {
        return View("Index", new LoginViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Create(LoginViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            return View("Index", vm);
        }

        await _serieservicio.Add(vm);
        return RedirectToRoute(new { controller = "Cuenta", action = "Index" });
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel vm)
    {
        return RedirectToAction("Index", "Home");
    }


    [HttpPost]
    public async Task<IActionResult> DeletePost(int id)
    {
        await _serieservicio.Delete(id);
        return RedirectToRoute(new { controller = "Cuenta", action = "Index" });
    }
}
