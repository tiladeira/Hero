using White.Auth.Core.Entities.Base;

namespace White.Auth.Core.Entities
{
    public class Categoria : BaseEntity
    {
        public string Name { get; set; }

        public Categoria() { }

        public Categoria(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
