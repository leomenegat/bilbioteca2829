namespace biblioteca.Models
{
    public class Livro
    {
        public int IdLivro { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int AnoPublicacao { get; set; }
        public int IdAutor { get; set; }
    }
}