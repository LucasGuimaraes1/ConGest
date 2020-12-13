using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PROJETO_RENATO.Dados.EntityFramework.Comum;
using PROJETO_RENATO.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PROJETO_RENATO.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly static string senhaAdm = "paodequeijo123";
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Usuario usuario)
        {
            Contexto db = new Contexto();
            List<Usuario> usuarios = db.Usuario.ToList();
            Usuario user = usuarios.Find(l => l.UsuarioAcesso == usuario.UsuarioAcesso);
            if (user != null && user.SenhaAcesso == usuario.SenhaAcesso)
            {
                return RedirectToAction("ListarCondominios", "Condominio", new { id = user.UsuarioId });
            }
            if(user != null && (user.SenhaAcesso != usuario.SenhaAcesso))
            {
                ModelState.AddModelError("SenhaAcesso", "Senha incorreta");
            }
            return View(usuario);
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario usuario)
        {
            if (usuario == null || usuario.UsuarioAcesso == null || usuario.SenhaAcesso == null || usuario.Nome == null || usuario.SenhaVerificacao == null)
            {
                return View(usuario);
            }
            if(usuario.SenhaVerificacao != senhaAdm)
            {
                ModelState.AddModelError("SenhaVerificacao", "Senha Administrativa incorreta");
                return View(usuario);
            }
            Contexto db = new Contexto();
            db.Usuario.Add(usuario);
            db.SaveChanges();
            return View("Index", usuario);
        }
    }
}
