using Application.Services;
using Application.ViewModels;
using Database.Contexts;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace ITLA_TV_PLUS.Controllers
{
    public class HomeController : Controller
    {
        private readonly SerieService _serieService;
        private readonly ApplicationContext _context;
        private readonly SaveSerieViewModel _saveSerieViewModel;
        SaveGeneroViewModel genero1 = new();
        SaveGeneroViewModel genero2 = new();

        public HomeController(ApplicationContext dbContext)
        {
            _serieService = new SerieService(dbContext);
            _context = dbContext;
        }

        public  async Task<IActionResult>  Index(string FiltroSerie,string FiltroGenero,string FiltroProduc)
        {
            ViewBag.SeriesViewModel = _serieService.GetSeriesViewModel(); //Con esto envio un listado de series a mi vista
            ViewBag.GenerosViewModel = _serieService.GetGenerosViewModel();//Con esto envio un listado de generos a mi vista
            ViewBag.ProductoraViewModel = _serieService.GetProductorasViewModel();//Con esto envio un listado de productoras a mi vista

            //Condicionales para los filtros
            if (FiltroSerie != null)
            {
                return View(_serieService.GetSeriesFiltradas(FiltroSerie).ToList());
            }
            else if (FiltroGenero != null)
            {
                return View(_serieService.GetGenerosFiltradas(FiltroGenero).ToList());
            }
            else if (FiltroProduc != null)
            {
                return View(_serieService.GetProducFiltradas(FiltroProduc).ToList());
            }
            var serieDetails = _serieService.GetAllSeriesDetails();
            return View(serieDetails);
            
        }

        public async Task<IActionResult> SeriesDetails(int id)
        {
            return View(await _serieService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> SeriesPost(int id)
        {
            await _serieService.GetByIdSaveViewModel(id);
            return RedirectToRoute(new { controller = "Home", action = "SeriesDetails" });
        }
    }
}