using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public  class MelhorTrajeto
    {
        public Guid IdMelhorTrajeto { get; set; }

        public string Origem { get; set; }

        public string Destino { get; set; }

        public List<Perna> Pernas { get; set; }

        public List<string> Caminho { get; set; } = new List<string>();

        public int CustoTotal { get; set; }

        //public int NumeroPernas { get; set; }


    }
}
