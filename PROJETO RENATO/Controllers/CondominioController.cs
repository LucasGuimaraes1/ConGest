using Microsoft.AspNetCore.Mvc;
using PROJETO_RENATO.Dados.EntityFramework.Comum;
using PROJETO_RENATO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJETO_RENATO.Controllers
{
    public class CondominioController : Controller
    {
        static Usuario usuario = new Usuario();
        public IActionResult ListarCondominios(int id)
        {
            Contexto db = new Contexto();
            List<Usuario> usuarios = db.Usuario.ToList();
            usuario = usuarios.Find(l => l.UsuarioId == id);
            List<Condominio> condominios = db.Condominio.ToList();
            if (usuario != null)
            {
                ViewBag.UsuarioId = usuario.UsuarioId;
                return View(condominios);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AdicionarCondominio()
        {
            ViewBag.id = usuario.UsuarioId;
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Condominio condominio)
        {
            Contexto db = new Contexto();
            if (condominio == null)
            {
                return RedirectToAction("AdicionarCondominio");

            }
            db.Condominio.Add(condominio);
            db.SaveChanges();
            return RedirectToAction("ListarCondominios", new { id = usuario.UsuarioId });

        }

        public IActionResult deletar(int Id)
        {
            Contexto db = new Contexto();
            Condominio condominio = db.Condominio.Find(Id);
            db.Condominio.Remove(condominio);
            db.SaveChanges();
            return RedirectToAction("ListarCondominios",new { id = usuario.UsuarioId });
        }

        public IActionResult editar(int Id)
        {
            Contexto db = new Contexto();
            Condominio condominio = db.Condominio.Find(Id);
            return View(condominio);
        }

        [HttpPost]
        public IActionResult editar(Condominio condominio)
        {
            Contexto db = new Contexto();
            if (condominio.Endereco == null || condominio.Cnpj == null || condominio.NomeCondominio == null )
            {
                return View(condominio);
            }
            db.Condominio.Update(condominio);
            db.SaveChanges();
            return RedirectToAction("ListarCondominios", new { id = usuario.UsuarioId });
        }
       
    }
}
