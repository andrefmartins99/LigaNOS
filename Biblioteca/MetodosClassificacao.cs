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

            Classificacoes = OrdenarListaClassificacoes(Classificacoes);

            return Classificacoes;
        }

        /// <summary>
        /// Ordenar a lista Classificacoes de acordo com as estatísticas dos clubes
        /// </summary>
        public List<DadosClassificacao> OrdenarListaClassificacoes(List<DadosClassificacao> Classificacoes)
        {
            return Classificacoes.OrderByDescending(x => x.Pontos).ThenByDescending(x => x.DiferencaGolos).ThenByDescending(x => x.NumVitorias).ThenByDescending(x => x.GolosMarcados).ToList();
        }
    }
}
