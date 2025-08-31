using biblioteca.Models;
using biblioteca.Services;

class Program
{
    static void Main()
    {
        var service = new BibliotecaService();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Biblioteca ===");
            Console.WriteLine("1 - Cadastrar Usuário");
            Console.WriteLine("2 - Listar Usuários");
            Console.WriteLine("3 - Cadastrar Livro");
            Console.WriteLine("4 - Listar Livros");
            Console.WriteLine("5 - Registrar Empréstimo");
            Console.WriteLine("6 - Registrar Devolução");
            Console.WriteLine("7 - Histórico de Empréstimos");
            Console.WriteLine("0 - Sair");
            Console.Write("Opção: ");
            var op = Console.ReadLine();

            switch (op)
            {
                case "1":
                    Console.Write("Nome: ");
                    string nomeU = Console.ReadLine();
                    Console.Write("CPF: ");
                    string cpf = Console.ReadLine();
                    Console.Write("Email: ");
                    string email = Console.ReadLine();
                    service.CadastrarUsuario(new Usuario { Nome = nomeU, CPF = cpf, Email = email });
                    Console.WriteLine("Usuário cadastrado!");
                    Console.ReadKey();
                    break;

                case "2":
                    var usuarios = service.ListarUsuarios();
                    foreach (var u in usuarios)
                        Console.WriteLine($"{u.IdUsuario} - {u.Nome} - {u.CPF} - {u.Email}");
                    Console.ReadKey();
                    break;

                case "3":
                    Console.Write("Título: ");
                    string titulo = Console.ReadLine();
                    Console.Write("Gênero: ");
                    string genero = Console.ReadLine();
                    Console.Write("Ano: ");
                    int ano = int.Parse(Console.ReadLine());
                    Console.Write("IdAutor: ");
                    int idAutor = int.Parse(Console.ReadLine());
                    service.CadastrarLivro(new Livro { Titulo = titulo, Genero = genero, AnoPublicacao = ano, IdAutor = idAutor });
                    Console.WriteLine("Livro cadastrado!");
                    Console.ReadKey();
                    break;

                case "4":
                    var livros = service.ListarLivros();
                    foreach (var l in livros)
                        Console.WriteLine($"{l.IdLivro} - {l.Titulo} ({l.AnoPublicacao})");
                    Console.ReadKey();
                    break;

                case "5":
                    Console.Write("IdUsuario: ");
                    int idUsuario = int.Parse(Console.ReadLine());
                    Console.Write("IdLivro: ");
                    int idLivro = int.Parse(Console.ReadLine());
                    service.RegistrarEmprestimo(idUsuario, idLivro);
                    Console.WriteLine("Empréstimo registrado!");
                    Console.ReadKey();
                    break;

                case "6":
                    Console.Write("IdEmprestimo: ");
                    int idEmp = int.Parse(Console.ReadLine());
                    service.RegistrarDevolucao(idEmp);
                    Console.WriteLine("Devolução registrada!");
                    Console.ReadKey();
                    break;

                case "7":
                    Console.Write("IdUsuario: ");
                    int idU = int.Parse(Console.ReadLine());
                    var hist = service.HistoricoUsuario(idU);
                    foreach (var e in hist)
                        Console.WriteLine($"{e.IdEmprestimo} - Livro {e.IdLivro} - {e.Status} - Emp: {e.DataEmprestimo} - Dev: {e.DataDevolucao}");
                    Console.ReadKey();
                    break;

                case "0":
                    return;
            }
        }
    }
}
