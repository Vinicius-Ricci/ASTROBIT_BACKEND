using ASTROBIT_BACKEND.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASTROBIT_BACKEND.Models
{
    public class UsuarioModel
    {
        public Usuario usuario { get; set; }
        public List<UsuarioMoeda> listaMoeda {get; set; }
    }
}
