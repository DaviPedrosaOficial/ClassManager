using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassManager.Models
{
    public class Instituicao
    {
        public string Nome { get; set; }
        public List<Turma> Turmas { get; set; }
        public double MediaNotas { get; set; }
        public double MediaFrequencia { get; set; }
    }
}
