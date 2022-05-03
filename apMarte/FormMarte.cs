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
                PopularCampos(cidade);

                cidadesListBox.SetSelected(lista.PosicaoAtual, true);
            }

            else
            {
                PopularCampos(new Cidade("", "", 0, 0));
            }
        }

        private void ultimoButton_Click(object sender, EventArgs e)
        {
            lista.PosicionarNoUltimo();

            Cidade cidade = lista.DadoAtual();

            if (cidade != null)
            {
                PopularCampos(cidade);

                cidadesListBox.SetSelected(lista.PosicaoAtual, true);
            }

            else
            {
                PopularCampos(new Cidade("", "", 0, 0));
            }
        }

        private void anteriorButton_Click(object sender, EventArgs e)
        {
            lista.RetrocederPosicao();

            Cidade cidade = lista.DadoAtual();

            if (cidade == null)
            {
                lista.PosicionarNoUltimo();

                cidade = lista.DadoAtual();
            }

            PopularCampos(cidade);

            cidadesListBox.SetSelected(lista.PosicaoAtual, true);
        }

        private void proximoButton_Click(object sender, EventArgs e)
        {
            lista.AvancarPosicao();

            Cidade cidade = lista.DadoAtual();

            if (cidade == null)
            {
                lista.PosicionarNoPrimeiro();

                cidade = lista.DadoAtual();
            }

            PopularCampos(cidade);

            cidadesListBox.SetSelected(lista.PosicaoAtual, true);
        }

        private void procurarButton_Click(object sender, EventArgs e)
        {
            if (codigoCidadeTextBox.Text == "")
            {
                MessageBox.Show("Código de cidade inválido!");
            }

            else
            {
                Cidade cidadeASerProcurada = new Cidade(
                    codigoCidadeTextBox.Text,
                    nomeCidadeTextBox.Text,
                    xNumericUpDown.Value,
                    yNumericUpDown.Value
                );

                if (lista.Existe(cidadeASerProcurada, out int ondeEsta))
                {
                    cidadesListBox.SetSelected(ondeEsta, true); // Foca o elemento procurado no listBox
                }
            }
        }

        private void excluirButton_Click(object sender, EventArgs e)
        {
            if (codigoCidadeTextBox.Text == "")
            {
                MessageBox.Show("Código de cidade inválido!");
            }

            else
            {
                Cidade cidadeASerExcluida = new Cidade(
                    codigoCidadeTextBox.Text,
                    nomeCidadeTextBox.Text,
                    xNumericUpDown.Value,
                    yNumericUpDown.Value
                );

                lista.Excluir(cidadeASerExcluida);
                lista.ExibirDados(cidadesListBox);
                lista.PosicionarNoPrimeiro();

                if (lista.PosicaoAtual != -1)
                {
                    cidadesListBox.SetSelected(lista.PosicaoAtual, true);
                }
            }
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.FileName != "")
            {
                lista.GravarDados(openFileDialog.FileName);
            }
        }

        private void sairButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.FileName != "")
            {
                lista.GravarDados(openFileDialog.FileName);
            }

            Close();
        }

        private void cidadesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lista.Tamanho > 0)
            {
                lista.PosicionarEm(cidadesListBox.SelectedIndex);

                Cidade cidadeSelecionada = lista.DadoAtual();
                
                PopularCampos(cidadeSelecionada);
            }
        }

        private void mapaPictureBox_Paint(object sender, PaintEventArgs e)
        {
        }

        private void FormMarte_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (openFileDialog.FileName != "")
            {
                lista.GravarDados(openFileDialog.FileName);
            }
        }

        private void PopularCampos(Cidade cidade)
        {
            codigoCidadeTextBox.Text = cidade.Codigo;
            nomeCidadeTextBox.Text = cidade.Nome;
            xNumericUpDown.Value = cidade.X;
            yNumericUpDown.Value = cidade.Y;
        }
    }
}
