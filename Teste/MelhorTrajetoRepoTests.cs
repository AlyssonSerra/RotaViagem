

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Xunit;
using Entities.Models;
using Repositories.Repo;

namespace Teste
{
    public class MelhorTrajetoRepoTests
    {
        [Fact]
        public void GerarMelhorTrajetoJson_CriaArquivoComDadosCorretos()
        {

            var repo = new MelhorTrajetoRepo();
            string caminho = Path.Combine(Path.GetTempPath(), "melhorTrajetoTest.json");
            var trajetos = new List<MelhorTrajeto>
        {
            new MelhorTrajeto { Origem = "GRU", Destino = "BRC", CustoTotal = 10 },
            new MelhorTrajeto { Origem = "BRC", Destino = "SCL", CustoTotal = 5 }
        };

            repo.GerarMelhorTrajetoJson(caminho, trajetos);

            Assert.True(File.Exists(caminho), "O arquivo JSON não foi criado.");

            string json = File.ReadAllText(caminho);
            var trajetosDoArquivo = JsonSerializer.Deserialize<List<MelhorTrajeto>>(json);

            Assert.NotNull(trajetosDoArquivo);
            Assert.Equal(trajetos.Count, trajetosDoArquivo.Count);
            Assert.Equal(trajetos[0].Origem, trajetosDoArquivo[0].Origem);
            Assert.Equal(trajetos[0].Destino, trajetosDoArquivo[0].Destino);
            Assert.Equal(trajetos[0].CustoTotal, trajetosDoArquivo[0].CustoTotal);

            if (File.Exists(caminho))
            {
                File.Delete(caminho);
            }
        }
    }

}
