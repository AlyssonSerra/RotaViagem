using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Response
{
    public class MelhorTrajetoResponse
    {
        //public Guid Id { get; set; }

        public string Origem { get; set; }

        public string Destino { get; set; }

        public int CustoTotal { get; set; }

        public List<string> Caminho { get; set; } = new List<string>();

    }
}
