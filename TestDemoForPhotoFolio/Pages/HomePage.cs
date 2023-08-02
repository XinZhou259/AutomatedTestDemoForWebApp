using OpenQA.Selenium;
using PhotoFolio.Utils;
using OpenQA.Selenium.Interactions;

namespace PhotoFolio.Pages
{
    internal class HomePage : BasePage
    {

        public HomePage(IWebDriver driver) : base(driver) { }

        private Wait Wait => new(driver);
        private IWebElement HeaderText => driver.FindElement(By.XPath("//*[@id=\"header\"]/div/a/h1"));
        private IWebElement HeaderIcon => driver.FindElement(By.ClassName("bi-camera"));
        private IWebElement GalleryDropdown => NavBar.FindElement(By.CssSelector("li.dropdown"));
        private IWebElement Description => driver.FindElement(By.TagName("h2"));        
        private List<IWebElement> Images => driver.FindElements(By.TagName("img")).ToList();

        public Boolean IfHeaderIconVisible()
        {
            return HeaderIcon.Displayed;
        }

        public Boolean IfHeaderTextVisible()
        {
            return HeaderText.Displayed;
        }

        public List<IWebElement> GetParentNavBarItems()
        {
            return ParentNavBarItems;
        }

        public List<IWebElement> GetGalleryDropdwonItems()
        {


            Actions actions = new Actions(driver);
            actions.MoveToElement(GalleryDropdown).Perform();
            Thread.Sleep(2000);
            List<IWebElement> GalleryDropdownItems = GalleryDropdown.FindElements(By.XPath(".//ul/li")).ToList();

            return GalleryDropdownItems;
        }

        public string GetDescription()
        {
            Wait.WaitForTheElementToBecomeVisible(() => Description, TimeSpan.FromSeconds(5));
            return Description.Text;
        }

        public Boolean IsContactButtonVisible()
        {
            Wait.WaitForTheElementToBecomeVisible(() => ContactButton, TimeSpan.FromSeconds(5));
            return ContactButton.Displayed;
        }
        public string GetContactButtonText()
        {
            return ContactButton.Text;
        }

        public string GetContactButtonLinkText()
        {
            return ContactButton.GetAttribute("href");
        }

        public List<IWebElement> GetImages()
        {
            return Images;
        }

        public void NavigateToNaturePage()
        {
            List<IWebElement> gallaryDropdownItems = GetGalleryDropdwonItems();
            gallaryDropdownItems[0].Click();
        }
    }
}
