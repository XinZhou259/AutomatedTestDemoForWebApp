using PhotoFolio.Pages;
using OpenQA.Selenium;

namespace PhotoFolio.Tests
{
    internal class HomePageTests : BaseTest
    {
        private HomePage homePage;
       

        [SetUp]
        public void SetUp() 
        {
            homePage = new HomePage(driver);           

        }

        [Test]
        public void TestHeaderIsDisplayed()
        {
         
            Assert.That(homePage.IfHeaderIconVisible, Is.True,"Header Icon is not displayed");            
            Assert.That(homePage.IfHeaderTextVisible, Is.True, "Header Text is not displayed");
        }

        [Test]
        public void TestParentNavBarItemName()
        {
            List<IWebElement> navBarItems = homePage.GetParentNavBarItems();      
            
            string[] expectedName = {"HOME","ABOUT","GALLERY","SERVICES","CONTACT" }; 

            for(int i = 0; i < navBarItems.Count; i++)
            {
                string actureName = navBarItems[i].Text;
                Assert.That(actureName, Is.EqualTo(expectedName[i]), "Text mismatch at index["+i+"]");               
            }
        }

        [Test]
        public void TestGalleryDropdownItems() 
        {
            List<IWebElement> galleryDropdownItems = homePage.GetGalleryDropdwonItems();
            string[] expectedItem = { "Nature", "Animals", "Travel" };
            
            for(int i = 0; i < galleryDropdownItems.Count;i++)
            {
                string actureItem = galleryDropdownItems[i].Text;                
                Assert.That(actureItem, Is.EqualTo(expectedItem[i]), "Item mismatch at index[" + i+"]");


            }
        }

        [Test]
        public void TestDescription()
        {
            Assert.That(homePage.GetDescription(), Is.EqualTo("I'm a Professional Photographer from New York City"),
                "The Description content is not correct.");

        }

        [Test]
        public void TestContactButton()
        {
            Assert.Multiple(() =>
            {
                Assert.That(homePage.IsContactButtonVisible, Is.True, "'Available for hir' button is not displayed.");
                Assert.That(homePage.GetContactButtonText, Is.EqualTo("AVAILABLE FOR HIRE"),
                    "The text for 'Available for hire' button is not correct.");
                Assert.That(homePage.GetContactButtonLinkText(), Does.Contain("contact.html"),
                    "The link text for 'Available for hire' button is not correct.");
            });
        }

        [Test]
        public void TestImagesAreAllDisplayed()
        {           
            Assert.That(homePage.GetImages(), Has.Count.EqualTo(16), "There are images are missing");
        }

        [Test]
        public void TestNavigateToNaturePage()
        {
            homePage.NavigateToNaturePage();           

            Assert.That(homePage.GetPageUrl(), Does.Contain("nature.html"),
                "The Nature page is not displayed");
            
        }

        
    }
}
