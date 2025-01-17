using Entities.Models;
using Entities.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Mappers
{
    public interface IPernaMapping
    {
        public Perna ConverteRequestParaModel(PernaRequest request);

    }
}
