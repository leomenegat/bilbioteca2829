using biblioteca.Models;
using Microsoft.Data.SqlClient;

namespace biblioteca.Data
{
    public class UsuarioRepository
    {
        private readonly BibliotecaContext _context = new BibliotecaContext();

        public void Cadastrar(Usuario usuario)
        {
            using var conn = _context.GetConnection();
            conn.Open();
            string sql = "INSERT INTO Usuarios (Nome, CPF, Email) VALUES (@n, @c, @e)";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@n", usuario.Nome);
            cmd.Parameters.AddWithValue("@c", usuario.CPF);
            cmd.Parameters.AddWithValue("@e", usuario.Email);
            cmd.ExecuteNonQuery();
        }

        public List<Usuario> Listar()
        {
            var lista = new List<Usuario>();
            using var conn = _context.GetConnection();
            conn.Open();
            string sql = "SELECT * FROM Usuarios";
            using var cmd = new SqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Usuario
                {
                    IdUsuario = (int)reader["IdUsuario"],
                    Nome = reader["Nome"].ToString(),
                    CPF = reader["CPF"].ToString(),
                    Email = reader["Email"].ToString()
                });
            }
            return lista;
        }
    }
}
