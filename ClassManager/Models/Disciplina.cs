using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassManager.Models
{
    public class Disciplina
    {
        public string Nome { get; set; }
        public List<Atividade> Atividades { get; set; }
        public int CargaHoraria { get; set; }
        public int CargaHorariaAtual { get; set; } = 0;
        public double Media { get; set; }
    }
}
