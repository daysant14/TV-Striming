using Database.Contexts;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class GeneroRepository
    {
        private readonly ApplicationContext _dbcontext;

        public GeneroRepository(ApplicationContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        //Guardar
        public async Task AddAsync(Genero genero)
        {
            await _dbcontext.AddAsync(genero);
            await _dbcontext.SaveChangesAsync();
        }

        //Actualizar
        public async Task UpdateAsync(Genero genero)
        {
            _dbcontext.Entry(genero).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
        }

        //Borrar
        public async Task DeleteAsync(Genero genero)
        {
            _dbcontext.Set<Genero>().Remove(genero);
            await _dbcontext.SaveChangesAsync();
        }

        //Buscar todos los generos
        public async Task<List<Genero>> GetAllAsync()
        {
            return await _dbcontext.Set<Genero>().ToListAsync();
        }

        //Buscar los generos por id
        public async Task<Genero> GetByIdAsync(int id)
        {
            return await _dbcontext
                        .Set<Genero>()
                        .FindAsync(id);
        }
    }
}
