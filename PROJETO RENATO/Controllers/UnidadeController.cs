using Microsoft.AspNetCore.Mvc;
using PROJETO_RENATO.Dados.EntityFramework.Comum;
using PROJETO_RENATO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJETO_RENATO.Controllers
{
    public class UnidadeController : Controller
    {
        static Usuario usuario = new Usuario();
        public IActionResult ListarUnidades(int id, int condominioID)
        {
            Contexto db = new Contexto();
            List<Usuario> usuarios = db.Usuario.ToList();
            usuario = usuarios.Find(l => l.UsuarioId == id);
            List<Unidade> unidades = db.Unidade.ToList();
            if (usuario != null)
            {
                ViewBag.CondominioID = condominioID;
                return View(unidades);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AdicionarUnidade(int condominioID)
        {
            ViewBag.CondominioID = condominioID;
            ViewBag.id = usuario.UsuarioId;
            return View();
        }

        [HttpPost]
        public IActionResult AdicionarUnidade(Unidade unidade)
        {
            Contexto db = new Contexto();
            if (unidade == null)
            {
                return RedirectToAction("AdicionarUnidade");

            }
            db.Unidade.Add(unidade);
            db.SaveChanges();
            return RedirectToAction("ListarUnidades", new { id = usuario.UsuarioId });

        }

        public IActionResult deletar(int Id)
        {
            Contexto db = new Contexto();
            Unidade unidade = db.Unidade.Find(Id);
            db.Unidade.Remove(unidade);
            db.SaveChanges();
            return RedirectToAction("ListarUnidades", new { id = usuario.UsuarioId });
        }

        public IActionResult AdicionarMorador(Unidade unidade)
        {
            ViewBag.Unidade = unidade;
            return View(unidade);
        }
    }
}
