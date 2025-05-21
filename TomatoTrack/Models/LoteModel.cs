using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoTrack.Models
{
    public class LoteModel
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public int TotalTomates { get; set; }
        public int TomatesMaduros { get; set; }
        public double mediaScoreMaduros { get; set; }
        public double desvioPadraoMaduros { get; set; }
        public double mediaScoreVerdes { get; set; }
        public double desvioPadraoVerdes { get; set; }
        public int NumeroImagens { get; set; }
        public List<byte[]> Imagens { get; set; }

        public void setDateTime(string dataHora)
        {
            this.DataHora = DateTime.Parse(dataHora);
        }
    }    
}
