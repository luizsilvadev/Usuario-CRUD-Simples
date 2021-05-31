using ISAT.Developer.Exam.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace ISAT.Developer.Exam.Core.Models
{
    public class Usuario : BaseEntity<Usuario>
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public int Idade { get; set; }

        public Usuario()
        {
            RuleFor(usuario => usuario.Nome).NotEmpty().Length(1, 255);
            RuleFor(usuario => usuario.Sobrenome).NotEmpty().Length(1, 255);
            RuleFor(usuario => usuario.Email).EmailAddress().Length(1, 255);
            RuleFor(usuario => usuario.Idade).InclusiveBetween(10, 100);
        }

        public override bool IsValid()
        {
            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
