using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca;

namespace MenuPrincipal
{
    public partial class Classificacao : Form
    {
        DadosClassificacao dadosClassificacao;
        MetodosClassificacao metodosClassificacao;
        List<DadosClube> Clubes;
        MenuPrincipal form;
        int posicao = 1;

        public Classificacao(MenuPrincipal Form, List<DadosClube> clubes)
        {
            InitializeComponent();
            form = Form;
            Clubes = clubes;
            metodosClassificacao = new MetodosClassificacao();
            dadosClassificacao = new DadosClassificacao();
            dadosClassificacao.Classificacoes = metodosClassificacao.PreencherListaClassificacoes(Clubes, dadosClassificacao.Classificacoes, dadosClassificacao);
            PreencherDataGridViewClassificacao();
        }

        public void PreencherDataGridViewClassificacao()
        {

            foreach (var clube in dadosClassificacao.Classificacoes)
            {
                string[] row = { posicao.ToString(), clube.Nome, clube.Pontos.ToString(), clube.NumJogos.ToString(), clube.NumVitorias.ToString(), clube.NumDerrotas.ToString(), clube.NumEmpates.ToString(), clube.GolosMarcados.ToString(), clube.GolosSofridos.ToString(), clube.DiferencaGolos.ToString() };

                dgvClassificacao.Rows.Add(row);
                posicao++;
            }

            dgvClassificacao.ClearSelection();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            form.EstadoBtnVoltar();
            this.Close();
        }

        private void Classificacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.EstadoBtnVoltar();
        }
    }
}
