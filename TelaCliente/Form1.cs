using ClientesCadastro.Classes;
using System;
using System.Windows.Forms;
using TelaDeConsulta;

namespace TelaCliente
{
    public partial class Form1 : Form
    {
        BindingSource dados = new BindingSource();
        public Form1()
        {
            InitializeComponent();          
        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            
            if (textBoxNome.Text != "" & textBoxTelefone.Text != "" & textBoxEmail.Text != "")
            {
                if (textBoxNome.Text.Length > 25)
                    MessageBox.Show("O capo nome nao pode ter mais que 25 caracteres!");
                else if (textBoxTelefone.Text.Length > 9)
                    MessageBox.Show("O capo telefone nao pode ter mais que 9 caracteres!");
                else if (textBoxEmail.Text.Length > 25)
                    MessageBox.Show("O capo email nao pode ter mais que 25 caracteres!");
                else
                {
                    Cliente cli = new Cliente(textBoxNome.Text, textBoxTelefone.Text, textBoxEmail.Text);
                    cli.Insert();
                    textBoxNome.Text = "";
                    textBoxTelefone.Text = "";
                    textBoxEmail.Text = "";
                    MessageBox.Show("Cliente Cadastrado com Sucesso!");
                }
            }
            else
                MessageBox.Show("Todos os campos devem ser preenchidos!");
        }

        private void buttonConsultar_Click(object sender, EventArgs e)
        {
            teladeconsulta tl = new teladeconsulta();
            if (Cliente.Todos() != null)
                tl.Show();
            else
                MessageBox.Show("Nenhum cliente cadastrado!");
        }
    }
}
