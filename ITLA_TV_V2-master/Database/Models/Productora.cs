using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Productora
    {
        public int ProductoraId { get; set; }
        public string ProductoraName { get; set; }

        //Navigation property
        public ICollection<Serie>? Series { get; set; }
    }
}
