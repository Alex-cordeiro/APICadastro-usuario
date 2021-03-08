using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cadastro_Usuarios.DataContext;
using Cadastro_Usuarios.Models;
using System.Text.Json;

namespace Cadastro_Usuarios.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        
        private UsuariosContext _context;

        public UsuariosController(UsuariosContext context)
        {
            _context = context;
        }

         //GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios(string nome, string ativo)
        {
           if(nome == null && ativo == null)
            {
                return Ok(await _context.Usuarios.ToListAsync());
            }
            else
            {

                Usuario buscaUsuario = new Usuario(nome, ConverteStringParaBool(ativo));

                
                IEnumerable<Usuario> usuarioEncontrado = _context.Usuarios.Where(x => x.Ativo == buscaUsuario.Ativo).Where(x => x.Nome == buscaUsuario.Nome);

               
                var json = "";

                

                
                foreach (Usuario user in usuarioEncontrado)
                {
                    json = JsonSerializer.Serialize(usuarioEncontrado);
                }

                if(json == "")
                {
                    return NotFound("Usuário não existe ou desativado");
                }

                return Ok("Registros encontrados: " + json);
                
            }
           
        }


        //POST: API/Usuarios
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            

            Usuario Novousuario = new Usuario(usuario.Nome, usuario.Data, usuario.Email, usuario.Senha, usuario.Sexo);
            if ( usuario.Nome == null)
            {
                return BadRequest(" Erro!!!: Nome inserido como nulo ou fora do limite de caracteres requerido");
            } else if (usuario.Data == null)
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
        private bool ConverteStringParaBool(string ativo)
        {
            bool usuarioAtivo = false;

            if(ativo == "true")
            {
                return usuarioAtivo = true;
            }
            else
            {
                return usuarioAtivo;
            }
        }
    }
}
