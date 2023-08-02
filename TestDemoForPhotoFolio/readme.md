**Just for showing some practical automated test cases for website application testing.**

**Setup environment:**
1.	Download the test scripts folder “TestDemoForPhotoFolio” and the testing website folder “PhotoFolio”.
2.	Open test scripts project “PhotoFolio” with VS, find file “BaseTest.cs” under Tests folder.
3.	Change the website url to your file location for websit folder “PhotoFolio” on line 19.

**Test scripts brief description:**
1.	There are three test classes under Tests folder. They are: BaseTest.cs, HomePageTests.cs, ContactPageTests.cs.
2.	For BaseTest.cs, it includes the Sutup and TearDown method for WebDriver, and create driver method.
3.	For HomePage.cs, it includes some test cases for Home page of the website. I just pick some practical test points, doesn’t match tests for all elements. For example, if there are several same type elements, I just write test case for one of them.
4.	For ContacPageTest.cs, it includes some practical test cases for ContactPage.
5.	There are several other pages with same or similar elements in Homepage, so I don’t write test cases for them repeatedly.

 
