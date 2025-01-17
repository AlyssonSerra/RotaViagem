using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Managers
{
    public interface IMelhorTrajetoManager
    {
        public MelhorTrajeto EncontrarMelhorTrajeto(string origem, string destino, List<Perna> rotas);

    }
}
