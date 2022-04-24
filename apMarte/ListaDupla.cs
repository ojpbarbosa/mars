﻿using System;
using System.IO;
using System.Windows.Forms;

class ListaDupla<Dado> : IDados<Dado>
                where Dado : IComparable<Dado>, IRegistro<Dado>, new()
{
    NoDuplo<Dado> primeiro, ultimo, atual;
    int quantosNos;
    private Situacao situacaoAtual;

    public ListaDupla()
    {
        primeiro = ultimo = atual = null;
        quantosNos = 0;
    }

    public Situacao SituacaoAtual { get => situacaoAtual; set => situacaoAtual = value; }
    public int PosicaoAtual { 
        get 
        { 
            if (Existe(DadoAtual(), out int posicao))
            {
                return posicao;
            }

            else
            {
                return -1;
            }
        }
        set => PosicionarEm(value); 
    }
    public bool EstaNoInicio { get => atual == primeiro; }
    public bool EstaNoFim { get => atual == ultimo; }
    public bool EstaVazio { get => quantosNos == 0; }          // (bool) Verificar se está vazia
    public int Tamanho { get => quantosNos; }
    public NoDuplo<Dado> Primeiro { get => primeiro; }
    public NoDuplo<Dado> Ultimo { get => ultimo; }

    public void LerDados(string nomeArquivo)    // fará a leitura e armazenamento dos dados do arquivo cujo nome é passado por parâmetro
    {
        if (nomeArquivo != null)
        {
            situacaoAtual = Situacao.editando;

            StreamReader arquivo = new StreamReader(nomeArquivo);

            while (!arquivo.EndOfStream)
            {
                Incluir(new Dado().LerRegistro(arquivo));
            }
        }
    }

    public void GravarDados(string nomeArquivo)  // gravará sequencialmente, no arquivo cujo nome é passado por parâmetro, os dados armazenados na lista
    {
        if (nomeArquivo != null)
        {
            situacaoAtual = Situacao.editando;

            StreamWriter arquivo = new StreamWriter(nomeArquivo);

            PosicionarNoPrimeiro();

            while (!EstaNoFim)
            {
                DadoAtual().GravarRegistro(arquivo);

                AvancarPosicao();
            }
        }
    }

    public void PosicionarNoPrimeiro()
    {
        atual = primeiro; // o atual é posicionado no primeiro nó
    }

    public void RetrocederPosicao()
    {
        if (atual != null) // se atual for diferente de null
        {
            atual = atual.Ant; // o atual é posicionado no nó anterior
        }
    }

    public void AvancarPosicao()
    {
        if (atual != null) // se atual for diferente de null
        {
            atual = atual.Prox; // o atual é posicionado no próximo nó
        }
    }

    public void PosicionarNoUltimo()
    {
        atual = ultimo; // o atual é posicionado no último nó
    }

    public void PosicionarEm(int posicaoDesejada)
    {
        PosicionarNoPrimeiro(); // o atual é posicionado no primeiro nó

        for (int i = 0; i < posicaoDesejada; i++) // enquanto i for menor que a posi
        {
            if (atual != null)
            {
                AvancarPosicao();
            }
        }
    }

    // (bool) Pesquisar Dado procurado em ordem crescente; a pesquisa
    // posicionará o ponteiro atual no nó procurado quando este
    // or encontrado ou, se não achar, no nó seguinte a local
    // onde deveria estar o nó procurado
    public bool Existe(Dado procurado, out int ondeEsta)
    {
        situacaoAtual = Situacao.pesquisando;

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
                if (procurado.CompareTo(DadoAtual()) == 0)
                {
                    achou = true;
                }

                else
                {
                    ondeEsta++;

                    AvancarPosicao();
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

        if (Existe(dadoAExcluir, out int ondeEsta))
        {
            situacaoAtual = Situacao.excluindo;
            
            PosicionarEm(ondeEsta); // PosicaoAtual = ondeEsta;

            atual.Ant.Prox = atual.Prox;
            atual.Prox.Ant = atual.Ant;
            quantosNos--;

            AvancarPosicao();

            return true;
        }

        return false;
    }

    public bool IncluirNoInicio(Dado novoValor)
    {
        situacaoAtual = Situacao.incluindo;

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
        situacaoAtual = Situacao.incluindo;

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
        situacaoAtual = Situacao.incluindo;

        if (novoValor == null)
        {
            return false;
        }

        if (!Existe(novoValor, out _))
        {
            if (EstaVazio) // se a lista está vazia
            {
                IncluirNoInicio(novoValor); // o dado é inserido no incio
            }

            else
            {
                if (atual == null && primeiro != null) // se dado for menor que primeiro
                {
                    IncluirNoInicio(novoValor); // o dado é inserido no início
                }

                else if (atual == ultimo) // se atual foi posicionado no último
                {
                    IncluirAposFim(novoValor); // o dado é inserido após o fim
                }

                else // caso contrário
                {
                    NoDuplo<Dado> novoNo = new NoDuplo<Dado>(novoValor)
                    {

                        // o dado é inserido na sua posição correspondente
                        Prox = atual.Prox
                    };
                    novoNo.Prox.Ant = novoNo;
                    atual.Prox = novoNo;
                    novoNo.Ant = atual;

                    quantosNos++;
                }
            }

            return true;
        }

        return false;
    }

    public bool Incluir(Dado novoValor, int posicaoDeInclusao)  // inclui novo nó na posição indicada da lista
    {
        situacaoAtual = Situacao.incluindo;

        if (novoValor == null)
        {
            return false;
        }

        if (!Existe(novoValor, out int ondeEsta))
        {
            PosicionarEm(posicaoDeInclusao);

            NoDuplo<Dado> novoNo = new NoDuplo<Dado>(novoValor);

            atual.Ant.Prox = novoNo;
            novoNo.Ant = atual.Ant;
            novoNo.Prox = atual;
            atual.Ant = novoNo;
            atual = novoNo;

            return true;
        }

        return false;
    }

    public Dado this[int indice] // lista[0]
    {
        get
        {
            PosicionarEm(indice);

            return DadoAtual();
        }
        set
        {
            PosicionarEm(indice);

            atual.Info = value;

            situacaoAtual = Situacao.editando;
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

    public void ExibirDados() // lista os dados armazenados na lista em modo console
    {
        situacaoAtual = Situacao.navegando;

        PosicionarNoPrimeiro();

        while (atual != null)
        {
            Console.WriteLine(DadoAtual().ToString());

            AvancarPosicao();
        }
    }

    public void ExibirDados(ListBox lista)  // lista os dados armazenados na lista no listbox passado como parâmetro
    {
        situacaoAtual = Situacao.navegando;

        PosicionarNoPrimeiro();

        lista.Items.Clear();

        while (atual != null)
        {
            lista.Items.Add(DadoAtual().ToString());

            AvancarPosicao();
        }
    }

    public void ExibirDados(ComboBox lista) // lista os dados armazenados na lista no combobox passado como parâmetro
    {
        situacaoAtual = Situacao.navegando;

        PosicionarNoPrimeiro();

        lista.Items.Clear();

        while (atual != null)
        {
            lista.Items.Add(DadoAtual().ToString());

            AvancarPosicao();
        }
    }

    public void ExibirDados(TextBox lista)
    {
        situacaoAtual = Situacao.navegando;

        PosicionarNoPrimeiro();

        lista.Text = "";

        while (atual != null)
        {
            lista.Text += $"{DadoAtual()}\n";

            AvancarPosicao();
        }
    }

    public void Ordenar()
    {
        situacaoAtual = Situacao.editando;

        ListaDupla<Dado> ordernada = new ListaDupla<Dado>();

        PosicionarNoPrimeiro();

        while (!EstaVazio)
        {
            ordernada.Incluir(DadoAtual());

            Excluir(DadoAtual());

            AvancarPosicao();
        }

        primeiro = ordernada.Primeiro;
        ultimo = ordernada.Ultimo;
    }
}