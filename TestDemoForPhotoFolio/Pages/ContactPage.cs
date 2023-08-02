using OpenQA.Selenium;
using PhotoFolio.Utils;


namespace PhotoFolio.Pages
{
    internal class ContactPage : BasePage
    {
        public ContactPage(IWebDriver driver) : base(driver) { }
        private Wait Wait => new(driver);

        private IWebElement NameBox => driver.FindElement(By.Id("name"));
        private IWebElement EmailBox => driver.FindElement(By.Id("email"));
        private IWebElement MessageBox => driver.FindElement(By.Id("message"));
        private IWebElement SendMessageButton => driver.FindElement(By.Id("send-message"));
        private IWebElement ClearButton => driver.FindElement(By.Id("clear"));
        private IWebElement PromptMessage => driver.FindElement(By.Id("alert-container"));
        private IWebElement NameBoxLabel =>driver.FindElement(By.Id("name"));

        public void GoToContactPage()
        {
            Wait.WaitForTheElementToBecomeVisible(() => ContactButton, TimeSpan.FromSeconds(5));
            ContactButton.Click();
        }
        public Boolean IfNameBoxIsVisible ()
        {
            Wait.WaitForTheElementToBecomeVisible(() => NameBox, TimeSpan.FromSeconds(5));
            return NameBox.Displayed;
        }

        public Boolean IfEmailBoxIsVisible ()
        {
            Wait.WaitForTheElementToBecomeVisible(() => EmailBox, TimeSpan.FromSeconds(5));
            return EmailBox.Displayed;
        }

        public Boolean IfMessageBoxIsVisible ()
        {
            Wait.WaitForTheElementToBecomeVisible(() => MessageBox, TimeSpan.FromSeconds(5));
            return MessageBox.Displayed;
        }
        public Boolean IfClearButtonIsVisible ()
        {
            Wait.WaitForTheElementToBecomeVisible(()=>SendMessageButton, TimeSpan.FromSeconds(5));
            return ClearButton.Displayed;
        }

        public Boolean IfSendMessageButtonIsVisible() 
        {
            Wait.WaitForTheElementToBecomeVisible(() => ClearButton, TimeSpan.FromSeconds(5));
            return SendMessageButton.Displayed; 
        }

        public void FillContactInfo(string name, string email, string message)
        {
            Wait.WaitForTheElementToBecomeVisible(() => NameBox, TimeSpan.FromSeconds(5));
            NameBox.SendKeys(name);
            EmailBox.SendKeys(email);
            MessageBox.SendKeys(message);
        }

        public string[] GetInfo()
        {
            string[] info= new string[3];
            info[0]=NameBox.GetAttribute("value");
            info[1]=EmailBox.GetAttribute("value");
            info[2]=MessageBox.GetAttribute("value");
            return info;
        }
        public void ClickSendMessageButton()
        {
            ScrollToElement(SendMessageButton);
            SendMessageButton.Click();
        }

        public void ClickClearButton() 
        { 
            ScrollToElement(ClearButton); 
            ClearButton.Click();
        }

        public Boolean PromptMessageIsVisible()
        {
            return PromptMessage.Displayed;
        }
        public string GetPromptMessage()
        {
            return PromptMessage.Text;
        }

        internal void GetRequiredInfoForName()
        {
            
        }
    }
}
