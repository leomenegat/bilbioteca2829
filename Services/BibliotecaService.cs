using biblioteca.Data;
using biblioteca.Models;

namespace biblioteca.Services
{
    public class BibliotecaService
    {
        private readonly LivroRepository _livroRepo = new LivroRepository();
        private readonly EmprestimoRepository _emprestimoRepo = new EmprestimoRepository();
        private readonly UsuarioRepository _usuarioRepo = new UsuarioRepository(); // <— ADD

        public void CadastrarLivro(Livro livro)
        {
            _livroRepo.Cadastrar(livro);
        }

        public List<Livro> ListarLivros()
        {
            return _livroRepo.Listar();
        }

        public void RegistrarEmprestimo(int idUsuario, int idLivro)
        {
            var emprestimo = new Emprestimo
            {
                IdUsuario = idUsuario,
                IdLivro = idLivro,
                DataEmprestimo = DateTime.Now,
                Status = "Ativo"
            };
            _emprestimoRepo.RegistrarEmprestimo(emprestimo);
        }

        public void RegistrarDevolucao(int idEmprestimo)
        {
            _emprestimoRepo.RegistrarDevolucao(idEmprestimo);
        }

        public List<Emprestimo> HistoricoUsuario(int idUsuario)
        {
            return _emprestimoRepo.HistoricoUsuario(idUsuario);
        }
        public void CadastrarUsuario(Usuario u) => _usuarioRepo.Cadastrar(u);
        public List<Usuario> ListarUsuarios() => _usuarioRepo.Listar();

    }
}
