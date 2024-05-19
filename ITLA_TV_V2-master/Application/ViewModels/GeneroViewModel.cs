using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class GeneroViewModel
    {
        public int GeneroId { get; set; }
        public string GeneroName { get; set; }

        //Navigation property
        public ICollection<Serie>? Series { get; set; }
    }
}
