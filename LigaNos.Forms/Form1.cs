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

namespace LigaNos.Forms
{
    public partial class Form1 : Form
    {
        DadosClube dadosClube;
        MetodosClube clube;
        List<string> clubes;
        int contaCLubes = 0;

        public Form1()
        {
            clubes = new List<string>();
            clube = new MetodosClube();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clubes = clube.LerFicheiroClubes(clubes, dadosClube);
            contaCLubes = clubes.Count;
            lblclubeInfo.Text = $"{contaCLubes.ToString()} de 8 clubes";
            PreencherListBoxClubes();

            if (contaCLubes < 8)
            {
                btnCriarClube.Visible = true;
            }
        }

        public void PreencherListBoxClubes()
        {
            listBoxClubes.DataSource = null;
            listBoxClubes.DataSource = clubes;
        }
    }
}
