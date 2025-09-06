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
        public int CLientId { get; set; }

        [PrimaryKey]
        public string Nome { get; set; }
        public List<Turma> Turmas { get; set; }
        public double MediaNotas { get; set; }
        public double MediaFrequencia { get; set; }
    }
}
