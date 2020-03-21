using System.Collections.Generic;
using System.Linq;

namespace Biblioteca
{
    public static class MetodosClassificacao
    {
        /// <summary>
        /// Ordenar por pontos, diferença de golos, número de vitórias e golos marcados descendentemente
        /// </summary>
        /// <param name="Clubes">lista de clubes</param>
        /// <returns>Retorna a lista de clubes ordenada, pronta para ser exibida na classificação</returns>
        public static List<DadosClube> OrdenarListaClubes(List<DadosClube> Clubes)
        {
            return Clubes.OrderByDescending(x => x.Pontos).ThenByDescending(x => x.DiferencaGolos).ThenByDescending(x => x.NumVitorias).ThenByDescending(x => x.GolosMarcados).ToList();
        }
    }
}
