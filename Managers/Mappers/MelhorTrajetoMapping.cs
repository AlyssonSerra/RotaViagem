using Entities.Models;
using Entities.Request;
using Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Mappers;

namespace Managers.Mappers
{
    public class MelhorTrajetoMapping :IMelhorTrajetoMapping
    {
        public MelhorTrajetoResponse ConverteModelParaResponse(MelhorTrajeto model)
        {
            return new MelhorTrajetoResponse
            {
                Origem = model.Origem,
                Destino = model.Destino,
                CustoTotal = model.CustoTotal,
                Caminho = model.Caminho
            };


        }
    }

}
