using System;
using System.IO;
using System.Windows.Forms;

class ListaDupla<Dado> : IDados<Dado>
                where Dado : IComparable<Dado>, IRegistro<Dado>, new()
{
    NoDuplo<Dado> primeiro, ultimo, atual;
    int quantosNos;

    public ListaDupla()
    {
        primeiro = ultimo = atual = null;
        quantosNos = 0; 
    }

    public Situacao SituacaoAtual { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int PosicaoAtual { 
        get 
        { 
            Existe(atual.Info, out int posicao); 
            return posicao;
        }
        set => throw new NotImplementedException(); 
    }
    public bool EstaNoInicio { get => atual == primeiro; }
    public bool EstaNoFim { get => atual == ultimo; }
    public bool EstaVazio { get => quantosNos == 0; }          // (bool) Verificar se está vazia
    public int Tamanho { get => quantosNos; }

    public void LerDados(string nomeArquivo)    // fará a leitura e armazenamento dos dados do arquivo cujo nome é passado por parâmetro
    {
        if (nomeArquivo != null)
        {
            StreamReader arquivo = new StreamReader(nomeArquivo);

            while (!arquivo.EndOfStream)
            {
                Dado dado = new Dado().LerRegistro(arquivo);

                IncluirAposFim(dado);
            }
        }
    }

    public void GravarDados(string nomeArquivo)  // gravará sequencialmente, no arquivo cujo nome é passado por parâmetro, os dados armazenados na lista
    {
        if (nomeArquivo != null)
        {
            StreamWriter arquivo = new StreamWriter(nomeArquivo);

            while (!EstaNoFim)
            {
                DadoAtual().GravarRegistro(arquivo);

                AvancarPosicao();
            }
        }
    }

    public void PosicionarNoPrimeiro()        // Posicionar atual no primeiro nó para ser acessado
    {
        atual = primeiro;
    }

    public void RetrocederPosicao()        // Retroceder atual para o nó anterior para ser acessado
    {
        if (atual != null)
        {
            atual = atual.Ant;
        }
    }

    public void AvancarPosicao()
    {
        if (atual != null)
        {
            atual = atual.Prox;
        }
    }

    public void PosicionarNoUltimo()        // posicionar atual no último nó para ser acessado
    {
        atual = ultimo;
    }

    public void PosicionarEm(int posicaoDesejada)
    {
        PosicionarNoPrimeiro();

        for (int i = 0; i < posicaoDesejada; i++)
        {
            if (atual != null)
            {
                atual = atual.Prox;
            }
        }
    }

    // (bool) Pesquisar Dado procurado em ordem crescente; a pesquisa
    // posicionará o ponteiro atual no nó procurado quando este
    // or encontrado ou, se não achar, no nó seguinte a local
    // onde deveria estar o nó procurado
    public bool Existe(Dado procurado, out int ondeEsta)
    {
        PosicionarNoPrimeiro();

        if (EstaVazio || procurado == null)
        {
            ondeEsta = -1;

            return false;
        }

        if (procurado.CompareTo(primeiro.Info) < 0)
        {
            ondeEsta = -1;

            return false;
        }

        if (procurado.CompareTo(ultimo.Info) > 0)
        {
            PosicionarNoUltimo();

            ondeEsta = -1;

            return false;
        }

        bool achou = false, fim = false;

        ondeEsta = 0;
        
        while (!achou && !fim)
        {
            if (atual == null)
            {
                fim = true;
            }

            else
            {
                if (procurado.CompareTo(atual.Info) == 0)
                {
                    achou = true;
                }

                else
                {
                    if (procurado.CompareTo(atual.Info) > 0)
                    {
                        fim = true;
                    }

                    else
                    {
                        AvancarPosicao();

                        ondeEsta++;
                    }
                }
            }
        }

        return achou;
    }

    public bool Excluir(Dado dadoAExcluir)
    {
        if (dadoAExcluir == null)
        {
            return false;
        }

        if (!Existe(dadoAExcluir, out int ondeEsta))
        {
            return false;
        }

        atual.Ant.Prox = atual.Prox;
        atual.Prox.Ant = atual.Ant;
        quantosNos--;

        return true;
    }

    public bool IncluirNoInicio(Dado novoValor)
    {
        if (novoValor == null)
        {
            return false;
        }

        NoDuplo<Dado> novoNo = new NoDuplo<Dado>(novoValor);

        if (EstaVazio)
        {
            primeiro = ultimo = novoNo;
        } 
        
        else
        {
            primeiro.Ant = novoNo;
            novoNo.Prox = primeiro;
            primeiro = novoNo;
        }

        quantosNos++;

        return true;
    }

    public bool IncluirAposFim(Dado novoValor)
    {
        if (novoValor == null)
        {
            return false;
        }

        NoDuplo<Dado> novoNo = new NoDuplo<Dado>(novoValor);

        if (EstaVazio)
        {
            primeiro = novoNo;
        }

        else
        {
            ultimo.Prox = novoNo;
            novoNo.Ant = ultimo;
        }

        ultimo = novoNo;
        quantosNos++;

        return true;
    }

    public bool Incluir(Dado novoValor)         // (bool) Inserir nó com Dado em ordem crescente
    {
        throw new NotImplementedException();
    }

    public bool Incluir(Dado novoValor, int posicaoDeInclusao)  // inclui novo nó na posição indicada da lista
    {
        throw new NotImplementedException();
    }

    public Dado this[int indice] /// just like an array (list[0])
    {
        get
        {
            PosicionarEm(indice);

            return atual.Info;
        }
        set
        {
            PosicionarEm(indice);

            atual.Info = value;
        }
    }
    
    public Dado DadoAtual()  // retorna o dado atualmente visitado
    {
        if (atual != null)
        {
            return atual.Info;
        }

        return default;
    }

    public void ExibirDados()   // lista os dados armazenados na lista em modo console
    {
        PosicionarNoPrimeiro();

        while (atual != null)
        {
            Console.WriteLine(atual.Info.ToString());

            atual = atual.Prox;
        }
    }

    public void ExibirDados(ListBox lista)  // lista os dados armazenados na lista no listbox passado como parâmetro
    {
        PosicionarNoPrimeiro();

        lista.Items.Clear();

        while (atual != null)
        {
            lista.Items.Add(atual.Info.ToString());

            atual = atual.Prox;
        }
    }

    public void ExibirDados(ComboBox lista) // lista os dados armazenados na lista no combobox passado como parâmetro
    {
        PosicionarNoPrimeiro();

        lista.Items.Clear();

        while (atual != null)
        {
            lista.Items.Add(atual.Info.ToString());

            atual = atual.Prox;
        }
    }


    public void ExibirDados(TextBox lista)
    {
        PosicionarNoPrimeiro();

        lista.Text = "";

        while (atual != null)
        {
            lista.Text += $"{atual.Info}\n";

            atual = atual.Prox;
        }
    }

    public void Ordenar()
    {
        throw new NotImplementedException();
    }
}