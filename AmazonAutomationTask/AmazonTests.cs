using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace AmazonAutomationTask
{
    [TestFixture]
    public class AmazonTests : AmazonEntities
    {
        private readonly string navigateToUrl = "https://www.amazon.co.uk/";

        private AmazonWebElements elements;

        private readonly string searchedItem = "Harry Potter and the Cursed Child 1 & 2";

        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            elements = new AmazonWebElements();

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            PageFactory.InitElements(driver, elements);

            driver.Navigate().GoToUrl(navigateToUrl);
        }

        [TearDown]
        public void Dispose()
        {
            if (driver != null)
            {
                driver.Dispose();
            }
        }

        [Test]
        public void AmazonTitleCheck()
        {         
            Assert.AreEqual(driver.Title, "Amazon.co.uk: Low Prices in Electronics, Books, Sports Equipment & more", "Site title doesn't match");
        }

        [Test]
        public void SearchForBook()
        {
            SelectElementFromDropDown(elements.FilterByItemCategory, "Books");

            elements.SearchInputField.SendKeys(searchedItem);

             elements.SearchButton.Click();

            WaitForCondition(driver, ExpectedConditions.ElementToBeClickable(elements.SearchResultElement), 15000);

            var actualElementText = elements.SearchResultElement.Text;

            elements.SearchResultElement.Click();

            var expectedElementText = "Harry Potter and the Cursed Child - Parts One and Two: The Official Playscript of the Original West End Production";            

            Assert.AreEqual(expectedElementText, actualElementText);
        }

        [Test]
        public void CheckItemPrice()
        {
            SelectElementFromDropDown(elements.FilterByItemCategory, "Books");

            elements.SearchInputField.SendKeys(searchedItem);

            WaitForCondition(driver, ExpectedConditions.ElementToBeClickable(elements.SearchButton), 15000);

            elements.SearchButton.Click();            

            var expectedElementPrice = "£4.00";

            var actualItemPrice = elements.ItemPrice.GetAttribute("innerHTML");

            Assert.AreEqual(expectedElementPrice, actualItemPrice);
        }

        [Test]
        public void ChooseBookCover()
        {
            SelectElementFromDropDown(elements.FilterByItemCategory, "Books");

            elements.SearchInputField.SendKeys(searchedItem);

            elements.SearchButton.Click();

            WaitForCondition(driver, ExpectedConditions.ElementToBeClickable(elements.SearchButton), 15000);

            elements.SearchResultElement.Click();

            WaitForCondition(driver, ExpectedConditions.ElementToBeClickable(elements.PaperbackCoverElement), 15000);

            elements.PaperbackCoverElement.Click();

            var actualCover = elements.PaperbackCoverElement.Text;

            var expectedCover = "Paperback";            

            Assert.AreEqual(expectedCover, actualCover);
        }

        [Test]
        public void AddItemToBasket()
        {
            SelectElementFromDropDown(elements.FilterByItemCategory, "Books");

            elements.SearchInputField.SendKeys(searchedItem);

            elements.SearchButton.Click();

            WaitForCondition(driver, ExpectedConditions.ElementToBeClickable(elements.SearchButton), 15000);

            elements.SearchResultElement.Click();

            WaitForCondition(driver, ExpectedConditions.ElementToBeClickable(elements.PaperbackCoverElement), 15000);

            elements.PaperbackCoverElement.Click();

            elements.AddItemToBasket.Click();

            WaitForCondition(driver, ExpectedConditions.ElementToBeClickable(elements.ElementIsAGift), 10000);

            elements.ElementIsAGift.Click();

            Assert.IsTrue(elements.ElementIsAGift.Enabled);
        }

        [Test]
        public void PrePurcahseActions()
        {
            SelectElementFromDropDown(elements.FilterByItemCategory, "Books");

            elements.SearchInputField.SendKeys(searchedItem);

            elements.SearchButton.Click();

            WaitForCondition(driver, ExpectedConditions.ElementToBeClickable(elements.SearchButton), 15000);

            elements.SearchResultElement.Click();

            WaitForCondition(driver, ExpectedConditions.ElementToBeClickable(elements.PaperbackCoverElement), 15000);

            elements.PaperbackCoverElement.Click();

            elements.AddItemToBasket.Click();

            WaitForCondition(driver, ExpectedConditions.ElementToBeClickable(elements.ElementIsAGift), 10000);

            elements.ElementIsAGift.Click();

            Assert.Multiple(()=> 
            {
                Assert.AreEqual("Added to Basket", elements.AddedToBasket.Text);
                Assert.True(elements.ItemQuantityToTheBasket.Text.Contains("1 item"));
                Assert.AreEqual("£4.00", elements.ItemPriceInTheBasket.Text);
            });
        }
    }
}
