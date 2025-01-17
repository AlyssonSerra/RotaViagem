using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts.Repositories.Repo
{
    public interface IPernaRepo
    {

        public void GerarPernaJson(string caminho, List<Perna> pernas);
        public List<Perna> ObterPernasJson(string caminho);
    }
}
