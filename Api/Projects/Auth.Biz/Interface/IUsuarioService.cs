using Auth.Data;

namespace Auth.Biz.Interface
{
    public interface IUsuarioService
    {
        Usuario ObterUsuarioLogin(string email, string senha);

        Return CriarUsuario(Usuario user);
    }
}
