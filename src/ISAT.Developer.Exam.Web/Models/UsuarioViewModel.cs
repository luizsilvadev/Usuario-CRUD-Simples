using System;
using System.ComponentModel.DataAnnotations;

namespace ISAT.Developer.Exam.Web.Models
{
    public class UsuarioViewModel
    {
        [Display(Name = "Código")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [StringLength(255, ErrorMessage = "Nome não pode ser maior que 255 caracteres.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [StringLength(255, ErrorMessage = "Sobrenome não pode ser maior que 255 caracteres.")]
        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [StringLength(255, ErrorMessage = "E-mail não pode ser maior que 255 caracteres.")]
        [EmailAddress(ErrorMessage = "Digite um e-mail válido.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [Range(10, 100, ErrorMessage = "A idade deve ser entre 10 e 100.")]
        [Display(Name = "Idade")]
        public int Idade { get; set; }

        [Display(Name = "Nome Completo")]
        public string NomeCompleto
        {
            get
            {
                return Nome + " " + Sobrenome;
            }
        }
    }
}
