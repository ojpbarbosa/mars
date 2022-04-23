using System;
using System.Windows.Forms;

namespace apMarte
{
    public partial class FormMarte : Form
    {
        private ListaDupla<Cidade> lista;

        public FormMarte()
        {
            InitializeComponent();
        }

        private void FormMarte_Load(object sender, EventArgs e)
        {
            int indice = 0;
            toolStrip.ImageList = imageList;

            foreach (ToolStripItem item in toolStrip.Items)
            {
                if (item is ToolStripButton)
                {
                    (item as ToolStripButton).ImageIndex = indice++;
                }     
            }

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                lista = new ListaDupla<Cidade>();

                lista.LerDados(openFileDialog.FileName);
                lista.ExibirDados(cidadesListBox);
            }
        }

        private void inicioButton_Click(object sender, EventArgs e)
        {
            lista.PosicionarNoPrimeiro();

            Cidade cidade = lista.DadoAtual();

            if (cidade != null)
            {
                codigoCidadeTextBox.Text = cidade.Codigo;
                nomeCidadeTextBox.Text = cidade.Nome;
                xNumericUpDown.Value = (decimal)cidade.X;
                yNumericUpDown.Value = (decimal)cidade.Y;

                cidadesListBox.SetSelected(lista.PosicaoAtual, true);
            }

            else
            {
                codigoCidadeTextBox.Text = "";
                nomeCidadeTextBox.Text = "";
                xNumericUpDown.Value = 0;
                yNumericUpDown.Value = 0;
            }
        }

        private void ultimoButton_Click(object sender, EventArgs e)
        {
            lista.PosicionarNoUltimo();

            Cidade cidade = lista.DadoAtual();

            if (cidade != null)
            {
                codigoCidadeTextBox.Text = cidade.Codigo;
                nomeCidadeTextBox.Text = cidade.Nome;
                xNumericUpDown.Value = (decimal)cidade.X;
                yNumericUpDown.Value = (decimal)cidade.Y;

                cidadesListBox.SetSelected(lista.PosicaoAtual, true);
            }

            else
            {
                codigoCidadeTextBox.Text = "";
                nomeCidadeTextBox.Text = "";
                xNumericUpDown.Value = 0;
                yNumericUpDown.Value = 0;
            }
        }
        
        private void anteriorButton_Click(object sender, EventArgs e)
        {
            if (lista.PosicaoAtual - 1 < 0) // Se o index for menor que zero, significa que cidade é null
            {
                codigoCidadeTextBox.Text = "";
                nomeCidadeTextBox.Text = "";
                xNumericUpDown.Value = 0;
                yNumericUpDown.Value = 0;
            }

            else
            {
                lista.PosicionarEm(lista.PosicaoAtual - 1);
                Cidade cidade = lista.DadoAtual();

                codigoCidadeTextBox.Text = cidade.Codigo;
                nomeCidadeTextBox.Text = cidade.Nome;
                xNumericUpDown.Value = (decimal)cidade.X;
                yNumericUpDown.Value = (decimal)cidade.Y;

                cidadesListBox.SelectedIndex = lista.PosicaoAtual;
            }
        }

        private void proximoButton_Click(object sender, EventArgs e)
        {
            lista.AvancarPosicao();

            Cidade cidade = lista.DadoAtual();

            if (cidade != null)
            {
                codigoCidadeTextBox.Text = cidade.Codigo;
                nomeCidadeTextBox.Text = cidade.Nome;
                xNumericUpDown.Value = (decimal)cidade.X;
                yNumericUpDown.Value = (decimal)cidade.Y;

                cidadesListBox.SelectedIndex = lista.PosicaoAtual;
            }
            
            else
            {
                codigoCidadeTextBox.Text = "";
                nomeCidadeTextBox.Text = "";
                xNumericUpDown.Value = 0;
                yNumericUpDown.Value = 0;
            }
        }

        private void procurarButton_Click(object sender, EventArgs e)
        {
            Cidade cidadeASerProcurada = new Cidade(
                codigoCidadeTextBox.Text,
                nomeCidadeTextBox.Text,
                (float)xNumericUpDown.Value,
                (float)yNumericUpDown.Value
            );

            if (lista.Existe(cidadeASerProcurada, out int ondeEsta))
            {
                cidadesListBox.SelectedIndex = ondeEsta; // Foca o elemento procurado no listBox
            }
        }

        private void excluirButton_Click(object sender, EventArgs e)
        {
            Cidade cidadeASerExcluida = new Cidade(
                codigoCidadeTextBox.Text,
                nomeCidadeTextBox.Text,
                (float)xNumericUpDown.Value,
                (float)yNumericUpDown.Value
            );

            if (lista.Existe(cidadeASerExcluida, out int ondeEsta))
            {
                lista.Excluir(cidadeASerExcluida);
                lista.ExibirDados(cidadesListBox);
            }
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {

        }
    }
}
