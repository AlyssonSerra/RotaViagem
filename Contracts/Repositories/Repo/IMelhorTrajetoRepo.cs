using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories.Repo
{
    public interface IMelhorTrajetoRepo
    {
        public void GerarMelhorTrajetoJson(string caminho, List<MelhorTrajeto> trajetos);
    }
}
