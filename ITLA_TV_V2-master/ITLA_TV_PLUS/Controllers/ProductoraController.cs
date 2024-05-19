using Application.Services;
using Application.ViewModels;
using Database.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace ITLA_TV_PLUS.Controllers
{
    public class ProductoraController : Controller
    {
        private readonly Application.Services.ProductoraService _productoraService;
        private readonly Database.Contexts.ApplicationContext _context;

        public ProductoraController(ApplicationContext dbContext)
        {
            _productoraService = new ProductoraService(dbContext);
            _context = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Productoras = _productoraService.GetProductoras();
            return View(await _productoraService.GetAllViewModel());
        }

        public IActionResult Create()
        {
            return View("MantenimientoProductora", new SaveProductoraViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveProductoraViewModel vm)
        {
            if (ModelState.IsValid)
            {
                return View("MantenimientoProductora", vm);
            }

            await _productoraService.Add(vm);
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("MantenimientoProductora", await _productoraService.GetByIdSaveProductoraModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveProductoraViewModel vm)
        {
            if (ModelState.IsValid)
            {
                return View("MantenimientoProductora", vm);
            }

            await _productoraService.Update(vm);
            return RedirectToAction("Index");

        }


        public async Task<IActionResult> Delete(int id)
        {
            return View(await _productoraService.GetByIdSaveProductoraModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _productoraService.Delete(id);
            return RedirectToRoute(new { controller = "Productora", action = "Index" });
        }
    }
}
