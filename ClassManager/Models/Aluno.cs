using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassManager.Models
{
    public class Aluno
    {
        public int Nome { get; set; }
        public List<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();

        public int PresencaCargaHoraria { get; set; }
    }
}
