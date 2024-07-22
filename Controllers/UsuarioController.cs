using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet.Context;
using dotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
        public IActionResult Login(Usuario usuario)
        {  
            
             var usuarioBanco = _usuarioContext.Usuarios
            .FromSql($"SELECT * FROM USUARIOS WHERE Login = {usuario.Login} AND Senha = {usuario.Senha}").FirstOrDefault();
            
            if(usuarioBanco != null)
            {
                usuario = usuarioBanco;
                //return RedirectToAction(nameof(_inventario.Lista),"Item");
                return RedirectToAction("Criar","Item",new {id = usuario.Id});
               
            }
            else
            {
                ModelState.AddModelError("Senha","Usuario nao encontrado");
                return View(usuario);
            }              
            
        }

        public IActionResult CadastroUsuario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastroUsuario(Usuario usuario)
        {
           var verificacao = _usuarioContext.Usuarios
           .FromSql($"SELECT * FROM USUARIOS WHERE Login = {usuario.Login}").FirstOrDefault();
           if(verificacao == null)
           {
                _usuarioContext.Usuarios.Add(usuario);
                _usuarioContext.SaveChanges();
                return RedirectToAction(nameof(Login));
           }
           else
           {
            ModelState.AddModelError("Senha","Usuario já cadastro");
           }
            return View(usuario);
        }
    }
}