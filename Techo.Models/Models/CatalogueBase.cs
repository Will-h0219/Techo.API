using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techo.Models.Models
{
    public abstract class CatalogueBase
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
