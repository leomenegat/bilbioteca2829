using biblioteca.Models;
using Microsoft.Data.SqlClient;

namespace biblioteca.Data
{
    public class EmprestimoRepository
    {
        private readonly BibliotecaContext _context = new BibliotecaContext();

        public void RegistrarEmprestimo(Emprestimo e)
        {
            using var conn = _context.GetConnection();
            conn.Open();
            string sql = "INSERT INTO Emprestimos (IdUsuario, IdLivro, DataEmprestimo, Status) VALUES (@u, @l, @d, @s)";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@u", e.IdUsuario);
            cmd.Parameters.AddWithValue("@l", e.IdLivro);
            cmd.Parameters.AddWithValue("@d", e.DataEmprestimo);
            cmd.Parameters.AddWithValue("@s", e.Status);
            cmd.ExecuteNonQuery();
        }

        public void RegistrarDevolucao(int idEmprestimo)
        {
            using var conn = _context.GetConnection();
            conn.Open();
            string sql = "UPDATE Emprestimos SET DataDevolucao = @data, Status = 'Devolvido' WHERE IdEmprestimo = @id";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@data", DateTime.Now);
            cmd.Parameters.AddWithValue("@id", idEmprestimo);
            cmd.ExecuteNonQuery();
        }

        public List<Emprestimo> HistoricoUsuario(int idUsuario)
        {
            var lista = new List<Emprestimo>();
            using var conn = _context.GetConnection();
            conn.Open();
            string sql = "SELECT * FROM Emprestimos WHERE IdUsuario = @id";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", idUsuario);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Emprestimo
                {
                    IdEmprestimo = (int)reader["IdEmprestimo"],
                    IdUsuario = (int)reader["IdUsuario"],
                    IdLivro = (int)reader["IdLivro"],
                    DataEmprestimo = (DateTime)reader["DataEmprestimo"],
                    DataDevolucao = reader["DataDevolucao"] as DateTime?,
                    Status = reader["Status"].ToString()
                });
            }
            return lista;
        }
    }
}
