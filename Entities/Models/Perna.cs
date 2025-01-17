using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Perna
    {
        public Guid IdPerna { get; set; }
        public string Origem { get; set; }

        public string Destino { get; set; }

        public int Custo { get; set; }
    }
}
