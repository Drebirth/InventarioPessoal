using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.Models
{
    public class Item
    {   
        private string _nome;
        private string _descricao;
        private int _quantidade;

        public Item(string nome, string descricao, int quantidade)
        {
            _nome = nome;
            _descricao = descricao;
            _quantidade = quantidade;
        }

        public Item(){}
        public int Id { get; set;}
        public string Nome 
        { 
            get{ return _nome; }
            set{ _nome = value; }
        }

        public string Descricao 
        { 
            get => _descricao; 
            set => _descricao = value;
        }
        public int Quantidade 
        { 
            get => _quantidade; set => _quantidade = value; 
        }

    }
}