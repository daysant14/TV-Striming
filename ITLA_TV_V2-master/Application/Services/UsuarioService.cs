using Application.Repository;
using Application.ViewModels;
using Database.Contexts;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Application.Services
{
    public class UsuarioService
    {

        private readonly UsuarioRepository _repositorio;

        public UsuarioService(ApplicationContext dbContext)
        {
            _repositorio = new(dbContext);
        }

        public async Task update(LoginViewModel vm)
        {
            UsuarioViewModel usuario = new();
            usuario.Id = vm.Id;
            usuario.NombreUsuario = vm.NombreUsuario;
            usuario.Contraseña = vm.Contraseña;
      



            await _repositorio.UdapteAsync(usuario);
        }

        public async Task Delete(int id)
        {
            var product = await _repositorio.GetByIdAsync(id);
            await _repositorio.DeleteAsync(product);
        }

        public async Task Add(LoginViewModel vm)
        {
            Usuario usuario = new();
            usuario.Id = vm.Id;
            usuario.NombreUsuario = vm.NombreUsuario;
            usuario.Contraseña = vm.Contraseña;


            await _repositorio.AddAsync(usuario);
        }




        public async Task<LoginViewModel> GetAllViewModel()
        {
            var listaUsuarios = await _repositorio.GetAllAsync();
            var modelo = new LoginViewModel();
            modelo.ListaUsuariosViewModel = listaUsuarios.Select(usuario => new UsuarioViewModel
            {
                NombreUsuario = usuario.NombreUsuario,
                Contraseña = usuario.Contraseña,
                Id = usuario.Id,
            }).ToList();
            return modelo;
        }



        public async Task<LoginViewModel> GetByIdSaOveViewModel(int id)
        {
            var usuario = await _repositorio.GetByIdAsync(id);
            LoginViewModel vm = new();
            vm.Id = usuario.Id;
            vm.NombreUsuario = usuario.NombreUsuario;
            vm.Contraseña = usuario.Contraseña;
          


            return vm;
        }



    }
}


