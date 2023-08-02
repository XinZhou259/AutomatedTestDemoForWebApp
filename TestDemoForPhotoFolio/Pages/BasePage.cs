using OpenQA.Selenium;


namespace PhotoFolio.Pages
{
    internal class BasePage
    {
        protected IWebDriver driver;
        protected IWebElement NavBar => driver.FindElement(By.Id("navbar"));
        protected List<IWebElement> ParentNavBarItems => NavBar.FindElements(By.XPath("//li[not(ancestor::li)]")).ToList();
        protected IWebElement ContactButton => driver.FindElement(By.CssSelector("a.btn-get-started"));
        protected BasePage(IWebDriver driver) 
        {
            this.driver = driver;
        }

        protected void ScrollToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", element);
            Thread.Sleep(500);
        }

        public string GetPageUrl()
        {
            return driver.Url;
        }


    }
}
