using Database.Models;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class SaveSerieViewModel
    {
        public int SerieId { get; set; }
        public string SerieName { get; set; }
        [Required(ErrorMessage = "Coloque el nombre de la serie.")]

        public string ImagePath { get; set; }
        [Required(ErrorMessage = "Coloque el link de la imagen de la serie.")]

        public string VideoPath { get; set; }
        [Required(ErrorMessage = "Coloque el link del video de la serie.")]

        public string Descripcion { get; set; }
        public string Actores { get; set; }
        [Required(ErrorMessage = "Coloque el nombre del actor.")]
        public string Director { get; set; }
        [Required(ErrorMessage = "Coloque el nombre de la Director.")]
        public int Año { get; set; }
        [Required(ErrorMessage = "Coloque el año.")]

        public int GeneroPrimarioId { get; set; }
        [Required(ErrorMessage = "Coloque el genero de la serie.")]

        public int GeneroSecundarioId { get; set; }

        public int ProductoraId { get; set; }
        [Required(ErrorMessage = "Coloque la productora de la serie.")]

        //Foreign keys
        public Productora? Productora { get; set; }

        public Genero? Genero { get; set; }

        //Campos adicionales para las vistas
        public virtual string GeneroPrimarioName { get; set; }
        public virtual string GeneroSecundarioName { get; set; }
        public virtual string ProductoraName { get; set; }
    }
}
