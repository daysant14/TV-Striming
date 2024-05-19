using Application.Services;
using Application.ViewModels;
using Database.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace ITLA_TV_PLUS.Controllers
{
    public class GeneroController : Controller
    {
        private readonly Application.Services.GeneroService _generoService;
        private readonly Database.Contexts.ApplicationContext _context;

        public GeneroController(ApplicationContext dbContext)
        {
            _generoService = new GeneroService(dbContext);
            _context = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Generos = _generoService.GetGeneros();
            return View(await _generoService.GetAllViewModel());
        }

        public IActionResult Create()
        {
            return View("MantenimientoGenero", new SaveGeneroViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveGeneroViewModel vm)
        {
            if (ModelState.IsValid)
            {
                return View("MantenimientoGenero", vm);
            }

            await _generoService.Add(vm);
            return RedirectToAction("Index");
            
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("MantenimientoGenero", await _generoService.GetByIdSaveGeneroModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveGeneroViewModel vm)
        {
            if (ModelState.IsValid)
            {
                return View("MantenimientoGenero", vm);
            }

            await _generoService.Update(vm);
            return RedirectToAction("Index");

        }


        public async Task<IActionResult> Delete(int id)
        {
            return View(await _generoService.GetByIdSaveGeneroModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _generoService.Delete(id);
            return RedirectToRoute(new { controller = "Genero", action = "Index" });
        }
    }
}
