using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Managers;

namespace Managers
{
    public class MelhorTrajetoManager : IMelhorTrajetoManager
    {
        public MelhorTrajeto EncontrarMelhorTrajeto(string origem, string destino, List<Perna> rotas)
        {
            var visitados = new HashSet<string>();
            var MelhorTrajeto = new MelhorTrajeto { CustoTotal = int.MaxValue };
            MelhorTrajeto.Origem = origem;
            MelhorTrajeto.Destino = destino;
            EncontrarTrajetoRecursiva(origem, destino, visitados, new List<string>(), 0, MelhorTrajeto, rotas);
            return MelhorTrajeto.CustoTotal == int.MaxValue ? null : MelhorTrajeto;
        }

        private void EncontrarTrajetoRecursiva(string atual, string destino, HashSet<string> visitados, List<string> caminhoAtual, int custoAtual, 
            MelhorTrajeto MelhorTrajeto, List<Perna> rotas)
        {
            if (visitados.Contains(atual)) return;

            visitados.Add(atual);
            caminhoAtual.Add(atual);

            if (atual == destino)
            {
                if (custoAtual < MelhorTrajeto.CustoTotal)
                {
                    MelhorTrajeto.CustoTotal = custoAtual;
                    MelhorTrajeto.Caminho =  new List<string>(caminhoAtual);
                }
            }
            else
            {
                foreach (var rota in rotas.Where(r => r.Origem == atual))
                {
                    EncontrarTrajetoRecursiva(rota.Destino, destino, visitados, caminhoAtual, custoAtual + rota.Custo, MelhorTrajeto, rotas);
                }
            }

            visitados.Remove(atual);
            caminhoAtual.RemoveAt(caminhoAtual.Count - 1);
        }

    }
}
