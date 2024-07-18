using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet.Context;
using dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly ItemContext _usuarioContext;
        private readonly ItemController _inventario;

        public UsuarioController(ItemContext context)
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
            if(ModelState.IsValid)
            {

            var usuarioBanco = _usuarioContext.Usuarios
            .FromSql($"SELECT * FROM Usuarios WHERE Login = {user.Login} AND Senha = {user.Senha}")
            .FirstOrDefault();
            if(usuarioBanco.Login != user.Login || usuarioBanco.Senha != user.Senha)
            {
                 ModelState.AddModelError("Senha","Favor verificar a senha");
                 return View(user);
            }
            if(usuarioBanco != null)
            {
                return RedirectToAction(nameof(_inventario.Lista), "Item");   
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