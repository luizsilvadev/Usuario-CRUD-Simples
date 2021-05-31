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
                if (_usuarioService.ExistePorEmail(UsuarioMapper.UsuarioMap(usuarioViewModel)))
                {
                    ViewData["Mensagem"] = "Erro: Este e-mail já existe.";
                } else if (_usuarioService.ExistePorNomeCompleto(UsuarioMapper.UsuarioMap(usuarioViewModel)))
                {
                    ViewData["Mensagem"] = "Erro: Este nome e sobrenome já existem.";
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
        public ActionResult Edit(UsuarioViewModel usuarioViewModel)
        {
            try
            {
                if (_usuarioService.ExistePorEmail(UsuarioMapper.UsuarioMap(usuarioViewModel)))
                {
                    ViewData["Mensagem"] = "Erro: Este e-mail já existe.";
                }
                else if (_usuarioService.ExistePorNomeCompleto(UsuarioMapper.UsuarioMap(usuarioViewModel)))
                {
                    ViewData["Mensagem"] = "Erro: Este nome e sobrenome já existem.";
                }
                else
                {
                    _usuarioService.Update(UsuarioMapper.UsuarioMap(usuarioViewModel));
                    ViewData["Mensagem"] = "Sucesso: Usuário atualizado com sucesso.";
                }
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
        public ActionResult Delete(UsuarioViewModel usuarioViewModel)
        {
            try
            {
                _usuarioService.Delete(usuarioViewModel.Id);
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
