using Auth.Data;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Auth.Biz.Validations
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(m => m.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa estar entre {MinLength} e {MaxLength} caracteres");

            RuleFor(m => m.Email)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido")
                .Length(2, 60).WithMessage("O campo {PropertyName} precisa estar entre {MinLength} e {MaxLength} caracteres");

            RuleFor(m => m.Email).Custom((email, context) =>
            {
                string pattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

                if (!Regex.IsMatch(email, pattern))
                    context.AddFailure("To", "Email Inválido");
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
