using ASTROBIT_BACKEND.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASTROBIT_BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioMoedaController : ControllerBase
    {
        private readonly Contexto db;

        public UsuarioMoedaController(Contexto contexto)
        {
            db = contexto;
        }

        [Route("Favoritar/{UsuarioId}/{MoedaId}")]
        [HttpGet]
        public MoedaResponse Favoritar(int UsuarioId, string MoedaId)
        {
            Entidades.UsuarioMoeda novo_registro = new Entidades.UsuarioMoeda();
            novo_registro.MoedaId = MoedaId;
            novo_registro.UsuarioId = UsuarioId;
            db.UsuarioMoeda.Add(novo_registro);
            db.SaveChanges();

            return new MoedaResponse { Success = "Favoritado" };
        }

        [Route("DeletarMoeda/{MoedaId}")]
        [HttpDelete]
        public MoedaResponse DeletarMoeda(string MoedaId)
        {
            db.UsuarioMoeda.Remove(
            db.UsuarioMoeda.Where(a => a.MoedaId == MoedaId).FirstOrDefault()
            );
            db.SaveChanges();
            return new MoedaResponse { Success = "Favorito removido" };
        }
    }
}
