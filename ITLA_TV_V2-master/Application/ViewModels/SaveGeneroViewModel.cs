using Database.Models;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class SaveGeneroViewModel
    {
        public int GeneroId { get; set; }
        public string GeneroName { get; set; }
        [Required (ErrorMessage = "Debe ingresar el nombre del genero.")]

        //Navigation property
        public ICollection<Serie>? Series { get; set; }
    }
}
