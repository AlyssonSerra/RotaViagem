using System;
using System.Collections.Generic;
using Xunit;
using Managers;
using Entities.Models;
using Contracts.Managers;


namespace Teste
{
    public class MelhorTrajetoManagerTests
    {
        [Fact]
        public void EncontrarMelhorTrajeto_DeveRetornarMelhorTrajeto_CasoValido()
        {
            // Arrange
            var manager = new MelhorTrajetoManager();
            var rotas = new List<Perna>
        {
            new Perna { Origem = "GRU", Destino = "BRC", Custo = 10 },
            new Perna { Origem = "BRC", Destino = "SCL", Custo = 5 },
            new Perna { Origem = "GRU", Destino = "SCL", Custo = 20 },
            new Perna { Origem = "SCL", Destino = "ORL", Custo = 20 },
            new Perna { Origem = "ORL", Destino = "CDG", Custo = 5 },
            new Perna { Origem = "GRU", Destino = "CDG", Custo = 75 },
        };

            // Act
            var melhorTrajeto = manager.EncontrarMelhorTrajeto("GRU", "CDG", rotas);

            // Assert
            Assert.NotNull(melhorTrajeto);
            Assert.Equal(40, melhorTrajeto.CustoTotal);
            Assert.Equal(new List<string> { "GRU", "BRC", "SCL", "ORL", "CDG" }, melhorTrajeto.Caminho);
        }

        [Fact]
        public void EncontrarMelhorTrajeto_DeveRetornarNull_SeNaoHaCaminho()
        {
            // Arrange
            var manager = new MelhorTrajetoManager();
            var rotas = new List<Perna>
        {
            new Perna { Origem = "GRU", Destino = "BRC", Custo = 10 },
            new Perna { Origem = "BRC", Destino = "SCL", Custo = 5 }
        };

            // Act
            var melhorTrajeto = manager.EncontrarMelhorTrajeto("GRU", "CDG", rotas);

            // Assert
            Assert.Null(melhorTrajeto);
        }

        [Fact]
        public void EncontrarMelhorTrajeto_DeveRetornarTrajetoDireto_SeExistir()
        {
            // Arrange
            var manager = new MelhorTrajetoManager();
            var rotas = new List<Perna>
        {
            new Perna { Origem = "GRU", Destino = "CDG", Custo = 50 },
            new Perna { Origem = "GRU", Destino = "BRC", Custo = 10 },
            new Perna { Origem = "BRC", Destino = "CDG", Custo = 70 }
        };

            // Act
            var melhorTrajeto = manager.EncontrarMelhorTrajeto("GRU", "CDG", rotas);

            // Assert
            Assert.NotNull(melhorTrajeto);
            Assert.Equal(50, melhorTrajeto.CustoTotal);
            Assert.Equal(new List<string> { "GRU", "CDG" }, melhorTrajeto.Caminho);
        }

        [Fact]
        public void EncontrarMelhorTrajeto_DeveTratarRotasComCustoAlto()
        {
            // Arrange
            var manager = new MelhorTrajetoManager();
            var rotas = new List<Perna>
        {
            new Perna { Origem = "GRU", Destino = "BRC", Custo = 1000 },
            new Perna { Origem = "BRC", Destino = "SCL", Custo = 5000 },
            new Perna { Origem = "SCL", Destino = "CDG", Custo = 3000 },
            new Perna { Origem = "GRU", Destino = "CDG", Custo = 8000 }
        };

            // Act
            var melhorTrajeto = manager.EncontrarMelhorTrajeto("GRU", "CDG", rotas);

            // Assert
            Assert.NotNull(melhorTrajeto);
            Assert.Equal(8000, melhorTrajeto.CustoTotal);
            Assert.Equal(new List<string> { "GRU", "CDG" }, melhorTrajeto.Caminho);
        }

        [Fact]
        public void EncontrarMelhorTrajeto_DeveRetornarNull_SeOrigemIgualDestino()
        {
            // Arrange
            var manager = new MelhorTrajetoManager();
            var rotas = new List<Perna>
        {
            new Perna { Origem = "GRU", Destino = "BRC", Custo = 10 }
        };

            // Act
            var melhorTrajeto = manager.EncontrarMelhorTrajeto("GRU", "GRU", rotas);

            // Assert
            Assert.Null(melhorTrajeto);
        }
    }

}
