namespace biblioteca.Models
{
    public class Emprestimo
    {
        public int IdEmprestimo { get; set; }
        public int IdUsuario { get; set; }
        public int IdLivro { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public string Status { get; set; }
    }
}
