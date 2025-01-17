using Contracts.Repositories.Repo;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repositories.Repo
{
    public class MelhorTrajetoRepo :IMelhorTrajetoRepo
    {

        public void GerarMelhorTrajetoJson(string caminho, List<MelhorTrajeto> trajetos)
        {
            try
            {
                string json = JsonSerializer.Serialize(trajetos, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(caminho, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gerar o arquivo JSON: {ex.Message}");
            }
        }
    }
}
