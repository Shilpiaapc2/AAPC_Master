using OpenQA.Selenium;
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
    public class LocateExamByIndex
    {
        public static void Locateexampageload()
        {
            IWebElement certification = utility.driver.FindElement(By.XPath("//a[@id='ev-dh-63']"));
            Actions action = new Actions(utility.driver);
            action.MoveToElement(certification);
            action.Build().Perform();

            // navigate to locate exam page
            utility.driver.FindElement(By.XPath(".//*[@id='ev-dh-72']")).Click();

            // title check for page loading
            String title = utility.driver.Title;
            if (title.Equals("AAPC Certification Exam Locations - Coding Certification Exam - AAPC"))
            {
                Console.WriteLine("Locate exam page loaded successfully");
            }
            else
            {
                Console.WriteLine("page not loaded, please try again");
            }

        }


        //Select By Country, State or Index
        public static void SelectExamByIndex()

        {
            IWebElement firstradiobtn = utility.WebElementFinderByID("ctl00_Body_rdoSelectByCountryStateOrIndexMain_0");

            // IWebElement firstradiobtn = utility.driver.FindElement(By.Id("ctl00_Body_rdoSelectByCountryStateOrIndexMain_0"));
            bool firstradiocheck = firstradiobtn.Selected;
            if (firstradiocheck == false)
            {
                firstradiobtn.Click();
            }
            else
            {
                Console.WriteLine(" Search by Index radio button is checked");

            }
        }


        public static void SearchExamByIndex()

        {
            IWebElement Country_Drpdwn = utility.driver.FindElement(By.Id("ctl00_Body_ddlCountry"));
            Console.WriteLine(Country_Drpdwn.Size);
            Country_Drpdwn.Click();

            IWebElement statedropwdwn = utility.driver.FindElement(By.Id("ctl00_Body_ddlRegion"));
            // exam for country Germany
            SelectElement oselect = new SelectElement(Country_Drpdwn);
            oselect.SelectByText("Germany");
            Console.WriteLine("Germany country selcted");

            IJavaScriptExecutor js = (IJavaScriptExecutor)utility.driver;
            js.ExecuteScript("window.scrollBy(0,500)");

            Thread.Sleep(5000);
            Console.WriteLine("Germany list is successfully loaded .");
            IWebElement searchbtn = utility.driver.FindElement(By.Id("ctl00_Body_btnSearchExams"));
            searchbtn.Click();
            LocateExamByIndex.IsExamResultsDisplayed();

        }


        public static bool IsExamResultsDisplayed()

        {
            IWebElement result = utility.driver.FindElement(By.XPath(".//*[@id='ctl00_Body_gvExams']/tbody/tr/td"));

            if (result.Equals("No results found. Please double-check the index number you entered or contact AAPC at 800-626-2633 for further assistance."))
            {

                Console.WriteLine("Exam results not displayed");
                return false;
            }
            else
            {
                Console.WriteLine("Exam results  displayed successfully");
                return true;
            }
        }

        //select any exam by clicking on details link for that particular exam 
        public static void ExamsSelect()
        {
            IWebElement details = utility.driver.FindElement(By.XPath(".//*[@id='ctl00_Body_gvExams_ctl02_HyperLink1']/span"));
            details.Click();
            String url = utility.driver.Url;

            if (url.Contains("https://www.aapc.com/certification/locate-examination-info.aspx?"))
                Console.WriteLine("locate exam page successully loaded");

        }


        public static void CheckMembership()
        {
            IWebElement addrenewmemb = utility.WebElementFinderByID("ctl00_body_pnlExamPurchase");

            if (addrenewmemb.Text.Contains("Add/Renew Membership"))
            {
                ExamRegistrationForExpiredMembership();
            }

            else
            {
                ExamRegistrationForActiveMembership();
            }

        }
    

        public static void ExamRegistrationForActiveMembership()

        {
            IWebElement coding = utility.driver.FindElement(By.XPath(".//*[@id='ctl00_body_mnuCategories']/ul/li[1]/a/img "));
            coding.Click();
            utility.ExplicitWaitByID(utility.driver, "ctl00_body_mnuCoding");
            IWebElement maintbl = utility.driver.FindElement(By.Id("ctl00_body_mnuCoding"));
            maintbl.FindElement(By.XPath("//div[@id='ctl00_body_mnuCoding']/ul/li[1]")).Click();

            Thread.Sleep(3000);

            IWebElement checkbox1 = utility.driver.FindElement(By.Id("ctl00_body_chkAgree1"));
            checkbox1.Click();

            IWebElement checkbox2 = utility.driver.FindElement(By.Id("ctl00_body_chkAgree2"));
            checkbox2.Click();

            IWebElement registerbtn = utility.driver.FindElement(By.XPath(".//*[@id='ctl00_body_btnSubmit_input']"));
            registerbtn.Click();
                       
        }

        public static void ExamRegistrationForExpiredMembership()

        {
            IWebElement addrenewmembr = utility.WebElementFinderByID("ctl00_body_rbnNonMember");
            addrenewmembr.Click();
            Thread.Sleep(3000);
            IWebElement addrenewdropdown = utility.WebElementFinderByID("ctl00_body_cboMembership_Arrow");
            addrenewdropdown.Click();
            IWebElement dropdowntable = utility.WebElementFinderByID("ctl00_body_cboMembership_DropDown");
            IWebElement dropdowntablevalue = dropdowntable.FindElement(By.XPath("//li[contains(text(),'Individual Membership - $160')]"));
            dropdowntablevalue.Click();
            Thread.Sleep(3000);

            IWebElement coding = utility.driver.FindElement(By.XPath(".//*[@id='ctl00_body_mnuCategories']/ul/li[1]/a/img "));
            coding.Click();
            utility.ExplicitWaitByID(utility.driver, "ctl00_body_mnuCoding");
            IWebElement maintbl = utility.driver.FindElement(By.Id("ctl00_body_mnuCoding"));
            maintbl.FindElement(By.XPath("//div[@id='ctl00_body_mnuCoding']/ul/li[1]")).Click();

             Thread.Sleep(3000);

                IWebElement checkbox1 = utility.driver.FindElement(By.Id("ctl00_body_chkAgree1"));
                checkbox1.Click();

                IWebElement checkbox2 = utility.driver.FindElement(By.Id("ctl00_body_chkAgree2"));
                checkbox2.Click();

                IWebElement registerbtn = utility.driver.FindElement(By.XPath(".//*[@id='ctl00_body_btnSubmit_input']"));
                registerbtn.Click();
                               
            

           
          //else

          //  {
          //      Console.WriteLine("Membership radio button is not selected");


          //  }

            
        }

     

        public void ExamRegFlow()
        {
            Locateexampageload();
            SelectExamByIndex();
            SearchExamByIndex();
            ExamsSelect();
            CheckMembership();
        }
    }





    //public static void selectByProximity()

    //{
    //    IWebElement secondradiobtn = driver.FindElement(By.Id("ctl00_Body_rdoSelectByCountryStateOrIndexMain_1"));
    //    bool secondradiocheck = secondradiobtn.Selected;

    //    if (secondradiocheck == false)
    //    {
    //        secondradiobtn.Click();
    //    }

    //    else
    //    {
    //        Console.WriteLine(" Search by Proximity radio button is not checked");

    //    }

    //}


    }





    



