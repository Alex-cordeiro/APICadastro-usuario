using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cadastro_Usuarios.Models
{
    
    public class Usuario
    {
        //Atributos privados
        private string _nome;
        
        
       
        //Propriedades autoimplementadas
        public long Id { get;  set; }
        public DateTime DataNascimento { get; private set; } 
     
        //public int Idade { get;  set; }
     
        public string Email { get;  set; }

        
        public string Senha { get;  set; }
       
        public string Sexo { get;  set; }
       
        public bool Ativo { get;  set; }

        //Construtores
        public Usuario()
        {

        }

        public Usuario(string nome, string dataNascimento , string email, string senha, string sexo) 
        {
            Nome = nome;
            DataNascimento = DateTime.Parse(dataNascimento); 
            Ativo = true;                      
            Email = email;
            Senha = senha;
            Sexo = sexo;

        }

        public Usuario(string nome, bool ativo)
        {
            Nome = nome;
            Ativo = ativo;
        }

        public Usuario(Usuario usuario)
        {
            Nome = usuario.Nome;
        }


         public String Nome {
            get { return _nome; }
            
            set{
                if (value == null || value.Length < 3)
                {
                    _nome = null;
                }else
                {
                    _nome = value;
                }
            } 
        }


        public (long, String) UsuarioCadastrado() => (Id, Nome);
        

            
        
       


    }
}
