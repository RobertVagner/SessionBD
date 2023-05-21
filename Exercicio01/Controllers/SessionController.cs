using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercicio01.Models;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;

namespace Exercicio01.Controllers
{
    public class SessionController : Controller
    {
        private static IList<Usuario> usuarios = new List<Usuario>();
        public IActionResult Index()
        {
            var acesso = HttpContext.Session.GetString("usuario_session");
            if(acesso != null)
                return View(usuarios);
            return View("Login");
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(Usuario usuario)
        {
            usuarios.Add(usuario);
            usuario.UsuarioID = usuarios.Select(u => u.UsuarioID).Max() + 1;
            return RedirectToAction("Index");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login(string email, string senha)
        {
            var confirma = usuarios.Where(u => u.Email.Equals(email) && u.Senha.Equals(senha)).FirstOrDefault();
            if (confirma != null)
            {
                HttpContext.Session.SetString("usuario_session", confirma.Nome);
                return RedirectToAction("Correto");
            }
            else
            {
                return RedirectToAction("Login");
            }      
        }
        public IActionResult Correto()
        {
            return View();
        }
    }
}
