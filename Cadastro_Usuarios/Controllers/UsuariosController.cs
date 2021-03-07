using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cadastro_Usuarios.DataContext;
using Cadastro_Usuarios.Models;

namespace Cadastro_Usuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        //private readonly UsuariosContext _context;
        private UsuariosContext _context;

        public UsuariosController(UsuariosContext context)
        {
            _context = context;
        }

         //GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
           
           return await _context.Usuarios.ToListAsync();
        }
        
       
        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(long id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(long id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
              _context.Usuarios.Add(usuario);
              await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
           
        }*/

        //POST: API/Usuarios
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
           
            Usuario Novousuario = new Usuario(usuario.Nome, usuario.Idade, usuario.Email, usuario.Senha, usuario.Sexo);
            if ( usuario.Nome == null)
            {
                return BadRequest(" Erro!!!: Nome inserido como nulo ou fora do limite de caracteres requerido");
            } else if (usuario.Idade == null || usuario.Idade == 0)
            {
                return BadRequest("Erro!!!: A idade foi definida como nula ou como zerada, insira uma idade válida!!");
            }
            else if (usuario.Email == null)
            {
                return BadRequest("Erro!!!: O endereço de email foi definido como nulo, insira um endereço de email válido!!");
            }
            else if (usuario.Senha == null)
            {
                return BadRequest("Erro!!!: A senha foi definida como nula, insira uma senha válida!!!");
            }
            else if (usuario.Sexo == null)
            {
                return BadRequest("Erro!!!: O genero não foi definido!");
            }
            else
            {
                //Novousuario.Ativo = true;  

                _context.Usuarios.Add(Novousuario);
                await _context.SaveChangesAsync();
                return Ok("Id do novo usuário "+ Novousuario.Id);
            }
           
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(long id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(long id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
