using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Xunit;
using Entities.Models;
using Repositories.Repo;

namespace Teste
{
    public class PernaRepoTests
    {
        [Fact]
        public void GerarPernaJson_CriaArquivoComDadosCorretos()
        {
            // Arrange
            var repo = new PernaRepo();
            string caminho = Path.Combine(Path.GetTempPath(), "pernasTest.json");
            var pernas = new List<Perna>
        {
            new Perna { IdPerna = Guid.NewGuid(), Origem = "GRU", Destino = "BRC", Custo = 10 },
            new Perna { IdPerna = Guid.NewGuid(), Origem = "BRC", Destino = "SCL", Custo = 5 }
        };

            // Act
            repo.GerarPernaJson(caminho, pernas);

            // Assert
            Assert.True(File.Exists(caminho), "O arquivo JSON não foi criado.");

            string json = File.ReadAllText(caminho);
            var pernasDoArquivo = JsonSerializer.Deserialize<List<Perna>>(json);

            Assert.NotNull(pernasDoArquivo);
            Assert.Equal(pernas.Count, pernasDoArquivo.Count);
            Assert.Equal(pernas[0].Origem, pernasDoArquivo[0].Origem);
            Assert.Equal(pernas[0].Destino, pernasDoArquivo[0].Destino);
            Assert.Equal(pernas[0].Custo, pernasDoArquivo[0].Custo);

            // Cleanup
            if (File.Exists(caminho))
            {
                File.Delete(caminho);
            }
        }

        [Fact]
        public void ObterPernasJson_RetornaListaDePernas()
        {
            // Arrange
            var repo = new PernaRepo();
            string caminho = Path.Combine(Path.GetTempPath(), "pernasTest.json");
            var pernas = new List<Perna>
        {
            new Perna { IdPerna = Guid.NewGuid(), Origem = "GRU", Destino = "BRC", Custo = 10 },
            new Perna { IdPerna = Guid.NewGuid(), Origem = "BRC", Destino = "SCL", Custo = 5 }
        };

            string json = JsonSerializer.Serialize(pernas, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(caminho, json);

            // Act
            var resultado = repo.ObterPernasJson(caminho);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(pernas.Count, resultado.Count);
            Assert.Equal(pernas[0].Origem, resultado[0].Origem);
            Assert.Equal(pernas[0].Destino, resultado[0].Destino);
            Assert.Equal(pernas[0].Custo, resultado[0].Custo);

            // Cleanup
            if (File.Exists(caminho))
            {
                File.Delete(caminho);
            }
        }

        [Fact]
        public void ObterPernasJson_RetornaListaVaziaSeArquivoNaoExiste()
        {
            // Arrange
            var repo = new PernaRepo();
            string caminho = Path.Combine(Path.GetTempPath(), "pernasNaoExistente.json");

            // Act
            var resultado = repo.ObterPernasJson(caminho);

            // Assert
            Assert.NotNull(resultado);
            Assert.Empty(resultado);
        }

        [Fact]
        public void ObterPernasJson_RetornaListaVaziaParaJsonVazio()
        {
            // Arrange
            var repo = new PernaRepo();
            string caminho = Path.Combine(Path.GetTempPath(), "pernasVazio.json");
            File.WriteAllText(caminho, ""); // Cria um arquivo JSON vazio.

            // Act
            var resultado = repo.ObterPernasJson(caminho);

            // Assert
            Assert.NotNull(resultado);
            Assert.Empty(resultado);

            // Cleanup
            if (File.Exists(caminho))
            {
                File.Delete(caminho);
            }
        }
    }

}

