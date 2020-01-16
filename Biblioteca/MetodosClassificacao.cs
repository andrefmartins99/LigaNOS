using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Biblioteca
{
    public class MetodosClassificacao
    {
        public void PreencherListaClassificacoes(List<DadosClube> Clubes, List<DadosClassificacao> Classificacoes, DadosClassificacao dadosClassificacao)
        {
            Classificacoes = new List<DadosClassificacao>();

            foreach (var clube in Clubes)
            {
                var campos = clube.ToString().Split(';');

                dadosClassificacao = new DadosClassificacao();

                dadosClassificacao.Nome = campos[1];
                dadosClassificacao.Pontos = clube.Pontos;
                dadosClassificacao.NumJogos = clube.NumJogos;
            }
        }

        /// <summary>
        /// Ordenar a lista Classificacoes de acordo com as estatísticas dos clubes
        /// </summary>
        public void OrdenarListaClassificacoes(DadosClassificacao classificacao)
        {
            for (int i = 0; i < classificacao.Classificacoes.Count; i++)
            {
                var infoi = classificacao.Classificacoes[i].ToString().Split(';');
                int pontosi = Convert.ToInt32(infoi[1]);
                int numVitoriasi = Convert.ToInt32(infoi[3]);
                int golosMarcadosi = Convert.ToInt32(infoi[6]);
                int diferencaGolosi = Convert.ToInt32(infoi[8]);

                for (int j = i + 1; j < classificacao.Classificacoes.Count; j++)
                {
                    var infoj = classificacao.Classificacoes[j].ToString().Split(';');
                    int pontosj = Convert.ToInt32(infoj[1]);
                    int numVitoriasj = Convert.ToInt32(infoj[3]);
                    int golosMarcadosj = Convert.ToInt32(infoj[6]);
                    int diferencaGolosj = Convert.ToInt32(infoj[8]);
                    DadosClassificacao aux;

                    if (pontosj > pontosi)
                    {
                        aux = classificacao.Classificacoes[j];
                        classificacao.Classificacoes[j] = classificacao.Classificacoes[i];
                        classificacao.Classificacoes[i] = aux;
                        pontosi = pontosj;
                        diferencaGolosi = diferencaGolosj;
                        numVitoriasi = numVitoriasj;
                        golosMarcadosi = golosMarcadosj;
                    }
                    else if (pontosj == pontosi)
                    {
                        if (diferencaGolosj > diferencaGolosi)
                        {
                            aux = classificacao.Classificacoes[j];
                            classificacao.Classificacoes[j] = classificacao.Classificacoes[i];
                            classificacao.Classificacoes[i] = aux;
                            pontosi = pontosj;
                            diferencaGolosi = diferencaGolosj;
                            numVitoriasi = numVitoriasj;
                            golosMarcadosi = golosMarcadosj;
                        }
                        else if (diferencaGolosj == diferencaGolosi)
                        {
                            if (numVitoriasj > numVitoriasi)
                            {
                                aux = classificacao.Classificacoes[j];
                                classificacao.Classificacoes[j] = classificacao.Classificacoes[i];
                                classificacao.Classificacoes[i] = aux;
                                pontosi = pontosj;
                                diferencaGolosi = diferencaGolosj;
                                numVitoriasi = numVitoriasj;
                                golosMarcadosi = golosMarcadosj;
                            }
                            else if (numVitoriasj == numVitoriasi)
                            {
                                if (golosMarcadosj > golosMarcadosi)
                                {
                                    aux = classificacao.Classificacoes[j];
                                    classificacao.Classificacoes[j] = classificacao.Classificacoes[i];
                                    classificacao.Classificacoes[i] = aux;
                                    pontosi = pontosj;
                                    diferencaGolosi = diferencaGolosj;
                                    numVitoriasi = numVitoriasj;
                                    golosMarcadosi = golosMarcadosj;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
