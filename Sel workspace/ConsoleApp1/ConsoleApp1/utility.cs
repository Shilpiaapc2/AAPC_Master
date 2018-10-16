using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class utility
    {
        public static IWebDriver driver;

        public static void browserinitiate()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.aapc.com/login.aspx");
            
        }

        public static void browserclose()
        {
            driver.Close();

        }

        public static void ExplicitWaitByID(IWebDriver driver, String text)

        {   
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(text)));
            Thread.Sleep(3000);

        }


        public static void ExplicitWaitByXpath(IWebDriver driver, String text)

        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(text))); 
            Thread.Sleep(3000);
        }


        public static IWebElement WebElementFinderByID(String text )

        {   
             IWebElement element =  driver.FindElement(By.Id(text));
             return element;
        }

        public static IWebElement WebElementFinderByXPath(String text)

        {
            IWebElement element = driver.FindElement(By.XPath(text));
            return element;
        }


        public static void loginpage()

        {
            IWebElement username = driver.FindElement(By.Id("ctl00_Body_UserName"));
            Thread.Sleep(2000);
            username.SendKeys("subhankar");
            IWebElement password = driver.FindElement(By.XPath(".//*[@id='ctl00_Body_Password']"));
            password.SendKeys("subh_1234");

            IWebElement signin = driver.FindElement(By.Id("ctl00_Body_LoginButton"));
            signin.Click();
        }


    }
}
