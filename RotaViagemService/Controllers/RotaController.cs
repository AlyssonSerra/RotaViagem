using Microsoft.AspNetCore.Mvc;
using Entities.Response;
using Entities.Request;
using Repositories.Repo;
using Contracts.Repositories.Repo;
using Managers;
using Contracts.Managers;
using Contracts.Mappers;
using Managers.Mappers;
using Entities.Models;

namespace RotaViagemService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RotaController : ControllerBase
    {

        private readonly ILogger<RotaController> _logger;
        private readonly IConfiguration _configuration;
        private IPernaRepo _pernaRepo;
        private IMelhorTrajetoManager _melhorTrajetoManager;
        private IPernaMapping _pernaMapping;
        private IMelhorTrajetoMapping _melhorTrajetoMapping;
        public RotaController(ILogger<RotaController> logger, IPernaRepo pernaRepo, IConfiguration configuration, IMelhorTrajetoManager melhorTrajetoManager,
            IPernaMapping pernaMapping, IMelhorTrajetoMapping melhorTrajetoMapping)
        {
            _logger = logger;
            _pernaRepo = pernaRepo;
            _configuration = configuration;
            _melhorTrajetoManager = melhorTrajetoManager;
            _pernaMapping = pernaMapping;
            _melhorTrajetoMapping = melhorTrajetoMapping;
        }


        [HttpPost("IncluirViagem")]
        public IActionResult IncluirPerna([FromBody] PernaRequest PernaRequest)
        {
            try
            {
                var caminho = _configuration.GetSection("Paths").GetSection("CaminhoPernasJson").Value;

                var listaPernas = _pernaRepo.ObterPernasJson(caminho);

                Perna perna = _pernaMapping.ConverteRequestParaModel(PernaRequest);

                listaPernas.Add(perna);

                _pernaRepo.GerarPernaJson(caminho, listaPernas);

                var melhorRota = _melhorTrajetoManager.EncontrarMelhorTrajeto(PernaRequest.Origem, PernaRequest.Destino, listaPernas);

                return Ok();
            }
            catch (Exception ex) 
            {
                return StatusCode(500, "Erro interno");
            }
        }


        [HttpPut("GetMelhorRota")]
        public MelhorTrajetoResponse Get([FromBody] MelhorTrajetoRequest TrajetoRequest)
        {

            var caminho = _configuration.GetSection("Paths").GetSection("CaminhoPernasJson").Value;

            var listaPernas = _pernaRepo.ObterPernasJson(caminho);

            var melhorRota = _melhorTrajetoManager.EncontrarMelhorTrajeto(TrajetoRequest.Origem, TrajetoRequest.Destino, listaPernas);

            return _melhorTrajetoMapping.ConverteModelParaResponse(melhorRota);

        }

    }
}
