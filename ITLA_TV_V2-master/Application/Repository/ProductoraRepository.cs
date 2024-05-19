using Database.Contexts;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class ProductoraRepository
    {
        private readonly ApplicationContext _dbcontext;

        public ProductoraRepository(ApplicationContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        //Guardar
        public async Task AddAsync(Productora productora)
        {
            await _dbcontext.AddAsync(productora);
            await _dbcontext.SaveChangesAsync();
        }

        //Actualizar
        public async Task UpdateAsync(Productora productora)
        {
            _dbcontext.Entry(productora).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
        }

        //Borrar
        public async Task DeleteAsync(Productora productora)
        {
            _dbcontext.Set<Productora>().Remove(productora);
            await _dbcontext.SaveChangesAsync();
        }

        //Buscar todas las productoras
        public async Task<List<Productora>> GetAllAsync()
        {
            return await _dbcontext.Set<Productora>().ToListAsync();
        }

        //Buscar las productoras por id
        public async Task<Productora> GetByIdAsync(int Id)
        {
            return await _dbcontext
                        .Set<Productora>()
                        .FindAsync(Id);
        }
    }
}
