using Auth.Biz.Interface;
using Auth.Biz.Validations;
using Auth.Data;
using Auth.Data.Context;
using FluentValidation.Results;
using System;

namespace Auth.Biz
{
    public class UsuarioService : IUsuarioService
    {
        private readonly LocalContext _context;

        public UsuarioService(LocalContext context)
        {
            _context = context;
        }

        public Return CriarUsuario(Usuario user)
        {
            UsuarioValidator validator = new UsuarioValidator();
            ValidationResult results = validator.Validate(user);

            if (!results.IsValid)
                return new Return(results.Errors);

            user.DataCriacao = DateTime.Now;

            _context.Add(user);
            _context.SaveChanges();

            return new Return(user);
        }
    }
}
