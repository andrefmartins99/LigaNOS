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
        }

        private void Campeao_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
