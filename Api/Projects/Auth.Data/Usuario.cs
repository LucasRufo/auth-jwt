using System;

namespace Auth.Data
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Documento { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public DateTime? DataCriacao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public Usuario() { }

        public Usuario(string nome, string documento, string email, string senha, DateTime dataCriacao, DateTime? dataAlteracao)
        {
            Nome = nome;
            Documento = documento;
            Email = email;
            Senha = senha;
            DataCriacao = dataCriacao;
            DataAlteracao = dataAlteracao;
        }
    }
}
