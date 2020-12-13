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
        Contexto db = new Contexto();
        public IActionResult ListarCondominios(int id)
        {
            List<Usuario> usuarios = db.Usuario.ToList();
            usuario = usuarios.Find(l => l.UsuarioId == id);
            List<Condominio> condominios = db.Condominio.ToList();
            if (usuario != null)
            {
                foreach (Condominio condominio in condominios)
                {
                    if (condominio.Endereco.Length > 30)
                        condominio.Endereco = condominio.Endereco.Substring(0, 30) + "...";
                }
                ViewBag.Usuario = usuario;
                return View(condominios);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AdicionarCondominio(int usuarioId)
        {
            usuario = db.Usuario.Find(usuarioId);
            ViewBag.Usuario = usuario;
            return View();
        }

        [HttpPost]
        public IActionResult AdicionarCondominio(int usuarioId, Condominio condominio)
        {
            if ((string.IsNullOrEmpty(condominio.NomeCondominio) || string.IsNullOrEmpty(condominio.Cnpj) || string.IsNullOrEmpty(condominio.Endereco)) || (condominio.Cnpj.Length != 18 || condominio.Endereco.Length < 3 || condominio.NomeCondominio.Length < 3))
            {
                ViewBag.Usuario = db.Usuario.Find(usuarioId);
                return View(condominio);
            }
            db.Condominio.Add(condominio);
            db.SaveChanges();
            return RedirectToAction("ListarCondominios", new { id = usuario.UsuarioId });

        }

        public IActionResult deletar(int Id)
        {
            Condominio condominio = db.Condominio.Find(Id);
            if (condominio != null)
            {
                db.Condominio.Remove(condominio);
                db.SaveChanges();
            }
            return RedirectToAction("ListarCondominios", new { id = usuario.UsuarioId });
        }

        public IActionResult editar(int Id, int usuarioId)
        {
            Condominio condominio = db.Condominio.Find(Id);
            ViewBag.Usuario = db.Usuario.Find(usuarioId);
            return View(condominio);
        }

        [HttpPost]
        public IActionResult editar(Condominio condominio, int usuarioId)
        {
            if (condominio.Endereco == null || condominio.Cnpj == null || condominio.NomeCondominio == null)
            {
                ViewBag.Usuario = db.Usuario.Find(usuarioId);
                return View(condominio);
            }
            db.Condominio.Update(condominio);
            db.SaveChanges();
            return RedirectToAction("ListarCondominios", new { id = usuario.UsuarioId });
        }

        public IActionResult Detalhes(int condominioId, int usuarioId)
        {
            ViewBag.Usuario = db.Usuario.Find(usuarioId);
            return View(db.Condominio.Find(condominioId));
        }

    }
}
