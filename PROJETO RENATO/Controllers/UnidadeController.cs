using Microsoft.AspNetCore.Mvc;
using PROJETO_RENATO.Dados.EntityFramework.Comum;
using PROJETO_RENATO.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PROJETO_RENATO.Controllers
{
    public class UnidadeController : Controller
    {
        static Usuario usuario = new Usuario();
        Contexto db = new Contexto();
        public IActionResult ListarUnidades(int id, int condominioID)
        {
            usuario = db.Usuario.Find(id);
            List<Unidade> unidades = db.Unidade.Where(a => a.idCondominio == condominioID).ToList();
            if (usuario != null)
            {
                foreach (Unidade unidade in unidades)
                {
                    unidade.tipoUnidade = db.TipoUnidade.Find(unidade.UnidadeTipoId).Descricao;
                }
                ViewBag.Usuario = db.Usuario.Find(id);
                ViewBag.Condominio = db.Condominio.Find(condominioID);
                return View(unidades);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AdicionarUnidade(int id, int condominioID)
        {
            ViewBag.Condominio = db.Condominio.Find(condominioID);
            ViewBag.Usuario = db.Usuario.Find(id);
            ViewBag.TipoUnidade = db.TipoUnidade.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AdicionarUnidade(Unidade unidade, int id, int condominioID)
        {
            ViewBag.Usuario = db.Usuario.Find(id);
            ViewBag.Condominio = db.Condominio.Find(condominioID);
            ViewBag.TipoUnidade = db.TipoUnidade.ToList();
            unidade.idCondominio = condominioID;
            if (unidade == null)
            {
                return View(unidade);
            }
            if (unidade.NumeroUnidade == null || unidade.NumeroUnidade == 0)
            {
                ModelState.AddModelError("NumeroUnidade", "O valor do numero da unidade deve ser maior que 0");
                return View(unidade);
            }
            if (db.Unidade.Where(a => a.NumeroUnidade == unidade.NumeroUnidade && a.idCondominio == unidade.idCondominio).FirstOrDefault() != null)
            {
                ModelState.AddModelError("NumeroUnidade", "Essa unidade ja existe");
                return View(unidade);
            }
            if (unidade.UnidadeTipoId == 0)
            {
                ModelState.AddModelError("UnidadeTipoId", "Selecione uma das opções");
                return View(unidade);
            }
            db.Unidade.Add(unidade);
            db.SaveChanges();
            return RedirectToAction("ListarUnidades", new { id = usuario.UsuarioId, condominioID = ViewBag.Condominio.IdCondominio });
        }

        public IActionResult deletar(int Id)
        {
            Unidade unidade = db.Unidade.Find(Id);
            ViewBag.Condominio = db.Condominio.Find(unidade.idCondominio);
            if (unidade != null)
            {
                db.Unidade.Remove(unidade);
            }
            db.SaveChanges();
            return RedirectToAction("ListarUnidades", new { id = usuario.UsuarioId, condominioID = ViewBag.Condominio.IdCondominio });
        }

        public IActionResult AdicionarProprietario(int unidadeId, int usuarioId)
        {
            ViewBag.Usuario = db.Usuario.Find(usuarioId);
            ViewBag.Unidade = db.Unidade.Find(unidadeId);
            return View();
        }

        [HttpPost]
        public IActionResult AdicionarProprietario(Morador proprietario, int unidadeId, int usuarioId)
        {
            ViewBag.Usuario = db.Usuario.Find(usuarioId);
            ViewBag.Unidade = db.Unidade.Find(unidadeId);
            if (proprietario == null || string.IsNullOrEmpty(proprietario.Nome) || string.IsNullOrEmpty(proprietario.CPF) || string.IsNullOrEmpty(proprietario.Email))
            {
                return View(proprietario);
            }
            db.Morador.Add(proprietario);
            db.SaveChanges();
            Morador morador = db.Morador.Where(a => a.CPF == proprietario.CPF).FirstOrDefault();
            if (morador != null)
            {
                db.Unidade.Find(unidadeId).IdMorador = morador.IdMorador;
                db.SaveChanges();
            }
            return RedirectToAction("ListarUnidades", new { id = ViewBag.Usuario.UsuarioId, condominioID = db.Unidade.Find(unidadeId).idCondominio });
        }

        public IActionResult Editar(int id, int usuarioId)
        {
            ViewBag.TipoUnidade = db.TipoUnidade.ToList();
            ViewBag.Moradores = db.Morador.ToList();
            ViewBag.Usuario = db.Usuario.Find(usuarioId);
            return View(db.Unidade.Find(id));
        }

        [HttpPost]
        public IActionResult Editar(Unidade unidade, int usuarioId)
        {
            ViewBag.TipoUnidade = db.TipoUnidade.ToList();
            ViewBag.Usuario = db.Usuario.Find(usuarioId);
            ViewBag.Moradores = db.Morador.ToList();
            if (unidade == null)
            {
                return View(unidade);
            }
            if (unidade.UnidadeTipoId == 0)
            {
                ModelState.AddModelError("tipoUnidade", "Selecione pelo menos um tipo");
                return View(unidade);
            }
            db.Unidade.Update(unidade);
            db.SaveChanges();
            return RedirectToAction("ListarUnidades", new { id = ViewBag.Usuario.UsuarioId, condominioId = unidade.idCondominio });
        }

        public IActionResult DetalhesProprietario(int ProrietarioId, int usuarioId, int condominioId)
        {
            ViewBag.Usuario = db.Usuario.Find(usuarioId);
            ViewBag.Condominio = db.Condominio.Find(condominioId);
            return View(db.Morador.Find(ProrietarioId));
        }
        public IActionResult RemoverProprietario(int id, int usuarioId, int condominioId)
        {
            if (id != 0 && usuarioId != 0 && condominioId != 0)
            {
                db.Morador.Remove(db.Morador.Find(id));
                db.SaveChanges();
            }
            return RedirectToAction("ListarUnidades", new { id = usuarioId, condominioID = condominioId });
        }

        public IActionResult EditarProprietario(int id, int usuarioId, int condominioId)
        {
            ViewBag.Usuario = db.Usuario.Find(usuarioId);
            ViewBag.Condominio = db.Condominio.Find(condominioId);
            return View(db.Morador.Find(id));
        }

        [HttpPost]
        public IActionResult EditarProprietario(Morador morador, int usuarioId, int condominioId)
        {
            ViewBag.Usuario = db.Usuario.Find(usuarioId);
            ViewBag.Condominio = db.Condominio.Find(condominioId);
            if(morador.CPF == null || morador.Email == null || morador.Nome == null)
            {
                return View(morador);
            }
            db.Morador.Update(morador);
            db.SaveChanges();
            return RedirectToAction("ListarUnidades", new { id = ViewBag.Usuario.UsuarioId, condominioID = ViewBag.Condominio.IdCondominio });
        }
    }
}
