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
        public string Data { get;  set; }
        public string Email { get;   set; }
        public string Senha { get;   set; }
        public string Sexo { get;  set; }
        public bool Ativo { get;   set; }
        public int Idade { get;  set; }
        private DateTime DataNascimentoDate;
        //Construtores
        public Usuario()
        {

        }

        public Usuario(string nome, string dataNascimento , string email, string senha, string sexo) 
        {
            Nome = nome;
            Data = dataNascimento;
            Idade = calculaIdade(Data);
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
        
        public int calculaIdade( string dataNascimento)
        {
            
             DataNascimentoDate = DateTime.Parse(dataNascimento);

            if(DateTime.Now < DataNascimentoDate)
            {
                return Idade = 0;
            }
            else
            {
                Idade = DateTime.Now.Year - DataNascimentoDate.Year  ;
                if(DateTime.Now.DayOfYear < DataNascimentoDate.DayOfYear)
                {
                    Idade = Idade - 1;
                }
                return Idade;
            }
        }
            
        
       


    }
}
