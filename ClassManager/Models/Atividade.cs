using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassManager.Models
{
    public class Atividade
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double ValorAtividade { get; set; }
        public double NotaAluno { get; set; }
        public bool Feita { get; set; }
        public DateTime DataEntrega { get; set; }
    }
}
