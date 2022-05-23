using ASTROBIT_BACKEND.Entidades;
using ASTROBIT_BACKEND.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASTROBIT_BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly Contexto db;

        public UsuarioController(Contexto contexto)
        {
            db = contexto;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public List<Usuario> Get()
        {
            return db.USUARIO.ToList();
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public UsuarioModel Get(int id)
        {
            var usuario = db.USUARIO.Find(id);
            var favoritosUsuarios = db.UsuarioMoeda.Where(a => a.UsuarioId == id).Include(a => a.Moeda);
            UsuarioModel retorno = new UsuarioModel();
            retorno.usuario = db.USUARIO.Find(id);
            retorno.listaMoeda = db.UsuarioMoeda.Where(a => a.UsuarioId == id).Include(a => a.Moeda).ToList();
            if ( usuario == null)
            {
                return new UsuarioModel();
            }
            return retorno;
        }


        // POST api/Usuario
        [HttpPost]
        public Usuario Post(Usuario usuario)
        {      
            var Id = usuario.Id;
            var erro = "Usuario ja existe";
            var UserVerifica = db.USUARIO.Where(a => a.Login == usuario.Login);

            if(UserVerifica.Count ()> 0)
            {
                 BadRequest(erro);
            }
            else
            {
                db.USUARIO.Add(usuario);
                db.SaveChanges();
            }
            return usuario;
        }

        // PUT api/Usuario/5
        [HttpPut("{id}")]
        public  IActionResult Put(int id, [FromBody] Usuario usuario)
        {
            if(id != usuario.Id)
            {
                return BadRequest(new { Erro = "Não foi possivel alterar!" });
            }

            db.USUARIO.Update(usuario);

            try
            {
                db.SaveChanges();
            }
            catch
            {
                return BadRequest(new { Erro = "Não foi possivel salvar!" });
            }

            return Ok(new { Success = "Usuario alterado com sucesso!" });
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var remove = db.USUARIO.Find(id);
            if (remove == null)
            {
                return BadRequest(new { Erro = "Não foi possivel deletar!" });
            }

            db.USUARIO.Remove(remove);
            db.SaveChanges();

            return Ok(new { Success = "Usuario deletado com sucesso!" });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Usuario user)
        {
            var usuario = db.USUARIO.Where(a => a.Login == user.Login && a.Senha == user.Senha).FirstOrDefault();
            if(usuario == null)
            {
                return BadRequest(new { Erro = "Credenciais Invalidas" });
            }
            else
            {
                return Ok(new LoginResponse
                {
                    Success = "Logado com sucesso",
                    UsuarioId = usuario
                });
            }
        }
    }
}
