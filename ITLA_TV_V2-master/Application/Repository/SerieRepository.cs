using Database.Contexts;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Repository
{
    public class SerieRepository
    {
        private readonly ApplicationContext _dbcontext;

        public  SerieRepository(ApplicationContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        //Guardar
        public async Task AddAsync(Serie serie)
        {
            await _dbcontext.AddAsync(serie);
            await _dbcontext.SaveChangesAsync();
        }

        //Actualizar
        public async Task UpdateAsync(Serie serie)
        {
            _dbcontext.Entry(serie).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
        }

        //Borrar
        public async Task DeleteAsync(Serie serie)
        {
            _dbcontext.Set<Serie>().Remove(serie);
            await _dbcontext.SaveChangesAsync();
        }

        //Buscar todas las series
        public async Task<List<Serie>> GetAllAsync()
        {
            return await _dbcontext.Set<Serie>().ToListAsync();
        }

        //Buscar las series por id
        public async Task<Serie> GetByIdAsync(int id)
        {
            return await _dbcontext.Set<Serie>().FindAsync(id);
        }
    }
}
