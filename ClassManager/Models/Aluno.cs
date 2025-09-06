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
    [Table("Alunos")]

    public class Aluno
    {
        [PrimaryKey, AutoIncrement, NotNull]
        public int Id { get; set; }
        public int Nome { get; set; }
        public List<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();

        public int PresencaCargaHoraria { get; set; }
    }
}
