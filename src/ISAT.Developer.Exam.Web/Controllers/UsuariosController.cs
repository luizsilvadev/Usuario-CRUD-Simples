using ISAT.Developer.Exam.Core.Interfaces;
using ISAT.Developer.Exam.Web.Models;
using ISAT.Developer.Exam.Web.Mappers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ISAT.Developer.Exam.Web.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService UsuarioService)
        {
            _usuarioService = UsuarioService;
        }

        // Create
        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel usuarioViewModel)
        {
            try
            {
                var existeNomeCompleto = _usuarioService.GetAll().Where(e => e.Nome == usuarioViewModel.Nome 
                && e.Sobrenome == usuarioViewModel.Sobrenome).ToList();
                var existeEmail = _usuarioService.GetAll().Where(e => e.Email == usuarioViewModel.Email).ToList();
                if (existeEmail.Count > 0)
                {
                    ViewData["Mensagem"] = "Erro: Este e-mail já existe.";
                } else if (existeNomeCompleto.Count > 0)
                {
                    ViewData["Mensagem"] = "Erro: Este nome e sobrenome já existe.";
                } else
                {
                    _usuarioService.Insert(UsuarioMapper.UsuarioMap(usuarioViewModel));
                    ViewData["Mensagem"] = "Sucesso: Usuário cadastrado com sucesso.";
                }
            }
            catch (Exception ex)
            {
                ViewData["Mensagem"] = "Erro: " + ex.ToString();
                return View(usuarioViewModel);
            }
            return View(usuarioViewModel);
        }

        // Read
        // GET: Usuarios
        public IActionResult Index()
        {
            var usuariosViewModel = UsuarioMapper.UsuariosMap(_usuarioService.GetAll().ToList());
            return View(usuariosViewModel);
        }

        // GET: Usuarios/Details/5
        public IActionResult Details(long id)
        {
            return View(UsuarioMapper.UsuarioMap(_usuarioService.GetById(id)));
        }

        // Update
        // GET: Usuarios/Edit/5
        public IActionResult Edit(long id)
        {
            return View(UsuarioMapper.UsuarioMap(_usuarioService.GetById(id)));
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(long id, UsuarioViewModel usuarioViewModel)
        {
            try
            {
                _usuarioService.Update(UsuarioMapper.UsuarioMap(usuarioViewModel));
                ViewData["Mensagem"] = "Sucesso: Usuário atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                ViewData["Mensagem"] = "Erro: " + ex.ToString();
                return View(usuarioViewModel);
            }
            return View(usuarioViewModel);
        }

        // Delete
        // GET: Usuarios/Delete/5
        public IActionResult Delete(long id)
        {
            return View(UsuarioMapper.UsuarioMap(_usuarioService.GetById(id)));
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(long id, UsuarioViewModel usuarioViewModel)
        {
            try
            {
                _usuarioService.Delete(id);
                ViewData["Mensagem"] = "Sucesso: Usuário excluído com sucesso.";
            }
            catch (Exception ex)
            {
                ViewData["Mensagem"] = "Erro: " + ex.ToString();
                return View(usuarioViewModel);
            }
            return View(usuarioViewModel);
        }
    }
}
