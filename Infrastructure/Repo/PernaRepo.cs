using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities.Models;
using Contracts.Repositories.Repo;

namespace Repositories.Repo
{
    public class PernaRepo : IPernaRepo
    {
        public void GerarPernaJson(string caminho, List<Perna> pernas)
        {
            try
            {
                string json = JsonSerializer.Serialize(pernas, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(caminho, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gerar o arquivo JSON: {ex.Message}");
            }
        }

        public List<Perna> ObterPernasJson(string caminho)
        {
            try
            {
                if (!File.Exists(caminho)) return new List<Perna>();

                string json = File.ReadAllText(caminho);

                if (string.IsNullOrWhiteSpace(json))
                {
                    return new List<Perna>();
                }

                return JsonSerializer.Deserialize<List<Perna>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler o arquivo JSON: {ex.Message}");
                return new List<Perna>();
            }
        }

    }
}
