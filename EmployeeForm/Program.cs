using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EmployeeForm
{
    class Program
    {
        static void Main(string[] args)
        {
            Login();
        }

        public static void Login()
        {
           IWebDriver driver = new ChromeDriver(@"C:\Users\venthan\Downloads\chromedriver_win32");

            //Go to the url
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f");

            //Enter username
            IWebElement username = driver.FindElement(By.XPath("//*[@id='UserName']"));
            username.SendKeys("venthan12"); //venthan12

             //Enter password
             IWebElement password = driver.FindElement(By.XPath("//*[@id='Password']"));
            password.SendKeys("Venthan@12"); //Venthan@12

            //Click on Login
            IWebElement login = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            login.Click();


            //Check if home page is displayed
            //String turnup = driver.FindElement(By.XPath("/html/body/div[3]/div/a")).Text;

            if (driver.FindElement(By.XPath("/html/body/div[3]/div/a")).Text == "TurnUp")
            {
                //CreateEmployee(driver);
                // EditEmployee(driver);
                 DeleteEmployee(driver);

            }
            else
            {
                Console.WriteLine("TurnUp text is not present, test failed");
            }
        }

        public static void CreateEmployee(IWebDriver driver)
        {
             //Go to the url
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/User/Create?ReturnUrl=%2f");

            IWebElement Name = driver.FindElement(By.XPath("//*[@id='Name']"));
            Name.SendKeys("Venthan Testing 20");

            IWebElement Username = driver.FindElement(By.XPath("//*[@id='Username']"));
            Username.SendKeys("Venthantesting@20");

            IWebElement Password = driver.FindElement(By.XPath("//*[@id='Password']"));
            Password.SendKeys("Venthantesting@20");

            IWebElement RetypePassword = driver.FindElement(By.XPath("//*[@id='RetypePassword']"));
            RetypePassword.SendKeys("Venthantesting@20");

            IWebElement save = driver.FindElement(By.XPath("//*[@id='SaveButton']"));
            save.Click();
        }

        public static void EditEmployee(IWebDriver driver)
        {
            //Go to the url
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/User/Edit?id=1025");

            IWebElement name = driver.FindElement(By.XPath("//*[@id='Name']"));
            name.SendKeys("Venthan Testing 66");

            IWebElement save = driver.FindElement(By.XPath("//*[@id='SaveButton']"));
            save.Click();
        }

        public static void DeleteEmployee(IWebDriver driver)
        {
            //Go to the url
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/User");

            IWebElement delete = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[5]/td[3]/a[2]"));
            delete.Click();
            //*[@id="usersGrid"]/div[3]/table/tbody/tr[9]/td[3]/a[2]
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
        }
    }
}
