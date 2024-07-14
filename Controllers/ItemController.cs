using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet.Context;
using dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace dotnet.Controllers
{
    public class ItemController : Controller
    {
        private readonly ItemContext _context;

        public ItemController(ItemContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Lista()
        {
            var itens = _context.Itens.ToList();
            return View(itens);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Item item)
        {
         if(ModelState.IsValid){

            if(item.Quantidade < 1)
            {
                ModelState.AddModelError("Quantidade","O campo quantidade não pode ser menor que 1");
                return View(item);
            }

            if(item.Nome.Length < 2 )
            {
                ModelState.AddModelError("Nome","Nome não pode ser vazio!");
                return View(item);
            }
             
               _context.Itens.Add(item);
               _context.SaveChanges();
               return RedirectToAction(nameof(Index));
         }   
           
            return View(item);
        }

        
        public IActionResult Editar(int id)
        {
            var item = _context.Itens.Find(id);
            if(item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult Editar(Item item)
        {
            var itemAtt = _context.Itens.Find(item.Id);

            if(ModelState.IsValid)
            {

                if(item.Quantidade < 1)
            {
                ModelState.AddModelError("Quantidade","O campo quantidade não pode ser menor que 1");
                return View(item);
            }

                if(item.Nome.Length < 2 )
            {
                ModelState.AddModelError("Nome","Nome não pode ser vazio!");
                return View(item);
            }
            itemAtt.Nome = item.Nome;
            itemAtt.Descricao = item.Descricao;
            itemAtt.Quantidade = item.Quantidade;

            _context.Itens.Update(itemAtt);
            _context.SaveChanges();
            
            return RedirectToAction(nameof(Lista));
            }
            return View(item);

        }

         public IActionResult Excluir(int id)
         {
           var item=  _context.Itens.Find(id);
            if(id == null)
            {
                return NotFound();
            }
             return View(item);
        }

        [HttpPost]
        public IActionResult Excluir(Item item)
        {
            var itemEX = _context.Itens.Find(item.Id);
            _context.Itens.Remove(itemEX);
            _context.SaveChanges();

            return RedirectToAction(nameof(Lista));
        }
    }
}