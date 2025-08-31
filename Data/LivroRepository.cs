using biblioteca.Models;
using Microsoft.Data.SqlClient;

namespace biblioteca.Data
{
    public class LivroRepository
    {
        private readonly BibliotecaContext _context = new BibliotecaContext();

        public void Cadastrar(Livro livro)
        {
            using var conn = _context.GetConnection();
            conn.Open();
            string sql = "INSERT INTO Livros (Titulo, Genero, AnoPublicacao, IdAutor) VALUES (@t, @g, @a, @idAutor)";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@t", livro.Titulo);
            cmd.Parameters.AddWithValue("@g", livro.Genero);
            cmd.Parameters.AddWithValue("@a", livro.AnoPublicacao);
            cmd.Parameters.AddWithValue("@idAutor", livro.IdAutor);
            cmd.ExecuteNonQuery();
        }

        public List<Livro> Listar()
        {
            var lista = new List<Livro>();
            using var conn = _context.GetConnection();
            conn.Open();
            string sql = "SELECT * FROM Livros";
            using var cmd = new SqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Livro
                {
                    IdLivro = (int)reader["IdLivro"],
                    Titulo = reader["Titulo"].ToString(),
                    Genero = reader["Genero"].ToString(),
                    AnoPublicacao = (int)reader["AnoPublicacao"],
                    IdAutor = (int)reader["IdAutor"]
                });
            }
            return lista;
        }
    }
}
