using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Response;
using Entities.Models;
using Entities.Request;
using Contracts.Mappers;

namespace Managers.Mappers
{
    public class PernaMapping :IPernaMapping
    {
        public Perna ConverteRequestParaModel (PernaRequest request)
        {
            return new Perna
            {
                IdPerna = Guid.NewGuid(),
                Origem = request.Origem,
                Destino = request.Destino,
                Custo = request.Custo
            };

        }

    }
}
