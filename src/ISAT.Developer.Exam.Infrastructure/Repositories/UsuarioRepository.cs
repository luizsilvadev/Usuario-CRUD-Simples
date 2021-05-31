using ISAT.Developer.Exam.Core.Interfaces;
using ISAT.Developer.Exam.Core.Models;
using ISAT.Developer.Exam.Infrastructure.ORM.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISAT.Developer.Exam.Infrastructure.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
    }
}
