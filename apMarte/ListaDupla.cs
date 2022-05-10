// Gabriel Willian Bartmanovicz - 21234
// João Pedro Ferreira Barbosa - 21687

using System;
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

    // situação atual da lista
    public Situacao SituacaoAtual { get => situacaoAtual; set => situacaoAtual = value; }
    public int PosicaoAtual { // posição atual na lista
        get
        {
            if (Existe(DadoAtual(), out int posicao)) // se o dado atual existe
            {
                return posicao; // o paramêtro out é retornado como sua posição
            }

            return -1; // senão, -1
        }
        set => PosicionarEm(value); // posiciona o atual na posição atribuída
    }
    public bool EstaNoInicio { get => atual == primeiro; } // verifica se o atual está no início da lista
    public bool EstaNoFim { get => atual == ultimo; } // verifica se o atual está no fim da lista
    public bool EstaVazio { get => quantosNos == 0; } // verifica se a lista está vazia
    public int Tamanho { get => quantosNos; } // tamanho da lista

    public void LerDados(string nomeArquivo) // leitura e armazenamento dos dados
    {
        if (nomeArquivo != null) // se o nome do arquivo não for null
        {
            situacaoAtual = Situacao.editando; // define a situação atual como editando

            StreamReader arquivo = new StreamReader(nomeArquivo); // instancia um StreamReader com o nome do arquivo

            while (!arquivo.EndOfStream) // enquanto o arquivo não terminar de ser lido
            {
                Incluir(new Dado().LerRegistro(arquivo)); // inclui um novo dado a partir da leitura do registro do arquivo
            }

            arquivo.Close(); // fecha o arquivo
        }
    }

    public void GravarDados(string nomeArquivo) // gravação e armazenamento dos dados
    {
        if (nomeArquivo != null) // se o nome do arquivo não for null
        {
            situacaoAtual = Situacao.editando; // define a situação atual como editando

            StreamWriter arquivo = new StreamWriter(nomeArquivo); // instancia um StreamWriter com o nome do arquivo

            PosicionarNoPrimeiro(); // posiciona o atual no primeiro nó para percorrer a lista

            while (atual != null) // enquanto atual não for null
            {
                DadoAtual().GravarRegistro(arquivo); // grava o registro referente ao nó atual no arquivo

                AvancarPosicao(); // avança a posição do atual
            }

            arquivo.Close(); // fecha o arquivo
        }
    }

    public void PosicionarNoPrimeiro() // posiciona o atual no primeiro nó
    {
        atual = primeiro; // o atual é posicionado no primeiro nó
    }

    public void RetrocederPosicao() // posiciona o atual em seu nó anterior  
    {
        if (atual != null) // se atual for diferente de null
        {
            atual = atual.Ant; // o atual é posicionado no nó anterior
        }
    }

    public void AvancarPosicao() // posiciona o atual em seu próximo nó
    {
        if (atual != null) // se atual for diferente de null
        {
            atual = atual.Prox; // o atual é posicionado no próximo nó
        }
    }

    public void PosicionarNoUltimo() // posiciona o atual no último nó
    {
        atual = ultimo; // o atual é posicionado no último nó
    }

    public void PosicionarEm(int posicaoDesejada) // posiciona o atual em uma posição específica da lista
    {
        if (posicaoDesejada < Tamanho) // se a posicação for menor que o tamanho da lista
        {
            PosicionarNoPrimeiro(); // o atual é posicionado no primeiro nó

            for (int i = 0; i < posicaoDesejada; i++) // enquanto i for menor que a posição
            {
                AvancarPosicao(); // o atual é avançado
            }
        }
    }

    public bool Existe(Dado procurado, out int ondeEsta) // verifica a existência de um dado na lista
    {
        situacaoAtual = Situacao.pesquisando; // define a situação atual como pesquisando

        PosicionarNoPrimeiro(); // posiciona o atual no primeiro para percorrer a lista

        if (EstaVazio || procurado == null) // se a lista está vazia ou se o dado procurado for null
        {
            ondeEsta = -1; // onde está = -1

            return false; // o dado não existe
        }

        if (procurado.CompareTo(primeiro.Info) < 0) // se dado procurado for menor que o primeiro
        {
            ondeEsta = -1; // onde está = -1

            return false; // o dado não existe
        }

        if (procurado.CompareTo(ultimo.Info) > 0) // se oo dado procurado for maior que o último
        {
            PosicionarNoUltimo(); // o atual é posicionado no último nó

            ondeEsta = -1; // onde está = -1

            return false; // o dado não existe
        }

        situacaoAtual = Situacao.pesquisando; // define a situação atual como pesquisando

        bool achou = false, fim = false;

        ondeEsta = 0;
        
        while (!achou && !fim) // enquanto o dado não for encontrado e não estiver no fim
        {
            if (atual == null) // se atual for null
            {
                fim = true; // fim recebe true
            }

            else // senão
            {
                if (procurado.CompareTo(DadoAtual()) == 0) // se o dado procurado for igual ao dado atual
                {
                    achou = true; // o dado foi encontrado
                }

                else if (DadoAtual().CompareTo(procurado) > 0) // se o dado atual for maior que o atual procurado
                {
                    fim = true; // a posição de inclusão foi ultrapassada e fim recebe true
                }

                else // senão
                {
                    ondeEsta++; // a posição de onde o dado está é acrescida 

                    AvancarPosicao(); // o atual é avançado
                }
            }
        }

        return achou;
    }

    public bool Excluir(Dado dadoAExcluir) // exclui um dado
    {
        if (dadoAExcluir == null) // se o dado for null
        {
            return false; // a exclusão é abortada
        }

        if (Existe(dadoAExcluir, out _)) // se o dado existe
        {
            situacaoAtual = Situacao.excluindo; // define a situação atual como excluindo

            if (EstaNoInicio) // se atual for o primeiro nó
            {
                primeiro = atual.Prox; // o primeiro nó passa a ser o próximo nó

                if (primeiro != null) // se o primeiro não for null
                {
                    primeiro.Ant = null; // o nó anterior ao primeiro passa a ser null
                }
            }

            else // senão
            {
                // o próximo nó do nó anterior ao atual passa a ser o próximo nó do atual
                atual.Ant.Prox = atual.Prox;

                if (EstaNoFim)
                {
                    ultimo = atual.Ant; // o último nó passa a ser o anterior ao atual
                }

                else // senão
                {
                    atual.Prox.Ant = atual.Ant; // o nó anterior ao próximo nó do atual recebe o nó anterior ao atual
                }
            }

            quantosNos--; // quantos nós é decrescido

            AvancarPosicao(); // atual é avançado

            return true;
        }

        return false;
    }

    public bool IncluirNoInicio(Dado novoValor) // inclui um dado no início da lista
    {
        situacaoAtual = Situacao.incluindo; // define a situação atual como incluindo

        if (novoValor == null) // se o novo valor for null
        {
            return false; // a inclusão é abortada
        }

        NoDuplo<Dado> novoNo = new NoDuplo<Dado>(novoValor); // instancia um novo nó

        if (EstaVazio) // se a lista está vazia
        {
            primeiro = ultimo = novoNo;
        }

        else // senão
        {
            primeiro.Ant = novoNo; // o nó anterior ao primeiro passa a ser o novo nó
            novoNo.Prox = primeiro; // o próximo nó do novo nó passa a ser o primeiro
            primeiro = novoNo; // o primeiro passa a ser o novo nó
        }

        quantosNos++; // a quantidade de nós é acrescida

        return true;
    }

    public bool IncluirAposFim(Dado novoValor) // inclui um dado no fim da lista
    {
        situacaoAtual = Situacao.incluindo; // define a situação atual como incluindo

        if (novoValor == null) // se o novo valor for null
        {
            return false; // a inclusão é abortada
        }

        NoDuplo<Dado> novoNo = new NoDuplo<Dado>(novoValor); // instancia um novo nó

        if (EstaVazio) // se a lista está vazia
        {
            primeiro = novoNo;
        }

        else // senão
        {
            ultimo.Prox = novoNo; // o próximo nó do último nó recebe o novo nó
            novoNo.Ant = ultimo; // o nó anterior ao novo nó recebe o último
        }

        ultimo = novoNo; // ultimo passa a ser o novo nó
        quantosNos++; // quantos nós é acrescido

        return true;
    }

    public bool Incluir(Dado novoValor) // inclui um dado de forma ordenada
    {
        situacaoAtual = Situacao.incluindo; // define a situação atual como incluindo

        if (novoValor == null) // se o novo valor for null
        {
            return false; // a inclusão é abortada
        }

        if (!Existe(novoValor, out int ondeEsta)) // se o dado não existe
        {
            if (EstaVazio) // se a lista está vazia
            {
                return IncluirNoInicio(novoValor); // o dado é incluído no incio
            }

            else // senão
            {
                if (EstaNoFim && ondeEsta == -1) // se for maior que último
                {
                    return IncluirAposFim(novoValor); // o dado é inserido após o fim
                }

                else if (EstaNoInicio && ondeEsta == -1) // se dado for menor que primeiro
                {
                    return IncluirNoInicio(novoValor); // o dado é inserido no início
                }

                else // senão
                {
                    NoDuplo<Dado> novoNo = new NoDuplo<Dado>(novoValor); // instancia um novo nó
                    
                    novoNo.Ant = atual.Ant; // o nó anterior ao novo nó recebe o nó anterior ao nó atual
                    
                    if (novoNo.Ant != null)
                    {
                        novoNo.Ant.Prox = novoNo; // o próximo nó do nó anterior ao novo nó recebe novo nó
                    }

                    novoNo.Prox = atual; // o próximo nó do novo nó recebe atual
                    atual.Ant = novoNo; // o nó anteior ao atual recebe novo nó
                    atual = novoNo; // atual passa a ser o novo nó

                    quantosNos++; // quantos nós é acrescido

                    return true;
                }
            }
        }

        return false;
    }

    public bool Incluir(Dado novoValor, int posicaoDeInclusao)  // inclui novo nó na posição indicada da lista
    {
        situacaoAtual = Situacao.incluindo; // define a situação atual como incluindo

        if (novoValor == null) // se o novo valor for null
        {
            return false; // a inclusão é abortada
        }

        if (posicaoDeInclusao < 0 || posicaoDeInclusao > Tamanho - 1) // se a posição de inclusão for inválida
        {
            return false; // a inclusão é abortada
        }

        if (!Existe(novoValor, out _)) // se o dado não existe
        {
            PosicionarEm(posicaoDeInclusao); // posiciona o atual na posição desejada

            NoDuplo<Dado> novoNo = new NoDuplo<Dado>(novoValor); // instancia um novo nó

            novoNo.Ant = atual.Ant; // o nó anterior ao novo nó recebe o nó anterior ao nó atual

            if (novoNo.Ant != null) // se o nó anterior ao novo nó não for null
            {
                novoNo.Ant.Prox = novoNo; // o próximo nó do nó anterior ao novo nó recebe novo nó
            }

            novoNo.Prox = atual; // o próximo nó do novo nó recebe atual
            atual.Ant = novoNo; // o nó anteior ao atual recebe novo nó
            atual = novoNo; // atual passa a ser o novo nó

            quantosNos++; // quantos nós é acrescido

            return true;
        }

        return false;
    }

    public Dado this[int indice] // obtém o dado na inésima posição da lista (lista[0])
    {
        get
        {
            if (indice >= 0 && indice < Tamanho) // se o indice é válido
            {
                PosicionarEm(indice); // posiciona o atual no indíce

                return DadoAtual(); // retorna o dado atual
            }

            return default;
        }
        set
        {
            if (indice >= 0 && indice < Tamanho) // se o indice é válido
            {
                PosicionarEm(indice); // posiciona o atual no indíce

                atual.Info = value; // define o valor atribuída
            }
        }
    }
    
    public Dado DadoAtual()  // retorna o dado atual
    {
        if (atual != null) // se atual for diferente de null
        {
            return atual.Info; // retorna a informação do atual
        }

        return default;
    }

    public void ExibirDados() // lista os dados armazenados na lista em modo console
    {
        situacaoAtual = Situacao.navegando; // define a situação atual como navegando

        PosicionarNoPrimeiro(); // posiciona o atual no primeiro nó

        Console.Clear(); // limpa o console

        while (atual != null) // enquanto atual não for null
        {
            Console.WriteLine($"{DadoAtual()}\n"); // printa o dado atual

            AvancarPosicao(); // avança o atual
        }
    }

    public void ExibirDados(ListBox lista)  // lista os dados armazenados na lista no listbox passado como parâmetro
    {
        situacaoAtual = Situacao.navegando; // define a situação atual como navegando

        PosicionarNoPrimeiro(); // posiciona o atual no primeiro nó

        lista.Items.Clear(); // limpa o list box

        while (atual != null) // enquanto atual for diferente de null
        {
            lista.Items.Add(DadoAtual().ToString()); // o dado atual é incluído no list box

            AvancarPosicao(); // avança o atual
        }
    }

    public void ExibirDados(ComboBox lista) // lista os dados armazenados na lista no combobox passado como parâmetro
    {
        situacaoAtual = Situacao.navegando; // define a situação atual como navegando

        PosicionarNoPrimeiro(); // posiciona o atual no primeiro nó

        lista.Items.Clear(); // limpa o combo box

        while (atual != null) // enquanto atual for diferente de null
        {
            lista.Items.Add(DadoAtual().ToString()); // o dado atual é incluído no combo box

            AvancarPosicao(); // avança o atual
        }
    }

    public void ExibirDados(TextBox lista) // exibe os dados em um text box
    {
        situacaoAtual = Situacao.navegando; // defina a situação atual como navegando

        PosicionarNoPrimeiro(); // posiciona o atual no primeiro para percorrer a lista

        lista.Clear(); // limpa o text box

        while (atual != null) // enquanto atual for diferente de null
        {
            lista.Text += $"{DadoAtual()}\n"; // o dado é concatenado no text box

            AvancarPosicao(); // avança o atual
        }
    }

    public void Ordenar() // ordena a lista
    {
        situacaoAtual = Situacao.editando; // define a situação atual como editando

        ListaDupla<Dado> ordernada = new ListaDupla<Dado>(); // instancia a lista ordenada

        PosicionarNoPrimeiro(); // posiciona o atual no primeiro para percorrer a lista

        while (atual != null) // enquanto atual não for null
        {
            ordernada.Incluir(DadoAtual()); // inclui na lista ordenada

            AvancarPosicao(); // avança o atual
        }

        primeiro = ordernada.primeiro; // o ponteiro relativo ao primeiro nó da ordenada é atribuído ao primeiro nó da lista
        ultimo = ordernada.ultimo; // o ponteiro relativo ao último nó da ordenada é atribuído ao último nó da lista
    }
}