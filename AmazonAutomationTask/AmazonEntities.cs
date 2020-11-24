using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AmazonAutomationTask
{
    public class AmazonEntities
    {
        public void SelectElementFromDropDown(IWebElement element, string option)
        {          
            var selecteElement = new SelectElement(element);

            selecteElement.SelectByText(option);
        }

        public IWebElement WaitForCondition(IWebDriver driver, Func<IWebDriver, IWebElement> expectedCondition, double timeout)
        {
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));

            return webDriverWait.Until(expectedCondition);
        }
    }
}
