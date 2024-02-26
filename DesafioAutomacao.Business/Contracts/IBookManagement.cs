using DesafioAutomacao.DataTT.Model;

namespace DesafioAutomacao.Business.Contracts
{
    //Interface responsável por definir um contrato para a classe BookManagement
    public interface IBookManagement
    {
        Book Create(Book newBook);

    }
}
