using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet.Context;
using dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;


namespace dotnet.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly InventarioContext _usuarioContext;
        private readonly ItemController _inventario;

        public UsuarioController(InventarioContext context)
        {
            _usuarioContext = context;
            
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario user)
        {  

            var usuarioBanco = _usuarioContext.Usuarios
            .FromSql($"SELECT * FROM Usuarios WHERE Login = {user.Login} AND Senha = {user.Senha}")
            .FirstOrDefault();

            if(ModelState.IsValid)
            {
                // if(user.Equals(Empty) || user.Equals(null))
                // {
                //     ModelState.AddModelError("Senha","teste vazio ou nulo");
                //     return View(user);
                // }
            
            if(usuarioBanco != null)
            {
                return RedirectToAction(nameof(_inventario.Lista), "Item");   
            }
            if(usuarioBanco == null ){
                ModelState.AddModelError("Senha","Login ou Senha é inválida, favor verificar os campos!");
                return View(user);
            }
            
            
           }
            
            return View(user);
        }

        public IActionResult CadastroUsuario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastroUsuario(Usuario usuario)
        {
            if(ModelState.IsValid)
            {
                _usuarioContext.Usuarios.Add(usuario);
                _usuarioContext.SaveChanges();
                return RedirectToAction(nameof(Login));
            }
            return View(usuario);
        }
    }
}