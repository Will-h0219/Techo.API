﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techo.Models.Models;

namespace Techo.Models.DataTransferObjects.CataloguesDTO
{
    public class ComunidadDTO : CatalogueBase
    {
        public string NombreComuna { get; set; }
        public ZonaDTO Zona { get; set; }
    }
}
