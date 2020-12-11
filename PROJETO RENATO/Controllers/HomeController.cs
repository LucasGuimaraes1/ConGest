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

        public IActionResult Index()
        {
            return View();
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


        public IActionResult Login(Usuario usuario)
        {
            Contexto db = new Contexto();
            List<Usuario> usuarios = db.Usuario.ToList();
            Usuario user = usuarios.Find(l => l.UsuarioAcesso == usuario.UsuarioAcesso && l.SenhaAcesso == usuario.SenhaAcesso); 
            if(user != null)
            {
                return RedirectToAction("ListarCondominios", "Condominio",new { id = user.UsuarioId });
            }
            return RedirectToAction("Index");
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastroConfirm(Usuario usuario)
        {
            if (usuario == null && usuario.SenhaVerificacao != senhaAdm)
            {
                return Json(new { message = "Usuario ou senha admin invalida.", status = 0 });
            } 
            Contexto db = new Contexto();
            db.Usuario.Add(usuario);
            db.SaveChanges();
            //return RedirectToAction("ListarCondominios", "Condominio", new { id = usuario.UsuarioId });
            return Json(new { message = "Cadastrado com sucesso!", status = 1 });
        }
    }
}
