// Gabriel Willian Bartmanovicz - 21234
// João Pedro Ferreira Barbosa - 21687

using System.IO;

public interface IRegistro<Dado>
{
    Dado LerRegistro(StreamReader arquivo);
    string ParaArquivo();
    void GravarRegistro(StreamWriter arquivo);
}