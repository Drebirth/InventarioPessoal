using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.Models
{
    public class Usuario
    {
        /*
        public long Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        */
        private int _id;

        private string _login;
        private string _senha;

        public int Id 
        {
            get => _id;
            set => _id = value;
        }

        public string Login
        {
            get => _login;
            set => _login = value;
        }

        public string Senha
        {
            get => _senha;
            set => _senha = value;
        }

        
    }
}