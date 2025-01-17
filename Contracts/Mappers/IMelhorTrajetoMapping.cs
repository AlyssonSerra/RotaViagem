using Entities.Models;
using Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Mappers
{
    public interface IMelhorTrajetoMapping
    {
        public MelhorTrajetoResponse ConverteModelParaResponse(MelhorTrajeto model);

    }
}
