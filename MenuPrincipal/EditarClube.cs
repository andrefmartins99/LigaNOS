using Biblioteca;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MenuPrincipal
{
    public partial class EditarClube : Form
    {
        public MenuPrincipal MenuPrincipal { get; set; }

        public DadosClube Editado { get; set; }

        public EditarClube(MenuPrincipal Form, DadosClube editado)
        {
            InitializeComponent();
            MenuPrincipal = Form;
            Editado = editado;

            txtId.Text = Editado.IdClube;
            txtNome.Text = Editado.Nome;
            txtTreinador.Text = Editado.Treinador;
            txtEstadio.Text = Editado.Estadio;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MenuPrincipal.EstadobtnEditar();
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Verificar se os campos a preencher estão vazios
            if (string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrEmpty(txtTreinador.Text) || string.IsNullOrEmpty(txtEstadio.Text))
            {
                MessageBox.Show("Tem de preencher todos os campos!!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nome = txtNome.Text.Trim();
            string treinador = txtTreinador.Text.Trim();
            string estadio = txtEstadio.Text.Trim();

            //Verificar se a informação inserida já existe na lista Clubes
            if (VerificarCaixas(nome, treinador, estadio) == true)
            {
                MessageBox.Show("Nome, Treinador ou Estádio inserido já existe no campenonato, por favor introduza outro!!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Text = string.Empty;
                txtTreinador.Text = string.Empty;
                txtEstadio.Text = string.Empty;

                return;
            }

            Editado.Nome = nome;
            Editado.Treinador = treinador;
            Editado.Estadio = estadio;

            MenuPrincipal.EstadobtnEditar();
            MenuPrincipal.PreencherListBoxClubes();
            MenuPrincipal.VerificarClubes();
            this.Close();
        }

        //Verificar se caracteres inseridos são apenas letras ou espaços
        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < txtNome.TextLength; i++)
            {
                if (!(char.IsLetter(txtNome.Text[i]) || txtNome.Text[i] == 32))
                {
                    txtNome.Text = string.Empty;
                }
            }
        }

        //Verificar se caracteres inseridos são apenas letras ou espaços
        private void txtTreinador_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < txtTreinador.TextLength; i++)
            {
                if (!(char.IsLetter(txtTreinador.Text[i]) || txtTreinador.Text[i] == 32))
                {
                    txtTreinador.Text = string.Empty;
                }
            }
        }

        //Verificar se caracteres inseridos são apenas letras ou espaços
        private void txtEstadio_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < txtEstadio.TextLength; i++)
            {
                if (!(char.IsLetter(txtEstadio.Text[i]) || txtEstadio.Text[i] == 32))
                {
                    txtEstadio.Text = string.Empty;
                }
            }
        }

        //Verificar se a informação inserida já existe na lista Clubes
        public bool VerificarCaixas(string nomes, string treinadores, string estadios)
        {
            bool repetido = false;

            for (int i = 0; repetido != true && i < MenuPrincipal.Clubes.Count; i++)
            {
                string id = MenuPrincipal.Clubes[i].IdClube;
                string nome = MenuPrincipal.Clubes[i].Nome;
                string treinador = MenuPrincipal.Clubes[i].Treinador;
                string estadio = MenuPrincipal.Clubes[i].Estadio;

                if (Editado.IdClube != id)
                {
                    if (nome.ToLower() == nomes.ToLower() || treinador.ToLower() == treinadores.ToLower() || estadio.ToLower() == estadios.ToLower())
                    {
                        return true;
                    }
                }
            }

            return repetido;
        }

        private void EditarEquipa_FormClosing(object sender, FormClosingEventArgs e)
        {
            MenuPrincipal.EstadobtnEditar();
        }
    }
}
