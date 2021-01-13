using Auth.Biz.Interface;
using Auth.Data;
using Auth.Data.Context;
using FluentValidation;
using System.Linq;
using System.Text.RegularExpressions;

namespace Auth.Biz.Validations
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator(LocalContext _context)
        {
            RuleFor(m => m.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa estar entre {MinLength} e {MaxLength} caracteres");

            RuleFor(m => m.Email)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido")
                .Length(2, 60).WithMessage("O campo {PropertyName} precisa estar entre {MinLength} e {MaxLength} caracteres");

            RuleFor(m => m.Email).Custom((email, context) =>
            {
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

                if (!Regex.IsMatch(email, pattern))
                    context.AddFailure("Email", "Email Inválido");
            });

            RuleFor(m => m.Email).Custom((email, context) =>
            {
                var emailExistente = _context.Usuario.Any(m => m.Email.ToLower() == email.ToLower());

                if (emailExistente)
                    context.AddFailure("Email", "Email já cadastrado");
            });

            RuleFor(m => m.Documento)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido")
                .Length(2, 20).WithMessage("O campo {PropertyName} precisa estar entre {MinLength} e {MaxLength} caracteres");

            RuleFor(m => m.Senha)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido")
                .Length(2, 40).WithMessage("O campo {PropertyName} precisa estar no mínimo {MinLength} caracteres");
        }
    }
}
