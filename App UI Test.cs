using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace SeleniumBingTests
{
    /// <summary>
    /// Summary description for MySeleniumTests
    /// </summary>
    [TestClass]
    public class MySeleniumTests
    {
        private TestContext testContextInstance;
        private IWebDriver driver;
        private string appURL;

        public MySeleniumTests()
        {
        }

        [TestMethod]
        [TestCategory("Chrome")]
        public void TheBingSearchTest()
        {
            // BAD TEST

            appURL = "Your Website";
            driver.Navigate().GoToUrl(appURL + "/");
            driver.FindElement(By.Id("HTML Id Assigned to Username Textbox")).SendKeys("username");
            driver.FindElement(By.Id("HTML Id Assigned to Password Textbox")).SendKeys("password");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_Login1_LoginButton")).Click();
            Assert.IsTrue(driver.Title.Contains("Home"), "Verified title of the page");
        }

        [TestMethod]
        [TestCategory("Chrome")]
        [Obsolete]
        public void FormsAdminTest()
        {
            // GOOD TEST
			
            //Login Page + User Management Page
            appURL = "Your Website";
            driver.Navigate().GoToUrl(appURL + "/");
            driver.FindElement(By.Id("HTML Id Assigned to Username Textbox")).SendKeys("username");
            driver.FindElement(By.Id("HTML Id Assigned to Password Textbox")).SendKeys("password");
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_Login1_LoginButton")).Click();
            driver.FindElement(By.Id("search")).SendKeys("Nisha Verma" + Keys.Enter);
            WebDriverWait impersonateWait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            impersonateWait.Until(ExpectedConditions.ElementIsVisible(By.Id("impersonateButton")));
            driver.FindElement(By.Id("impersonateButton")).Click();
            Assert.IsTrue(driver.Title.Contains("User Management"), "Verified title of the page");

            //Admin Page
            //appURL = "Your Website";
            //driver.Navigate().GoToUrl(appURL + "/");
            ////Search Textbox
            //driver.FindElement(By.Id("searchBar")).SendKeys("Admin Page");
            ////System Filter
            //driver.FindElement(By.XPath("//div[@id='sectionSystemFilter']/input")).Click();
            //driver.FindElement(By.XPath("//div[@id='sectionSystemFilter']/input")).SendKeys("Change Control");
            //driver.FindElement(By.XPath("//div[@id='sectionSystemFilter']/input")).SendKeys(Keys.ArrowDown);
            //driver.FindElement(By.XPath("//div[@id='sectionSystemFilter']/input")).SendKeys(Keys.Enter);
            ////Record Type Filter
            //driver.FindElement(By.XPath("//div[@id='sectionRecordTypeFilter']/input")).SendKeys("None");
            ////Save Button
            //driver.FindElement(By.Id("theSaveButton")).Click();
            ////Results
            //Assert.IsTrue(driver.Title.Contains("Forms System Admin"), "Verified title of the page");

            //Forms Record Page
            appURL = "Your Website";
            driver.Navigate().GoToUrl(appURL + "/");
            //System Filter
            driver.FindElement(By.XPath("//div[@id='systemFilter']/input")).Click();
            driver.FindElement(By.XPath("//div[@id='systemFilter']/input")).SendKeys("Maintenance Management");
            driver.FindElement(By.XPath("//div[@id='systemFilter']/input")).SendKeys(Keys.ArrowDown);
            driver.FindElement(By.XPath("//div[@id='systemFilter']/input")).SendKeys(Keys.Enter);
            //Type Filter
            var education = driver.FindElement(By.Id("recordType"));
            var selectElement = new OpenQA.Selenium.Support.UI.SelectElement(education);
            selectElement.SelectByText("Maintenance Work Request");
            //Search Textbox
            driver.FindElement(By.Id("searchBar")).SendKeys("Records Page");
            //Location Filter
            WebDriverWait locationWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            locationWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='datum col-sm-1'][1]/div/div/div/div/div/div/div/div/div/div/div/div/input")));
            driver.FindElement(By.XPath("//div[@class='datum col-sm-1'][1]/div/div/div/div/div/div/div/div/div/div/div/div/input")).SendKeys("Die Design" + Keys.Tab);
            driver.FindElement(By.XPath("//div[@class='datum col-sm-1'][1]/div/div/div/div/div/div/div/div/div/div/div/div/input")).Click();
            driver.FindElement(By.XPath("//div[@class='datum col-sm-1'][1]/div/div/div/div/div/div/div/div/div/div/div/div/input")).SendKeys(Keys.Enter);
            //Priority Filter
            WebDriverWait priorityWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            priorityWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='datum col-sm-1'][2]/div/div/div/input")));
            driver.FindElement(By.XPath("//div[@class='datum col-sm-1'][2]/div/div/div/input")).SendKeys("3 - Improvement" + Keys.Tab);
            driver.FindElement(By.XPath("//div[@class='datum col-sm-1'][2]/div/div/div/input")).Click();
            driver.FindElement(By.XPath("//div[@class='datum col-sm-1'][2]/div/div/div/input")).SendKeys(Keys.Enter);
            //Status Filter
            WebDriverWait statusWait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            statusWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='datum col-sm-1'][3]/div/div/div/input")));
            driver.FindElement(By.XPath("//div[@class='datum col-sm-1'][3]/div/div/div/input")).SendKeys("Safety issue" + Keys.Tab);
            driver.FindElement(By.XPath("//div[@class='datum col-sm-1'][3]/div/div/div/input")).Click();
            driver.FindElement(By.XPath("//div[@class='datum col-sm-1'][3]/div/div/div/input")).SendKeys(Keys.Enter);
            //Problem & Comments Textbox
            driver.FindElement(By.XPath("//div[@class='datum col-sm-1'][4]/div/textarea")).SendKeys("Problems");
            driver.FindElement(By.XPath("//div[@class='datum col-sm-1'][5]/div/textarea")).SendKeys("Comments");
            //Create Button
            driver.FindElement(By.Id("theSaveButton")).Click();

            Assert.IsTrue(driver.Title.Contains("New Record"), "Verified title of the page");
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestInitialize()]
        public void SetupTest()
        {
            string browser = "Chrome";
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
           // driver.Quit(); If you don't want to exit the window by itself.
        }
    }
}