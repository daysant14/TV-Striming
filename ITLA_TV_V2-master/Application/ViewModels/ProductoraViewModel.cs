using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class ProductoraViewModel
    {
        public int ProductoraId { get; set; }
        public string ProductoraName { get; set; }

        //Navigation property
        public ICollection<Serie>? Series { get; set; }
    }
}
