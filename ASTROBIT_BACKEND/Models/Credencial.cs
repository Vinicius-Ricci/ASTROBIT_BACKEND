using ASTROBIT_BACKEND.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASTROBIT_BACKEND.Models
{
    public class Credencial
    {
        public Usuario Login { get; set; }
        public Usuario Senha { get; set; }
    }
}
