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
            
            if(item.Quantidade < 1)
            {
                ModelState.AddModelError("Quantidade","O campo quantidade não pode ser menor que 1");
                return View(item);
            }
            
            if(ModelState.IsValid)
            {
               _context.Itens.Add(item);
               _context.SaveChanges();
               return RedirectToAction(nameof(Index));
            }
            return View(item);
        }
    }
}