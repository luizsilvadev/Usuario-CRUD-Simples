using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.Results;
using ISAT.Developer.Exam.Core.Models;
using ISAT.Developer.Exam.Core.Interfaces;
using ISAT.Developer.Exam.Core.Entities;

namespace ISAT.Developer.Exam.Core.Services
{
    public class UsuarioService : Service<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public bool ExistePorEmail(Usuario usuario)
        {
            if (usuario.Id > 0)
                return _usuarioRepository.ExistsByExpression(f => f.Id != usuario.Id && f.Email == usuario.Email);
            return _usuarioRepository.ExistsByExpression(f => f.Email == usuario.Email);
        }

        public bool ExistePorNomeCompleto(Usuario usuario)
        {
            if (usuario.Id > 0)
                return _usuarioRepository.ExistsByExpression(f => f.Id != usuario.Id && f.Nome == usuario.Nome && f.Sobrenome == usuario.Sobrenome);
            return _usuarioRepository.ExistsByExpression(f => f.Nome == usuario.Nome && f.Sobrenome == usuario.Sobrenome);
        }
    }
}
