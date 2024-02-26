using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using DesafioAutomacao.DataTT;
using DesafioAutomacao.DataTT.Model;



namespace DesafioAutomacao.Data.SqlServerTT
{
    //Classe que serve como o ponto de entrada para interagir com o banco de dados da aplicação,
    //definindo o contexto do banco de dados, especificando as configurações e fornecendo
    //acesso às entidades do banco de dados por meio das propriedades DbSet.
    public partial class DesafioAutomacaoContext : DbContext, IDesafioAutomacaoContext
    {
        static DesafioAutomacaoContext()
        {
            Database.SetInitializer<DesafioAutomacaoContext>(null);
        }

        public DesafioAutomacaoContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

        }

        public virtual DbSet<Book> Book { get; set; }

    }
}
