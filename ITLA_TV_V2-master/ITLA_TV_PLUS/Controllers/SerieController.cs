using Application.Services;
using Application.ViewModels;
using Database.Contexts;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ITLA_TV_PLUS.Controllers
{
    public class SerieController : Controller
    {
        private readonly SerieService _serieService;

        public SerieController(ApplicationContext dbContext)
        {
            _serieService = new SerieService(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            var serieDetails = _serieService.GetAllSeriesDetails();

            return View(serieDetails);
        }

        public IActionResult Create()
        {
            ViewBag.GenerosViewModel = _serieService.GetGenerosViewModel();
            ViewBag.ProductoraViewModel = _serieService.GetProductorasViewModel();

            return View("MantenimientoSerie", new SaveSerieViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveSerieViewModel vm)
        {
            if (ModelState.IsValid)
            {
                return View("MantenimientoSerie", vm);
            }

            await _serieService.Add(vm);
            return RedirectToRoute(new {controller = "Serie", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.GenerosViewModel = _serieService.GetGenerosViewModel();
            ViewBag.ProductoraViewModel = _serieService.GetProductorasViewModel();

            return View("MantenimientoSerie",await _serieService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveSerieViewModel vm)
        {
            if (ModelState.IsValid)
            {
                return View("MantenimientoSerie", vm);
            }

            ViewBag.GenerosViewModel = _serieService.GetGenerosViewModel();
            ViewBag.ProductoraViewModel = _serieService.GetProductorasViewModel();

            await _serieService.Update(vm);
            return RedirectToRoute(new { controller = "Serie", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _serieService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _serieService.Delete(id);
            return RedirectToRoute(new { controller = "Serie", action = "Index" });
        }
    }
}
