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
    [Table("Disciplinas")]
    public class Disciplina
    {
        [ForeignKey("Turma")]
        public string TurmaNome { get; set; }

        [PrimaryKey, AutoIncrement, NotNull]
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Atividade> Atividades { get; set; }
        public int CargaHoraria { get; set; }
        public int CargaHorariaAtual { get; set; } = 0;
        public double Media { get; set; }
    }
}
