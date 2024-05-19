using Application.Repository;
using Application.ViewModels;
using Database.Models;
using Database.Contexts;
using System.Linq.Dynamic.Core;

namespace Application.Services
{
    public class SerieService
    {
        private readonly SerieRepository _serieRepository;
        private readonly ApplicationContext _context;


        public SerieService(ApplicationContext dbcontext)
        {
            _context = dbcontext;
            _serieRepository = new(dbcontext);
        }

        //Metodo para obtener todos los datos relacionados a una serie
        public List<SerieViewModel> GetAllSeriesDetails()
        {
            var seriesDetails = (from s in _context.Series
                                 join g in _context.Generos on s.GeneroPrimarioId equals g.GeneroId
                                 join g2 in _context.Generos on s.GeneroSecundarioId equals g2.GeneroId
                                 join p in _context.Productoras on s.ProductoraId equals p.ProductoraId
                                 select new SerieViewModel
                                 {
                                     SerieId = s.SerieId,
                                     SerieName = s.SerieName,
                                     ImagePath = s.ImagePath,
                                     VideoPath = s.VideoPath,
                                     Descripcion = s.Descripcion,
                                     Actores = s.Actores,
                                     Director = s.Director,
                                     Año = s.Año,
                                     GeneroPrimarioName = g.GeneroName,
                                     GeneroSecundarioName = g2.GeneroName,
                                     ProductoraName = p.ProductoraName
                                 }).ToList();

            return seriesDetails;
        }

        //Metodo para obtener el id y el nombre de las series, se utiliza en los filtros
        public List<SerieViewModel> GetSeriesFiltradas(string FiltroSerie)
        {
            var seriesDetails = (from s in _context.Series
                                 join g in _context.Generos on s.GeneroPrimarioId equals g.GeneroId
                                 join g2 in _context.Generos on s.GeneroSecundarioId equals g2.GeneroId
                                 join p in _context.Productoras on s.ProductoraId equals p.ProductoraId
                                 select new SerieViewModel
                                 {
                                     SerieId = s.SerieId,
                                     SerieName = s.SerieName,
                                     ImagePath = s.ImagePath,
                                     VideoPath = s.VideoPath,
                                     Descripcion = s.Descripcion,
                                     Actores = s.Actores,
                                     Director = s.Director,
                                     Año = s.Año,
                                     GeneroPrimarioName = g.GeneroName,
                                     GeneroSecundarioName = g2.GeneroName,
                                     ProductoraName = p.ProductoraName
                                 }).Where(s => s.SerieName == FiltroSerie)
                                 .ToList();

            return seriesDetails;
        }

        //Metodo para obtener el id y el nombre de los generos, se utiliza en los filtros
        public List<SerieViewModel> GetGenerosFiltradas(string FiltroGenero)
        {
            var generosDetails = (from s in _context.Series
                                  join g in _context.Generos on s.GeneroPrimarioId equals g.GeneroId
                                  join g2 in _context.Generos on s.GeneroSecundarioId equals g2.GeneroId
                                  join p in _context.Productoras on s.ProductoraId equals p.ProductoraId
                                  select new SerieViewModel
                                 {
                                     SerieId = s.SerieId,
                                     SerieName = s.SerieName,
                                     ImagePath = s.ImagePath,
                                     VideoPath = s.VideoPath,
                                     Descripcion = s.Descripcion,
                                     Actores = s.Actores,
                                     Director = s.Director,
                                     Año = s.Año,
                                     GeneroPrimarioName = g.GeneroName,
                                     GeneroSecundarioName = g2.GeneroName,
                                     ProductoraName = p.ProductoraName
                                 }).Where(g => g.GeneroPrimarioName == FiltroGenero || g.GeneroSecundarioName == FiltroGenero)
                                 .ToList();

            return generosDetails;
        }

        //Metodo para obtener el id y el nombre de las productoras, se utiliza en los filtros
        public List<SerieViewModel> GetProducFiltradas(string FiltroProduc)
        {
            var producDetails = (from s in _context.Series
                                 join g in _context.Generos on s.GeneroPrimarioId equals g.GeneroId
                                 join g2 in _context.Generos on s.GeneroSecundarioId equals g2.GeneroId
                                 join p in _context.Productoras on s.ProductoraId equals p.ProductoraId
                                 select new SerieViewModel
                                  {
                                     SerieId = s.SerieId,
                                     SerieName = s.SerieName,
                                     ImagePath = s.ImagePath,
                                     VideoPath = s.VideoPath,
                                     Descripcion = s.Descripcion,
                                     Actores = s.Actores,
                                     Director = s.Director,
                                     Año = s.Año,
                                     GeneroPrimarioName = g.GeneroName,
                                     GeneroSecundarioName = g2.GeneroName,
                                     ProductoraName = p.ProductoraName
                                 }).Where(p => p.ProductoraName == FiltroProduc)
                                 .ToList();

            return producDetails;
        }

        //Metodo para obtener los generos, se utiliza en los dropbox
        public List<SaveSerieViewModel> GetGenerosViewModel()
        {
            return _context.Generos.Select(g => new SaveSerieViewModel  
            {
                GeneroPrimarioId = g.GeneroId,
                GeneroSecundarioId = g.GeneroId,
                GeneroPrimarioName = g.GeneroName,
                GeneroSecundarioName = g.GeneroName
            }).ToList();
        }

        //public List<SerieViewModel> GetGeneroNames()
        //{
        //    var seriesGenero = (
        //        from s in _context.Series
        //        join g1 in _context.Generos on s.GeneroPrimarioId equals g1.GeneroId
        //        join g2 in _context.Generos on s.GeneroSecundarioId equals g2.GeneroId
        //        select new SerieViewModel
        //        {
        //            SerieId = s.SerieId,
        //            SerieName = s.SerieName,
        //            ImagePath = s.ImagePath,
        //            GeneroPrimarioName = g1.GeneroName,
        //            GeneroSecundarioName = g2.GeneroName
        //        }).ToList();

        //    return seriesGenero;
        //}

        //Metodo para obtener las productoras, se utiliza en los dropbox
        public List<SaveSerieViewModel> GetProductorasViewModel()
        {
            return _context.Productoras.Select(p => new SaveSerieViewModel
            {
                ProductoraId = p.ProductoraId,
                ProductoraName = p.ProductoraName
            }).ToList();
        }

        //Metodo para obtener las series, se utiliza en los dropbox
        public List<SaveSerieViewModel> GetSeriesViewModel()
        {
            return _context.Series.Select(s => new SaveSerieViewModel
            {
                SerieId = s.SerieId,
                SerieName = s.SerieName
            }).ToList();
        }

        //Metodo para obtener los datos de una serie para editarla o borrarla
        public async Task<SaveSerieViewModel> GetByIdSaveViewModel(int id)
        {
            var seriesDetails = await _serieRepository.GetByIdAsync(id);

            SaveSerieViewModel serie = new();
            serie.SerieId = seriesDetails.SerieId;
            serie.SerieName = seriesDetails.SerieName;
            serie.ImagePath = seriesDetails.ImagePath;
            serie.VideoPath = seriesDetails.VideoPath;
            serie.Descripcion = seriesDetails.Descripcion;
            serie.Actores = seriesDetails.Actores;
            serie.Director = seriesDetails.Director;
            serie.Año = seriesDetails.Año;
            serie.GeneroPrimarioId = seriesDetails.GeneroPrimarioId;
            serie.GeneroSecundarioId = seriesDetails.GeneroSecundarioId;
            serie.ProductoraId = seriesDetails.ProductoraId;

            return serie;
        }

        //Metodo para agregar un registro, en este caso una serie
        public async Task Add(SaveSerieViewModel vm)
        {
            Serie serie = new();
            serie.SerieName = vm.SerieName;
            serie.ImagePath = vm.ImagePath;
            serie.VideoPath = vm.VideoPath;
            serie.Descripcion = vm.Descripcion;
            serie.Actores = vm.Actores;
            serie.Director = vm.Director;
            serie.Año = vm.Año;
            serie.GeneroPrimarioId = vm.GeneroPrimarioId;
            serie.GeneroSecundarioId = vm.GeneroSecundarioId;
            serie.ProductoraId = vm.ProductoraId;

            await _serieRepository.AddAsync(serie);
        }

        //Metodo para actualizar los registros
        public async Task Update(SaveSerieViewModel vm)
        {
            Serie serie = new();
            serie.SerieId = vm.SerieId;
            serie.SerieName = vm.SerieName;
            serie.ImagePath = vm.ImagePath;
            serie.VideoPath = vm.VideoPath;
            serie.Descripcion = vm.Descripcion;
            serie.Actores = vm.Actores;
            serie.Director = vm.Director;
            serie.Año = vm.Año;
            serie.GeneroPrimarioId = vm.GeneroPrimarioId;
            serie.GeneroSecundarioId = vm.GeneroSecundarioId;
            serie.ProductoraId = vm.ProductoraId;

            await _serieRepository.UpdateAsync(serie);
        }

        //Metodo eliminar registros
        public async Task Delete(int id)
        {
            var serie = await _serieRepository.GetByIdAsync(id);
            await _serieRepository.DeleteAsync(serie);
        }
    }
}
