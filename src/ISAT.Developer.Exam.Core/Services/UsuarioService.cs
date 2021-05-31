using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.Results;
using ISAT.Developer.Exam.Core.Models;
using ISAT.Developer.Exam.Core.Interfaces;

namespace ISAT.Developer.Exam.Core.Services
{
    public class UsuarioService : Service<Usuario>, IUsuarioService
    {
        public UsuarioService(IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
        }
    }
}
