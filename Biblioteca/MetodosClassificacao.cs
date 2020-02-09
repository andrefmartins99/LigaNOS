using System.Collections.Generic;
using System.Linq;

namespace Biblioteca
{
    public class MetodosClassificacao
    {
        //Preencher a lista Classificações a partir da lista Clubes
        public List<DadosClassificacao> PreencherListaClassificacoes(List<DadosClube> Clubes, List<DadosClassificacao> Classificacoes, DadosClassificacao dadosClassificacao)
        {
            Classificacoes = new List<DadosClassificacao>();

            foreach (var clube in Clubes)
            {
                dadosClassificacao = new DadosClassificacao();

                dadosClassificacao.Nome = clube.Nome;
                dadosClassificacao.Pontos = clube.Pontos;
                dadosClassificacao.NumJogos = clube.NumJogos;
                dadosClassificacao.NumVitorias = clube.NumVitorias;
                dadosClassificacao.NumDerrotas = clube.NumDerrotas;
                dadosClassificacao.NumEmpates = clube.NumEmpates;
                dadosClassificacao.GolosMarcados = clube.GolosMarcados;
                dadosClassificacao.GolosSofridos = clube.GolosSofridos;

                Classificacoes.Add(dadosClassificacao);
            }

            Classificacoes = OrdenarListaClassificacoes(Classificacoes);

            return Classificacoes;
        }

        //Ordenar a lista Classificações por pontos, diferença de golos, número de vitórias e golos marcados descendentemente
        public List<DadosClassificacao> OrdenarListaClassificacoes(List<DadosClassificacao> Classificacoes)
        {
            return Classificacoes.OrderByDescending(x => x.Pontos).ThenByDescending(x => x.DiferencaGolos).ThenByDescending(x => x.NumVitorias).ThenByDescending(x => x.GolosMarcados).ToList();
        }
    }
}
