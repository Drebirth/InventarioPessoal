using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.Models
{
    public class Item
    {   
        private int _id;
        private string _nome;
        private string _descricao;
        private int _quantidade;

        public Item(int id, string nome, string descricao, int quantidade)
        {   
            //usuario.Id = id;
            _id = id;
            _nome = nome;
            _descricao = descricao;
            _quantidade = quantidade;
        }

        public Item(){}

        public Usuario usuario
        {
            get; set;
        }

        public int Id 
        { get => _id;
          set => _id = value;
        }

     
        public string Nome 
        { 
            get => _nome; set => _nome = value;
            // get{ return _nome; }
            // set{ _nome = value; }
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