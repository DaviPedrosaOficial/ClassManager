using SQLite;
using NotNullAttribute = SQLite.NotNullAttribute;
using TableAttribute = SQLite.TableAttribute;

namespace ClassManager.Models
{
    [Table("Clients")]
    public class Client
    {
        [PrimaryKey, AutoIncrement, NotNull]
        public int Id { get; set; }

        [NotNull]
        public string Nome { get; set; }

        [Unique, NotNull]
        public string Email { get; set; }

        [NotNull]
        public string Senha { get; set; }

        [Ignore]
        public List<Instituicao> Instituicoes { get; set; }
    }
}
