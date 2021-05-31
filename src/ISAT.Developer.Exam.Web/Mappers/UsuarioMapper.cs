using System;
using System.Collections.Generic;
using System.Text;
using ISAT.Developer.Exam.Core.Models;
using ISAT.Developer.Exam.Web.Models;

namespace ISAT.Developer.Exam.Web.Mappers
{
    public static class UsuarioMapper
    {
        public static UsuarioViewModel UsuarioMap(Usuario usuario)
        {
            var usuarioViewModel = new UsuarioViewModel();
            usuarioViewModel.Id = usuario.Id;
            usuarioViewModel.Nome = usuario.Nome;
            usuarioViewModel.Sobrenome = usuario.Sobrenome;
            usuarioViewModel.Email = usuario.Email;
            usuarioViewModel.Idade = usuario.Idade;
            return usuarioViewModel;
        }

        public static Usuario UsuarioMap(UsuarioViewModel usuarioViewModel)
        {
            var usuario = new Usuario();
            usuario.Id = usuarioViewModel.Id;
            usuario.Nome = usuarioViewModel.Nome;
            usuario.Sobrenome = usuarioViewModel.Sobrenome;
            usuario.Email = usuarioViewModel.Email;
            usuario.Idade = usuarioViewModel.Idade;
            return usuario;
        }

        public static List<UsuarioViewModel> UsuariosMap(List<Usuario> usuarios)
        {
            var usuariosViewModel = new List<UsuarioViewModel>();
            foreach (Usuario usuario in usuarios)
            {
                usuariosViewModel.Add(UsuarioMap(usuario));
            }
            return usuariosViewModel;
        }

        public static List<Usuario> UsuariosMap(List<UsuarioViewModel> usuariosViewModel)
        {
            var usuarios = new List<Usuario>();
            foreach (UsuarioViewModel usuarioViewModel in usuariosViewModel)
            {
                usuarios.Add(UsuarioMap(usuarioViewModel));
            }
            return usuarios;
        }
    }
}
