using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class LoginViewModel
    {
        public int Id { get; set; }

        [Required]
        public string NombreUsuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }


        public List<UsuarioViewModel> ListaUsuariosViewModel { get; set; }



    }
}
