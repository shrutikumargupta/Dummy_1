using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace Dummy_1.Pages

{

    public class AddtoCart

    {

        private IWebDriver driver;

        public object SeleniumExtras { get; private set; }

        public AddtoCart(IWebDriver driver)
        {
            this.driver = driver;
        }
        // method to sort items in products from price low to high
        public void Sortitemsfromlowtohigh()
        {
            try
            {

                string sortbutton_xpath = "//*[@class='product_sort_container']";
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                IWebElement sortbutton = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(sortbutton_xpath)));


                sortbutton.Click();
                sortbutton.SendKeys("Price (low to high)");

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        // methid to add top n (number of items provided by user) number of items to cart 
        public void AddItemsToCart(int number)
        {
            try
            {
                for (int i = 1; i <= number; i++)
                {

                    string pathttext = "(//*[@class='btn btn_primary btn_small btn_inventory '])[1]";

                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                    IWebElement AddtoCartbutton = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(pathttext)));

                    AddtoCartbutton.Click();

                }


                string Carticon_path = "//*[@class='shopping_cart_badge']";
                WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                IWebElement Carticon = wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath(Carticon_path)));
                int Number_of_items_in_cart = int.Parse(Carticon.Text);

                //validate no of items passed to be added in cart and no of items finally added in cart are same
                Assert.AreEqual(number, Number_of_items_in_cart, "No of items successfully added to cart:" + number);

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // method to return sum of price of all items added in the cart
        public decimal VerifyTotalAmountOfItemsInCart()
        {
            decimal Totalamount = 0.00m;


            try
            {

                driver.SwitchTo().DefaultContent();
                driver.FindElement(By.XPath("//*[@class='shopping_cart_link']")).Click();

                string Carticon_path = "//*[@class='shopping_cart_badge']";
                WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                IWebElement Carticon = wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath(Carticon_path)));

                int no = int.Parse(Carticon.Text);

                for (int i = 1; i <= no; i++)
                {

                    string pathttext_1 = "(//*[@class='inventory_item_price'])[" + i + "]";

                    WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                    IWebElement Priceofitem = wait2.Until(ExpectedConditions.ElementIsVisible(By.XPath(pathttext_1)));

                    string amount = (Priceofitem.Text).Replace("$", "");
                    decimal decimalValue = Convert.ToDecimal(amount);

                    Totalamount += decimalValue;
                }



            }

            catch (Exception ex)

            {
                Console.WriteLine(ex.ToString());
            }

            return Totalamount;

        }

        //method to remove items from top of the cart when sum of price of items exceed the maximum amount

        public void RemoveItemdfromCart(int maxamount)

        {
            try
            {
                decimal sum;
                sum = VerifyTotalAmountOfItemsInCart();
                Console.WriteLine("Sum of items in cart before removal of item from cart:" + sum);

                while (sum >= Convert.ToDecimal(maxamount))

                {

                    IWebElement Removebtn = driver.FindElement(By.XPath("(//*[@class='btn btn_secondary btn_small cart_button'])[1]"));
                    Removebtn.Click();
                    sum = VerifyTotalAmountOfItemsInCart();
                    Console.WriteLine("Sum of items in cart after removal of item from cart:" + sum);
                }
            }

            
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
}





    }
}
