using Biblioteca;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MenuPrincipal
{
    public partial class EditarClube : Form
    {
        MenuPrincipal form;
        DadosClube editado;
        List<DadosClube> Clubes;

        public EditarClube(MenuPrincipal Form, DadosClube Editado, List<DadosClube> clubes)
        {
            InitializeComponent();
            form = Form;
            editado = Editado;
            Clubes = clubes;

            txtId.Text = editado.IdClube;
            txtNome.Text = editado.Nome;
            txtTreinador.Text = editado.Treinador;
            txtEstadio.Text = editado.Estadio;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            form.EstadobtnEditar();
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

            string nomes = txtNome.Text.Trim();
            string treinadores = txtTreinador.Text.Trim();
            string estadios = txtEstadio.Text.Trim();

            //Verificar se a informação inserida já existe na lista Clubes
            if (VerificarCaixas(nomes, treinadores, estadios) == true)
            {
                MessageBox.Show("Nome, Treinador ou Estádio inserido já existe no campenonato, por favor introduza outro!!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Text = string.Empty;
                txtTreinador.Text = string.Empty;
                txtEstadio.Text = string.Empty;

                return;
            }

            editado.Nome = nomes;
            editado.Treinador = treinadores;
            editado.Estadio = estadios;

            form.EstadobtnEditar();
            form.PreencherListBoxClubes();
            form.VerificarClubes();
            this.Close();
        }

        //Verificar se caracteres são apenas inseridas letras ou espaços
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

        //Verificar se caracteres são apenas inseridas letras ou espaços
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

        //Verificar se caracteres são apenas inseridas letras ou espaços
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

            for (int i = 0; repetido != true && i < Clubes.Count; i++)
            {
                var campos = Clubes[i].ToString().Split(';');
                string id = campos[0];
                string nome = campos[1];
                string treinador = campos[2];
                string estadio = campos[3];

                if (editado.IdClube != id)
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
            form.EstadobtnEditar();
        }
    }
}
