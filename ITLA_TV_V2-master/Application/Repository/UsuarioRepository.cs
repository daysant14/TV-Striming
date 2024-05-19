using Application.ViewModels;
using Database.Contexts;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Application.Repository
{
    public class UsuarioRepository
    {
        private readonly ApplicationContext _dbcontext;

        public UsuarioRepository(ApplicationContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public async Task AddAsync(Usuario usuario)
        {
            await _dbcontext.AddAsync(usuario);
            await _dbcontext.SaveChangesAsync();
        }



        public async Task UdapteAsync(UsuarioViewModel usuario)
        {
            _dbcontext.Entry(usuario).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(UsuarioViewModel usuario)
        {
            _dbcontext.Set<UsuarioViewModel>().Remove(usuario);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _dbcontext.Set<Usuario>().ToListAsync();
        }

        public async Task<UsuarioViewModel> GetByIdAsync(int id)
        {
            return await _dbcontext.Set<UsuarioViewModel>().FindAsync(id);

        }
    }
}
