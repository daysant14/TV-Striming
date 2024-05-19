using Database.Models;

namespace Application.ViewModels
{
    public class SerieViewModel
    {
        public int? SerieId { get; set; }
        public string SerieName { get; set; }
        public string ImagePath { get; set; }
        public string VideoPath { get; set; }
        public string Descripcion { get; set; }
        public string Actores { get; set; }
        public string Director { get; set; }
        public int Año { get; set; }
        public int GeneroPrimarioId { get; set; }
        public int GeneroSecundarioId { get; set; }
        public int ProductoraId { get; set; }

        //Navigation property
        public Productora? Productora { get; set; }

        public Genero? Genero { get; set; }

        //Campos adicionales para la vista
        public virtual string GeneroPrimarioName { get; set; }
        public virtual string GeneroSecundarioName { get; set; }
        public virtual string ProductoraName { get; set; }
    }
}
