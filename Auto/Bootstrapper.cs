using DesafioAutomacao.Business.Contracts;
using DesafioAutomacao.Business.Implementation;
using DesafioAutomacao.DataTT.Model;
using DesafioAutomacao.InfraStructure.InfraStructure.Repository;
using DesafioAutomacao.InfraStructure.Repository;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using System.Data.Entity;
using System.Web.Mvc;
using System.Configuration;

namespace Auto
{
    public class Bootstrapper
    {
        //Método responsável por inicializar a configuração da injeção de dependência
        //para a aplicação usando o Unity Container
        public static void Initialize()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        //Método responsável por configurar e retornar um contêiner de injeção de dependência Unity
        //com configurações necessárias para a aplicação e o registro de tipos de serviço e suas
        //implementações correspondentes.
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            if (ConfigurationManager.AppSettings["BaseType"] != null)
            {
                if (ConfigurationManager.AppSettings["BaseType"].ToString().ToUpper() == "SQLSERVER")
                {
                    container
                    .RegisterType<DbContext, DesafioAutomacao.Data.SqlServerTT.DesafioAutomacaoContext>(new InjectionMember[]
                    {
                        new InjectionConstructor("ConnDesafioAutomacao")
                    });
                }
            }
            container.RegisterType<IUnityOfWork, UnityOfWork>();

            container.RegisterType<IBookManagement, BookManagement>();
            container.RegisterType<IRepository<Book>, BaseRepository<Book>>();

            return container;
        }
    }
}