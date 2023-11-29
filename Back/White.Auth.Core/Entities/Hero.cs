using White.Auth.Core.Entities.Base;

namespace White.Auth.Core.Entities
{
    public class Hero : BaseEntity
    {
        public string Nome { get; set; }
        public string Poder { get; set; }
        public int Idade { get; set; } = 0;
        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }

        public Hero() { }

        public Hero(int id, string nome, string poder, int idade)
        {
            Id = id;
            Nome = nome;
            Poder = poder;
            Idade = idade;
        }
    }
}
