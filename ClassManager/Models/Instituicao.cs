using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableAttribute = SQLite.TableAttribute;

namespace ClassManager.Models
{
    [Table("Instituicoes")]
    public class Instituicao
    {
        [ForeignKey("Client")]
        public int ClientId { get; set; }

        [PrimaryKey]
        public string Nome { get; set; }

        [Ignore]
        public Client Client { get; set; }

        [Ignore]
        public List<Turma> Turmas { get; set; }
        public double MediaNotas { get; set; }
        public double MediaFrequencia { get; set; }
    }
}
