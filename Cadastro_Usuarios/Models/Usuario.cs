using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro_Usuarios.Models
{
    public class Usuario
    {
        //Atributos privados
        private string _nome;
        
        

        //Propriedades autoimplementadas
        public long Id { get;  set; }
        //public DateTime DataNascimento { get; private set; } verificar como atribuir data ao usuario
        
        public int Idade { get;  set; }
        public string Email { get;  set; }
        public string Senha { get;  set; }
        public string Sexo { get;  set; }
        public bool Ativo { get;  set; }

        //Construtores
        public Usuario()
        {

        }

        public Usuario(string nome, int idade , string email, string senha, string sexo) 
        {
            Nome = nome;
            //DataNascimento = dataNascimento; /*verificar como calcular a idade do usuario e depois incluir o parâmetro DateTime dataNascimento]
            /*valor provisório :*/
            Idade = idade;
            Ativo = true;                      
            Email = email;
            Senha = senha;
            Sexo = sexo;

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
