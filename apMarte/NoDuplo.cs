// Gabriel Willian Bartmanovicz - 21234
// João Pedro Ferreira Barbosa - 21687

using System;

class NoDuplo<Dado>
    where Dado : IComparable<Dado>,
                    IRegistro<Dado>
{
    NoDuplo<Dado> ant;
    Dado info; // informação guardada no nó da lista
    NoDuplo<Dado> prox;

    public NoDuplo(Dado novoDado)
    {
        Ant = Prox = null;
        Info = novoDado;
    }

    public NoDuplo<Dado> Ant { get => ant; set => ant = value; }
    public Dado Info { get => info; set => info = value; }
    public NoDuplo<Dado> Prox { get => prox; set => prox = value;}
}