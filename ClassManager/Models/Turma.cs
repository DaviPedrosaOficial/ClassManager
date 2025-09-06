using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassManager.Models
{
    public class Turma
    {
        public string Nome { get; set; }
        public List<Disciplina> Disciplinas { get; set; }
        public List<Aluno> Alunos { get; set; } = new List<Aluno>();
        public double MediaTotalNota 
        { 
            get => Alunos.Count == 0 ? 0 : Alunos.Average(a => a.MediaNotas);
        }
        public double MediaTotalFrequencia 
        { 
            get => Alunos.Count == 0 ? 0 : Alunos.Average(a => (double)a.PresencaCargaHoraria / Disciplinas.Sum(d => d.CargaHorariaAtual) * 100);
        }
        public int PadraoDeNotas { get; set; }
        public string PadraoCalendario { get; set; }
    }
}
