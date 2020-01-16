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

        public Classificacao(MenuPrincipal Form, List<DadosClube> clubes)
        {
            InitializeComponent();
            form = Form;
            Clubes = clubes;
            metodosClassificacao = new MetodosClassificacao();
            dadosClassificacao = new DadosClassificacao();
            metodosClassificacao.PreencherListaClassificacoes(clubes, dadosClassificacao.Classificacoes, dadosClassificacao);
        }
    }
}
