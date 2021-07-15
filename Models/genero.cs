using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class Genero
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public ICollection<Peli> Peli { get; set; }
    }
}
