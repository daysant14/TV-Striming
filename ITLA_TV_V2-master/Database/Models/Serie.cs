using Database.Contexts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Serie
    {
        public int SerieId { get; set; }
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

        //Foreign keys
        public Productora? Productora { get; set; }

        public Genero? Genero { get; set; }

    }
}
