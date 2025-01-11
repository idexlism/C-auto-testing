using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Выбрал кейс "Создание комментария от другого юзера под постом в ленте"

            //Создаем второго юзера
            string userLogin = "change login";
            string userPassword = "change password)";


            //Открываем браузер
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //Переходим на портал
            driver.Navigate().GoToUrl("http://192.168.173.208");
            //Вводим логин
            var loginInput = driver.FindElement(By.XPath("//input[@name=\"USER_LOGIN\"]"));
            loginInput.SendKeys(userLogin + Keys.Tab);
            //Вводим пароль)
            var passwordInput = driver.FindElement(By.XPath("//input[@name=\"USER_PASSWORD\"]"));
            passwordInput.SendKeys(userPassword + Keys.Enter);
            Thread.Sleep(1000);
            //Нажимаем на поле 
            var comPress = driver.FindElement(By.XPath("//div[@class=\"feed-com-add-box-outer\"]"));
            comPress.Click();
            //Убираем слой iframe'а
            var contactFrame = driver.FindElement(By.XPath("//iframe[@class=\"bx-editor-iframe\"]"));
            driver.SwitchTo().Frame(contactFrame);
            //Пишем комментарий и опубликовываем
            var comInput = driver.FindElement(By.XPath("//body[@contenteditable=\"true\"]"));
            comInput.SendKeys("venom" + Keys.Control + Keys.Enter);
            //driver.Quit(); Его конечно стоило оставить, но с ним алгоритм вручную не проверишь
        }
    }
}
