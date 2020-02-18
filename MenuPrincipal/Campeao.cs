using Biblioteca;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MenuPrincipal
{
    public partial class Campeao : Form
    {
        DadosClassificacao dadosClassificacao;
        MetodosClassificacao metodosClassificacao;
        List<DadosClube> Clubes;
        MenuPrincipal form;

        public Campeao(MenuPrincipal Form, List<DadosClube> clubes)
        {
            InitializeComponent();
            form = Form;
            Clubes = clubes;
            dadosClassificacao = new DadosClassificacao();
            metodosClassificacao = new MetodosClassificacao();
            dadosClassificacao.Classificacoes = metodosClassificacao.PreencherListaClassificacoes(Clubes, dadosClassificacao.Classificacoes, dadosClassificacao);

            lblCampeao.Text = $"Parabéns!!! O campeão é o {dadosClassificacao.Classificacoes[0].Nome}";
            lblEstatisticaCampeao.Text = $"Pontos: {dadosClassificacao.Classificacoes[0].Pontos}{Environment.NewLine}" +
                $"Número de vitórias: {dadosClassificacao.Classificacoes[0].NumVitorias}{Environment.NewLine}" +
                $"Número de derrotas: {dadosClassificacao.Classificacoes[0].NumDerrotas}{Environment.NewLine}" +
                $"Número de empates: {dadosClassificacao.Classificacoes[0].NumEmpates}{Environment.NewLine}" +
                $"Golos Marcados / Golos sofridos: {dadosClassificacao.Classificacoes[0].GolosMarcados} / {dadosClassificacao.Classificacoes[0].GolosSofridos}{Environment.NewLine}" +
                $"Diferença de golos: {dadosClassificacao.Classificacoes[0].DiferencaGolos}";
        }

        private void Campeao_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.NaoFinalizar();
        }

        private void btnTerminarCampeonato_Click(object sender, EventArgs e)
        {
            DialogResult resposta;

            resposta = MessageBox.Show("Ao terminar o campeonato todos os clubes, jogos e jornadas vão ser apagados e o programa vai terminar.", "Terminar campeonato", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (resposta == DialogResult.Yes)
            {
                form.ApagarClubesJogosJornadas();
                Application.Exit();
            }
        }
    }
}
