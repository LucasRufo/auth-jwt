using Auth.Biz.Interface;
using Auth.Biz.Util;
using Auth.Biz.Validations;
using Auth.Data;
using Auth.Data.Context;
using FluentValidation.Results;
using System;
using System.Linq;

namespace Auth.Biz
{
    public class UsuarioService : IUsuarioService
    {
        private readonly LocalContext _context;

        public UsuarioService(LocalContext context)
        {
            _context = context;
        }

        public Usuario ObterUsuarioLogin(string email, string senha)
        {
            senha = Hashing.HashMD5(senha);

            return _context.Usuario
                .Where(m => m.Email.ToLower() == email.ToLower() && m.Senha == senha)
                .FirstOrDefault();
        }

        public Return CriarUsuario(Usuario user)
        {
            UsuarioValidator validator = new UsuarioValidator(_context);
            ValidationResult results = validator.Validate(user);

            if (!results.IsValid)
                return new Return(results.Errors);

            user.Senha = Hashing.HashMD5(user.Senha);
            user.DataCriacao = DateTime.Now;

            _context.Add(user);
            _context.SaveChanges();

            return new Return(user);
        }
    }
}
