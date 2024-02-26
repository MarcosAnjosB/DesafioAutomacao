using DesafioAutomacao.DataTT;
using DesafioAutomacao.DataTT.Model;
using System.Data.Entity;

namespace DesafioAutomacao.DataTT
{
    //Interface responsável por definir um contrato para a classe DesafioAutomacaoContext
    public interface IDesafioAutomacaoContext : IDbContext
    {
        DbSet<Book> Book { get; set; }
    }
}
