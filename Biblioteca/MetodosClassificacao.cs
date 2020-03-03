using System.Collections.Generic;
using System.Linq;

namespace Biblioteca
{
    public static class MetodosClassificacao
    {
        //Ordenar a lista Classificações por pontos, diferença de golos, número de vitórias e golos marcados descendentemente
        public static List<DadosClube> OrdenarListaClubes(List<DadosClube> Clubes)
        {
            return Clubes.OrderByDescending(x => x.Pontos).ThenByDescending(x => x.DiferencaGolos).ThenByDescending(x => x.NumVitorias).ThenByDescending(x => x.GolosMarcados).ToList();
        }
    }
}
