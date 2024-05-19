using Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class SaveProductoraViewModel
    {
        public int ProductoraId { get; set; }
        public string ProductoraName { get; set; }
        [Required(ErrorMessage = "Debe ingresar el nombre de la productora.")]

        //Navigation property
        public ICollection<Serie>? Series { get; set; }
    }
}
