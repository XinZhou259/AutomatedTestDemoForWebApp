using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using PhotoFolio.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PhotoFolio.Tests
{
    internal class ContactPageTests: BaseTest
    {
        
        private ContactPage contactPage;
        [SetUp]
        public void SetUp() 
        { 
            contactPage = new ContactPage(driver);
        }

        [Test]
        public void TestNavigateToContactPage()
        {
            contactPage.GoToContactPage();

            Assert.That(contactPage.GetPageUrl(), Does.Contain("contact.html"),
                "The Contact page is not displayed");

        }
        [Test]
        public void TestContactBoxesAreDisplayed()
        {
            contactPage.GoToContactPage();
            Assert.Multiple(() =>
            {
                Assert.That(contactPage.IfNameBoxIsVisible, Is.True, "The Name box is not displayed.");
                Assert.That(contactPage.IfEmailBoxIsVisible, Is.True, "The Email box is not displayed.");
                Assert.That(contactPage.IfMessageBoxIsVisible, Is.True, "The Message box is not displayed.");
            });
        }

        [Test]
        public void TestSendMessageButtonDisplayed() 
        {
            contactPage.GoToContactPage();
            Assert.That(contactPage.IfSendMessageButtonIsVisible, Is.True, "The Send Message button is not displayed.");
        }

        [Test]
        public void TestClearButtonDisplayed() 
        {
            contactPage.GoToContactPage();
            Assert.That(contactPage.IfClearButtonIsVisible, Is.True, "The Clear button is not displayed.");
        }

        [Test]
        public void TestFillInfo()
        {
            string[] infoEntered = new string[] { "Cathy", "cathy@test.com", "Test message." };
            contactPage.GoToContactPage();
            contactPage.FillContactInfo(infoEntered[0], infoEntered[1], infoEntered[2]);
            string[] infoDisplayed = contactPage.GetInfo();
            Assert.Multiple(() =>
            {
                Assert.That(infoDisplayed[0], Is.EqualTo(infoEntered[0]), "Name is displayed wrong.");
                Assert.That(infoDisplayed[1], Is.EqualTo(infoEntered[1]), "Email is displayed wrong.");
                Assert.That(infoDisplayed[2], Is.EqualTo(infoEntered[2]), "Message is displayed wrong.");
            });
        }

        [Test]
        public void TestShowSuccessMessage()
        {
            string[] infoEntered = new string[] { "Cathy", "cathy@test.com", "Test message." };
            contactPage.GoToContactPage();
            contactPage.FillContactInfo(infoEntered[0], infoEntered[1], infoEntered[2]);            
            contactPage.ClickSendMessageButton();
            Assert.Multiple(() =>
            {
                Assert.That(contactPage.PromptMessageIsVisible(), Is.True, "Prompt message is not displayed.");
                Assert.That(contactPage.GetPromptMessage, Is.EqualTo("Your message has been sent. Thank you!"),
                    "Prompt message is not correcct.");
            });
        }

        [Test]
        public void TestShowRequiredMessage()
        {
            contactPage.GoToContactPage();
            Thread.Sleep(1000);
            contactPage.ClickSendMessageButton();
            Assert.Multiple(() =>
            {
                Assert.That(contactPage.PromptMessageIsVisible(), Is.True, "Prompt message is not displayed.");
                Assert.That(contactPage.GetPromptMessage, Is.EqualTo("Please fill out name, email and message."),
                    "Prompt message is not correcct.");
            });

        }

        [Test]
        public void TestClearFuction()
        {
            string[] infoEntered = new string[] { "Cathy", "cathy@test.com", "Test message." };
            contactPage.GoToContactPage();
            contactPage.FillContactInfo(infoEntered[0], infoEntered[1], infoEntered[2]);
            contactPage.ClickClearButton();
            string[] infoDisplayed = contactPage.GetInfo();
            for(int i = 0; i < infoDisplayed.Length; i++)
            {                
                Assert.That(infoDisplayed[i], Is.Empty, "Contact info is not cleared.");
            }           

        }

      
    }
}
