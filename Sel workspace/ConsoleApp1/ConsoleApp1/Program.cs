using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
       //public static IWebDriver driver;

        static void Main(string[] args)
        {

           utility.browserinitiate();
           utility.loginpage();
           
            //calling locate exam method
           LocateExamByIndex obj = new LocateExamByIndex();
           obj.ExamRegFlow();

           utility.browserclose();
                     
        }
    }

