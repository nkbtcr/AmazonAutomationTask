using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AmazonAutomationTask
{
    public class AmazonWebElements
    {
        [FindsBy(How = How.XPath, Using = "//input[contains(@class,'nav-input')]")]
        public IWebElement SearchInputField { get; set; }

        [FindsBy(How = How.Id, Using = "nav-search-submit-text")]
        public IWebElement SearchButton { get; set; }

        [FindsBy(How = How.Id, Using = "searchDropdownBox")]
        public IWebElement FilterByItemCategory { get; set; }

        [FindsBy(How = How.CssSelector, Using = "span[class='a-size-medium a-color-base a-text-normal']")]
        public IWebElement SearchResultElement { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='a-autoid-14-announce' or @id='a-autoid-12-announce']/span[text()='Paperback']")]
        public IWebElement PaperbackCoverElement { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='a-button-text']")]
        public IWebElement PapercoverItem { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(@class,'a-offscreen') and text()='£4.00']")]
        public IWebElement ItemPrice { get; set; }

        [FindsBy(How = How.Id, Using = "add-to-cart-button")]
        public IWebElement AddItemToBasket { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='huc-v2-gifting-container']")]
        public IWebElement ElementIsAGift { get; set; }

        [FindsBy(How = How.XPath, Using = "//h1[@class='a-size-medium a-text-bold']")]
        public IWebElement AddedToBasket { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), ' (1 item): ')]")]
        public IWebElement ItemQuantityToTheBasket { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='a-color-price hlb-price a-inline-block a-text-bold']")]
        public IWebElement ItemPriceInTheBasket { get; set; }
    }
    
}
