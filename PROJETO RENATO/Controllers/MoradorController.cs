using Microsoft.AspNetCore.Mvc;
using PROJETO_RENATO.Dados.EntityFramework.Comum;
using PROJETO_RENATO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJETO_RENATO.Controllers
{
    public class MoradorController : Controller
    {
        static Usuario usuario = new Usuario();
        public IActionResult ListarUnidades(int id)
        {
            Contexto db = new Contexto();
            List<Usuario> usuarios = db.Usuario.ToList();
            usuario = usuarios.Find(l => l.UsuarioId == id);
            List<Morador> moradores = db.Morador.ToList();
            if (usuario != null)
            {
                return View(moradores);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AdicionarMorador()
        {
            ViewBag.id = usuario.UsuarioId;
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Morador morador)
        {
            Contexto db = new Contexto();
            if (morador == null)
            {
                return RedirectToAction("AdicionarMorador");

            }
            db.Morador.Add(morador);
            db.SaveChanges();
            return RedirectToAction("ListarMoradores", new { id = usuario.UsuarioId });

        }

        public IActionResult deletar(int Id)
        {
            Contexto db = new Contexto();
            Morador morador = db.Morador.Find(Id);
            db.Morador.Remove(morador);
            db.SaveChanges();
            return RedirectToAction("ListarMoradores", new { id = usuario.UsuarioId });
        }
    }
}

