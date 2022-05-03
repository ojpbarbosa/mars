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
                mensagemStatusLabel.Text = $"Registro {lista.PosicaoAtual + 1}/{lista.Tamanho}";
            }

            else
            {
                LimparCampos();
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
                mensagemStatusLabel.Text = $"Registro {lista.PosicaoAtual + 1}/{lista.Tamanho}";
            }

            else
            {
                LimparCampos();
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


            if (cidade != null)
            {
                PopularCampos(cidade);

                cidadesListBox.SetSelected(lista.PosicaoAtual, true);
                mensagemStatusLabel.Text = $"Registro {lista.PosicaoAtual + 1}/{lista.Tamanho}";
            }

            else
            {
                LimparCampos();
            }
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

            if (cidade != null)
            {
                PopularCampos(cidade);

                cidadesListBox.SetSelected(lista.PosicaoAtual, true);
                mensagemStatusLabel.Text = $"Registro {lista.PosicaoAtual + 1}/{lista.Tamanho}";
            }

            else
            {
                LimparCampos();
            }
        }

        private void procurarButton_Click(object sender, EventArgs e) // repensar lógica
        {
            if (codigoCidadeTextBox.Text == "")
            {
                MessageBox.Show("Código de cidade inválido!");
            }

            else
            {
                Cidade cidadeASerProcurada = new Cidade(
                    codigoCidadeTextBox.Text.PadLeft(3, ' '),
                    nomeCidadeTextBox.Text.PadRight(15, ' '),
                    xNumericUpDown.Value,
                    yNumericUpDown.Value
                );

                if (lista.Existe(cidadeASerProcurada, out int ondeEsta))
                {
                    cidadesListBox.SetSelected(ondeEsta, true); // Foca o elemento procurado no listBox
                    mensagemStatusLabel.Text = $"Registro {lista.PosicaoAtual + 1}/{lista.Tamanho}";
                }

                else
                {
                    LimparCampos();
                    mensagemStatusLabel.Text = "Registro inexistente!";
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
                    codigoCidadeTextBox.Text.PadLeft(3, ' '),
                    nomeCidadeTextBox.Text.PadRight(15, ' '),
                    xNumericUpDown.Value,
                    yNumericUpDown.Value
                );

                lista.Excluir(cidadeASerExcluida);
                lista.ExibirDados(cidadesListBox);
                lista.PosicionarNoPrimeiro();

                if (lista.PosicaoAtual != -1)
                {
                    cidadesListBox.SetSelected(lista.PosicaoAtual, true);
                    mensagemStatusLabel.Text = $"Registro {lista.PosicaoAtual + 1}/{lista.Tamanho}";
                }
            }
        }

        private void novoButton_Click(object sender, EventArgs e)
        {
            cidadesListBox.Enabled = inicioButton.Enabled = anteriorButton.Enabled =
                proximoButton.Enabled = ultimoButton.Enabled = procurarButton.Enabled =
                    novoButton.Enabled = excluirButton.Enabled = sairButton.Enabled = false; // desativa o list box e os botões

            cancelarButton.Enabled = salvarButton.Enabled = true;

            LimparCampos(); // limpa os campos

            codigoCidadeTextBox.Focus();
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            cidadesListBox.Enabled = inicioButton.Enabled = anteriorButton.Enabled =
                    proximoButton.Enabled = ultimoButton.Enabled = procurarButton.Enabled =
                        novoButton.Enabled = excluirButton.Enabled = sairButton.Enabled = true; // ativa o list box e os botões

            cancelarButton.Enabled = salvarButton.Enabled = false;

            LimparCampos(); // limpa os campos

            lista.PosicionarNoPrimeiro();
            
            cidadesListBox.SetSelected(lista.PosicaoAtual, true);
            mensagemStatusLabel.Text = $"Registro {lista.PosicaoAtual + 1}/{lista.Tamanho}";
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            if (codigoCidadeTextBox.Text == "" || nomeCidadeTextBox.Text == "" ||
                xNumericUpDown.Value == 0 || yNumericUpDown.Value == 0)
            {
                MessageBox.Show("Campos inválidos!");
            }

            else
            {
                Cidade cidadeASerCriada = new Cidade(
                    codigoCidadeTextBox.Text.PadLeft(3, ' '),
                    nomeCidadeTextBox.Text.PadRight(15, ' '),
                    xNumericUpDown.Value,
                    yNumericUpDown.Value
                );

                if (!lista.Existe(cidadeASerCriada, out _))
                {
                    if (lista.Incluir(cidadeASerCriada))
                    {
                        cidadesListBox.Enabled = inicioButton.Enabled = anteriorButton.Enabled =
                        proximoButton.Enabled = ultimoButton.Enabled = procurarButton.Enabled =
                            novoButton.Enabled = excluirButton.Enabled = sairButton.Enabled = true; // ativa o list box e os botões

                        cancelarButton.Enabled = salvarButton.Enabled = false;

                        lista.ExibirDados(cidadesListBox);

                        mensagemStatusLabel.Text = $"Registro {lista.PosicaoAtual + 1}/{lista.Tamanho}";
                    }
                }

                else
                {
                    MessageBox.Show($"Cidade com código {cidadeASerCriada.Codigo} já existente!");
                }
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
                mensagemStatusLabel.Text = $"Registro {lista.PosicaoAtual + 1}/{lista.Tamanho}";

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

        private void LimparCampos()
        {
            codigoCidadeTextBox.Text = "";
            nomeCidadeTextBox.Text = "";
            xNumericUpDown.Value = 0;
            yNumericUpDown.Value = 0;
        }
    }
}
