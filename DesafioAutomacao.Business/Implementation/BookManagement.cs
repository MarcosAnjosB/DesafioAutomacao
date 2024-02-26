using DesafioAutomacao.Business.Contracts;
using DesafioAutomacao.DataTT.Model;
using DesafioAutomacao.InfraStructure.Repository;

namespace DesafioAutomacao.Business.Implementation
{
    //Classe responsável por fazer a gestão das operações como criar, listar, modificar e excluir algum dado
    //no caso abaixo implementei apenas a operação de criar
    public class BookManagement : IBookManagement
    {
        protected IRepository<Book> _Book;
        public BookManagement(IRepository<Book> Book)
        {
            _Book = Book;
        }
        public Book Create(Book newBook)
        {
            return _Book.Add(newBook);
        }

    }
}
