using Application.Repository;
using Application.ViewModels;
using Database.Contexts;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ProductoraService
    {
        private readonly ProductoraRepository _productoraRepository;
        private readonly ApplicationContext _context;

        public ProductoraService(ApplicationContext dbcontext)
        {
            _productoraRepository = new(dbcontext);
            _context = dbcontext;
        }

        public async Task<List<ProductoraViewModel>> GetAllViewModel()
        {
            var serieslist = await _productoraRepository.GetAllAsync();

            return serieslist.Select(x => new ProductoraViewModel
            {
                ProductoraId = x.ProductoraId,
                ProductoraName = x.ProductoraName
            }).ToList();
        }

        public List<ProductoraViewModel> GetProductoras()
        {
            return _context.Productoras.Select(x => new ProductoraViewModel
            {
                ProductoraId = x.ProductoraId,
                ProductoraName = x.ProductoraName
            }).ToList();
        }


        //Metodo para agregar un registro
        public async Task Add(SaveProductoraViewModel vm)
        {
            Productora productora = new();
            productora.ProductoraId = vm.ProductoraId;
            productora.ProductoraName = vm.ProductoraName;

            await _productoraRepository.AddAsync(productora);
        }

        //Metodo para actualizar los registros
        public async Task Update(SaveProductoraViewModel vm)
        {
            Productora productora = new();
            productora.ProductoraId = vm.ProductoraId;
            productora.ProductoraName = vm.ProductoraName;

            await _productoraRepository.UpdateAsync(productora);
        }

        //Metodo DELETE
        public async Task Delete(int id)
        {
            // Obtén la serie por su ID
            var productora = await _productoraRepository.GetByIdAsync(id);
            await _productoraRepository.DeleteAsync(productora);
        }

        //Obtener los metodos por su id
        public async Task<SaveProductoraViewModel> GetByIdSaveProductoraModel(int id)
        {
            var prodDetails = await _productoraRepository.GetByIdAsync(id);

            SaveProductoraViewModel productora = new();
            productora.ProductoraId = prodDetails.ProductoraId;
            productora.ProductoraName = prodDetails.ProductoraName;

            return productora;
        }
    }
}
