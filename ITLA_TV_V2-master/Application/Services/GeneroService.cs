using Application.Repository;
using Application.ViewModels;
using Database.Contexts;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GeneroService
    {
        private readonly GeneroRepository _generoRepository;
        private readonly ApplicationContext _context;

        public GeneroService(ApplicationContext dbcontext)
        {
            _generoRepository = new(dbcontext);
            _context  = dbcontext;
        }

        public async Task<List<GeneroViewModel>> GetAllViewModel()
        {
            var generosList = await _generoRepository.GetAllAsync();

            return generosList.Select(x => new GeneroViewModel
            {
                GeneroId = x.GeneroId,
                GeneroName = x.GeneroName
            }).ToList();
        }

        public List<GeneroViewModel> GetGeneros()
        {
            return _context.Generos.Select(g => new GeneroViewModel
            {
                GeneroId = g.GeneroId,
                GeneroName = g.GeneroName
            }).ToList();
        }


        //Metodo para agregar un registro
        public async Task Add(SaveGeneroViewModel vm)
        {
            Genero genero = new();
            genero.GeneroId = vm.GeneroId;
            genero.GeneroName = vm.GeneroName;

            await _generoRepository.AddAsync(genero);
        }

        //Metodo para actualizar los registros
        public async Task Update(SaveGeneroViewModel vm)
        {
            Genero genero = new();
            genero.GeneroId = vm.GeneroId;
            genero.GeneroName = vm.GeneroName;

            await _generoRepository.UpdateAsync(genero);
        }

        //Metodo DELETE
        public async Task Delete(int id)
        {
            // Obtén la serie por su ID
            var genero = await _generoRepository.GetByIdAsync(id);
            await _generoRepository.DeleteAsync(genero);
        }

        //Obtener los metodos por su id
        public async Task<SaveGeneroViewModel> GetByIdSaveGeneroModel(int id)
        {
            var generosDetails = await _generoRepository.GetByIdAsync(id);

            SaveGeneroViewModel genero = new();
            genero.GeneroId = generosDetails.GeneroId;
            genero.GeneroName = generosDetails.GeneroName;

            return genero;
        }
    }
}
