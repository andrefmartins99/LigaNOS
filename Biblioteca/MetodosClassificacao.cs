using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Biblioteca
{
    public class MetodosClassificacao
    {
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

            OrdenarListaClassificacoes(Classificacoes);

            return Classificacoes;
        }

        /// <summary>
        /// Ordenar a lista Classificacoes de acordo com as estatísticas dos clubes
        /// </summary>
        public void OrdenarListaClassificacoes(List<DadosClassificacao> Classificacoes)
        {
            Classificacoes.OrderByDescending(x => x.Pontos).ThenBy(x => x.DiferencaGolos).ThenBy(x => x.NumVitorias).ThenBy(x => x.GolosMarcados);
        }
    }
}
