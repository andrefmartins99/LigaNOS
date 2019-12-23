using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Biblioteca
{
    public class Classificacao
    {
        //Propriedades

        public int Posicao { get; set; }

        public List<string> Classificacoes { get; set; }


        //Métodos

        /// <summary>
        /// Preencher a lista Classificacoes com as estatísticas dos clubes
        /// </summary>
        private void PreencherListaClassificacoes()
        {
            string ficheiro = "estatisticaClube.txt";
            var linha = File.ReadAllLines(ficheiro);
            Classificacoes = new List<string>();

            foreach (var linhas in linha)
            {
                Classificacoes.Add(linhas);
            }
        }

        /// <summary>
        /// Ordenar a lista Classificacoes de acordo com as estatísticas dos clubes
        /// </summary>
        private void OrdenarListaClassificacoes()
        {
            for (int i = 0; i < Classificacoes.Count; i++)
            {
                var infoi = Classificacoes[i].Split(';');
                int pontosi = Convert.ToInt32(infoi[1]);
                int numVitoriasi = Convert.ToInt32(infoi[3]);
                int golosMarcadosi = Convert.ToInt32(infoi[6]);
                int diferencaGolosi = Convert.ToInt32(infoi[8]);

                for (int j = i + 1; j < Classificacoes.Count; j++)
                {
                    var infoj = Classificacoes[j].Split(';');
                    int pontosj = Convert.ToInt32(infoj[1]);
                    int numVitoriasj = Convert.ToInt32(infoj[3]);
                    int golosMarcadosj = Convert.ToInt32(infoj[6]);
                    int diferencaGolosj = Convert.ToInt32(infoj[8]);
                    string aux;

                    if (pontosj > pontosi)
                    {
                        aux = Classificacoes[j];
                        Classificacoes[j] = Classificacoes[i];
                        Classificacoes[i] = aux;
                        pontosi = pontosj;
                        diferencaGolosi = diferencaGolosj;
                        numVitoriasi = numVitoriasj;
                        golosMarcadosi = golosMarcadosj;
                    }
                    else if (pontosj == pontosi)
                    {
                        if (diferencaGolosj > diferencaGolosi)
                        {
                            aux = Classificacoes[j];
                            Classificacoes[j] = Classificacoes[i];
                            Classificacoes[i] = aux;
                            pontosi = pontosj;
                            diferencaGolosi = diferencaGolosj;
                            numVitoriasi = numVitoriasj;
                            golosMarcadosi = golosMarcadosj;
                        }
                        else if (diferencaGolosj == diferencaGolosi)
                        {
                            if (numVitoriasj > numVitoriasi)
                            {
                                aux = Classificacoes[j];
                                Classificacoes[j] = Classificacoes[i];
                                Classificacoes[i] = aux;
                                pontosi = pontosj;
                                diferencaGolosi = diferencaGolosj;
                                numVitoriasi = numVitoriasj;
                                golosMarcadosi = golosMarcadosj;
                            }
                            else if (numVitoriasj == numVitoriasi)
                            {
                                if (golosMarcadosj > golosMarcadosi)
                                {
                                    aux = Classificacoes[j];
                                    Classificacoes[j] = Classificacoes[i];
                                    Classificacoes[i] = aux;
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
