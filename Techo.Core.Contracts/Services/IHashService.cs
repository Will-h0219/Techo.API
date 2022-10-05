using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techo.Models.Models;

namespace Techo.Core.Contracts.Services
{
    public interface IHashService
    {
        ResultadoHash Hash(string textoPlano);
        ResultadoHash Hash(string textoPlano, byte[] sal);
    }
}
