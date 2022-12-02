using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techo.Models.Models.Entities
{
    public class Zona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<Voluntario> Coordinadores { get; set; }
    }
}
