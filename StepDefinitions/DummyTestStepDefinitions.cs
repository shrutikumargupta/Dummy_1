//using NUnit.Framework;
using Dummy_1.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using Dummy_1.Pages;
//using S


namespace Dummy_1.StepDefinitions
{
    [Binding]
    public sealed class DummyTestStepDefinitions
    {
        private IWebDriver driver;
        Login log;
        AddtoCart Addcart;


        public DummyTestStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }
       
    

        [Given(@"open the browser and enter url")]
        public void GivenOpenTheBrowserAndEnterUrl()
        {
            driver.Url = "https://www.saucedemo.com/";
            Thread.Sleep(2000);
         
        }

        
        [When(@"I entered userid (.*) and paswrd (.*)")]
        public void WhenIEnteredUseridAndPaswrd(string username, string password)
        {
            log = new Login(driver);
           log.EnterCredentails(username, password);
        }

        [When(@"Click on login button")]
        public void WhenClickOnLoginButton()
        {

            log.ClickonLoginButton();
            
        }

        [Then(@"Verify the credentials")]
        public void ThenVerifyTheCredentials()
        {

           log.VerifyCredentialsafterLogin();

               
        }
        [Then(@"Sort items for price to see cheapest items")]
        public void ThenSortItemsForPriceToSeeCheapestItems()
        {
            Addcart = new AddtoCart(driver);
            Addcart.Sortitemsfromlowtohigh();
        }


        [Then(@"Add (.*) items to cart")]
        public void ThenAddItemsToCart(int number)
        {
            Addcart.AddItemsToCart(number);
        }


        [Then(@"remove items if amount is more than (.*)")]
        public void ThenRemoveItemsIfAmountIsMoreThan(int maxamount)

        {
            Addcart.RemoveItemdfromCart(maxamount);
        }



    }
}
