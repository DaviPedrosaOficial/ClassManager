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
    [Table("Turmas")]
    public class Turma
    {
        [ForeignKey("Instituicao")]
        public string InstituicaoNome { get; set; }

        [PrimaryKey]
        public string Nome { get; set; }
        public List<Disciplina> Disciplinas { get; set; }
        public List<Aluno> Alunos { get; set; } = new List<Aluno>();
        public double MediaTotalNota { get; set; }
        public double MediaTotalFrequencia { get; set; }
        public int PadraoDeNotas { get; set; }
        public string PadraoCalendario { get; set; }
    }
}
