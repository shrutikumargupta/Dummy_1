using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;


namespace Dummy_1
{
    
    public sealed class Login 
    {
        private IWebDriver driver;

               public Login(IWebDriver driver)
        {
            this.driver = driver;
        }
        
        //method to launch url
        
        public void Launch_url()
        {

            string urlvalue = "https://www.saucedemo.com/";
            driver.Navigate().GoToUrl(urlvalue);
        }

        //method to enter userid and password provided by user
        public void EnterCredentails(string username, string password)
        {
            try
            {
                string uid_pathtext = "//*[@id='user-name']";
                WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                IWebElement uid = wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath(uid_pathtext)));

                uid.SendKeys(username);

                string pwd_pathtext = "//*[@id='password']";

                IWebElement pwd = wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath(pwd_pathtext)));

                pwd.SendKeys(password);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            
         }
        // method to click on Login button after entering credentials
        public void ClickonLoginButton()

        {
            try
            {

                string Loginbtn_pathtext = "//*[@id='login-button']";
                WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                IWebElement Loginbtn = wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath(Loginbtn_pathtext)));

                Loginbtn.Click();
            }

            catch(Exception ex)
            {  
                Console.WriteLine(ex.Message);
            
            }
            
            }

        //method to verify if login is successful with valid credentials or unsuccessful with invalid credentials
        public void VerifyCredentialsafterLogin()


        {
            try
            {

                IList<IWebElement> elements = driver.FindElements(By.XPath("//*[@data-test='error']")).ToList();
                if (elements.Count == 1)


                {

                    IWebElement errormessage = driver.FindElement(By.XPath("//*[@data-test='error']"));
                    string Invalidcredentailserror_message = errormessage.Text;
                    Console.WriteLine("Login is unsuccessful due to error:" + Invalidcredentailserror_message);
                }

                else
                {
                    string Productstitle_pathtext = "//*[text()='Products']";

                    WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                    IWebElement Productstitle = wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath(Productstitle_pathtext)));
                   
                    if (Productstitle.Displayed == true)
                    {
                        Console.WriteLine("Login is successful");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

    }
    }

