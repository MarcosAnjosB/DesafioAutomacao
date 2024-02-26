using System;
using System.Web.Mvc;
using DesafioAutomacao.Business.Contracts;
using DesafioAutomacao.DataTT.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Auto.Controllers
{
    //Controller responsável por fazer toda interação com o browser e salvar as informações necessárias
    public class HomeController : Controller
    {
        private readonly IBookManagement _Book;
        public HomeController(IBookManagement Book)
        {
            _Book = Book;
        }
        public ActionResult AutomationWithSelenium()
        {
            try
            {
                Book book = new Book();
                IWebDriver driver = new ChromeDriver();

                AccessSite(driver);

                AccessElementSearch(driver);

                book = SearchElementsBook(driver);

                if (book != null)
                {
                    _Book.Create(book);
                }
                else
                {
                    throw new Exception("Método SearchElementsBook sem retorno válido!");
                }

                driver.Quit();

                return View();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu uma exceção no método AutomationWithSelenium - Mensagem de erro: " + e.Message);
                return View();
            }
        }

        //Método responsável por acessar a url do site Alura
        public void AccessSite(IWebDriver Driver)
        {
            try
            {
                var driver = Driver;

                string url = "https://www.alura.com.br/";

                driver.Navigate().GoToUrl(url);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu uma exceção no método AccessSite - Mensagem de erro: " + e.Message);
            }
        }

        //Método responsável por encontrar os elementos de pesquisa e acessar determinado curso
        public void AccessElementSearch(IWebDriver Driver)
        {
            try
            {
                var driver = Driver;

                IWebElement inputSearch = driver.FindElement(By.Id("header-barraBusca-form-campoBusca"));

                inputSearch.SendKeys("Arquitetura da informação em UX #149");

                IWebElement buttonSearch = driver.FindElement(By.CssSelector(".header__nav--busca-submit"));

                buttonSearch.Click();

                IWebElement ulElement = driver.FindElement(By.ClassName("paginacao-pagina"));

                IWebElement firstLiElement = ulElement.FindElement(By.TagName("li"));

                firstLiElement.Click();

            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu uma exceção no método AccessElementSearch - Mensagem de erro: " + e.Message);
            }
        }

        //Método responsável por encontrar os elementos informatidos: Título, professor, carga horária e descrição
        public Book SearchElementsBook(IWebDriver Driver)
        {
            try
            {
                Book book = new Book();
                var driver = Driver;

                IWebElement elementWorkload = driver.FindElement(By.CssSelector("p.episode-programming-time"));

                book.Workload = elementWorkload.Text;

                IWebElement elementDescription = driver.FindElement(By.CssSelector("div.podcast-details__description > p:nth-of-type(1)"));

                book.Description = elementDescription.Text;

                IWebElement elementTeacher = driver.FindElement(By.CssSelector("div.podcast-details__description > p:nth-of-type(2)"));

                book.Teacher = elementTeacher.Text;

                IWebElement elementTitle = driver.FindElement(By.CssSelector(".podcast-header-title"));

                book.Title = elementTitle.Text;

                return book;

            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu uma exceção no método SearchElementsBook - Mensagem de erro: " + e.Message);
                return null;
            }
        }
    }
}