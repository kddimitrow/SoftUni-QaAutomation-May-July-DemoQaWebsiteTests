using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using System.Threading;

namespace DemoQaWebsiteTests
{
    public class Tests
    {

        private IWebDriver driverDemoQa;
        private Actions builderDemoQa;
        private Actions builderResize1;
        private Actions builderResize2;

        [SetUp]
        public void Setup()
        {
           

            //setup for DemoQa website tests

            driverDemoQa = new ChromeDriver();
            driverDemoQa.Manage().Window.Maximize();
            

            builderDemoQa = new Actions(driverDemoQa);

            // scroll down 
            // ((IJavaScriptExecutor)driverDemoQa).ExecuteScript("window.scrollBy(0,2500);");

        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        //Droppable tests

        [Test]
        public void droppableTests1()
        {

            driverDemoQa.Navigate().GoToUrl("http://www.demoqa.com/droppable");

            Thread.Sleep(1500);

            var dragMeButton = driverDemoQa.FindElement(By.CssSelector("#draggable"));

            var dropHerePlace = driverDemoQa.FindElement(By.CssSelector("#simpleDropContainer > div:nth-child(2)"));

            builderDemoQa.DragAndDrop(dragMeButton, dropHerePlace)
                        .Perform();

            
            
        }

        [Test]
        public void droppableTests2()
        {

            driverDemoQa.Navigate().GoToUrl("http://www.demoqa.com/droppable");

            Thread.Sleep(1500);


            var droppableAcceptClick = driverDemoQa.FindElement(By.Id("droppableExample-tab-accept"));
            droppableAcceptClick.Click();

            Thread.Sleep(1500);

            

            var acceptableButton = driverDemoQa.FindElement(By.Id("acceptable"));

            var droppedPlace = driverDemoQa.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div/div[2]/div/div[2]"));

            builderDemoQa.DragAndDrop(acceptableButton, droppedPlace)
                        .Perform();



        }


        [Test]
        public void droppableTests3()
        {
           

            driverDemoQa.Navigate().GoToUrl("http://www.demoqa.com/droppable");

            Thread.Sleep(1500);


            var droppableAcceptClick = driverDemoQa.FindElement(By.Id("droppableExample-tab-revertable"));
            droppableAcceptClick.Click();

            Thread.Sleep(1500);

            

            var willRevertButton = driverDemoQa.FindElement(By.Id("revertable"));

            var revertDroppedPlace = driverDemoQa.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div/div[4]/div/div[2]"));

            builderDemoQa.DragAndDrop(willRevertButton, revertDroppedPlace)
                        .Perform();


            Thread.Sleep(2500);

            Actions builderDroppableActionTest3 = new Actions(driverDemoQa);

            var notRevertButton = driverDemoQa.FindElement(By.Id("notRevertable"));
            var notRevertDroppedPlace  = driverDemoQa.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div/div[4]/div/div[2]"));

            builderDroppableActionTest3.DragAndDrop(notRevertButton, notRevertDroppedPlace)
                        .Perform();
        }


        //Draggable tests
        
        [Test]
        public void draggableTests1()
        {
           


            driverDemoQa.Navigate().GoToUrl("http://www.demoqa.com/dragabble");

            Thread.Sleep(1500);

            var dragMeDraggableButton = driverDemoQa.FindElement(By.Id("dragBox"));

            builderDemoQa.DragAndDropToOffset(dragMeDraggableButton, 100, 100)
                          .Perform();    
            
        }


        [Test]
        public void draggableTests2()
        {

            driverDemoQa.Navigate().GoToUrl("http://www.demoqa.com/dragabble");

            Thread.Sleep(1500);

            var axisRestrictedClick = driverDemoQa.FindElement(By.Id("draggableExample-tab-axisRestriction"));
            axisRestrictedClick.Click();

            Thread.Sleep(1500);


            var onlyXDragButton = driverDemoQa.FindElement(By.Id("restrictedX"));

            builderDemoQa.DragAndDropToOffset(onlyXDragButton, 100, 0)
                          .Perform();


            Thread.Sleep(1500);

            Actions builderDragableActionTest2 = new Actions(driverDemoQa);

            var onlyYDragButton = driverDemoQa.FindElement(By.Id("restrictedY"));

            builderDragableActionTest2.DragAndDropToOffset(onlyYDragButton, 0, 100)
                         .Perform();

        }

        //Resizable tests

        [Test]
        public void resizebleTests1()
        {

            driverDemoQa.Navigate().GoToUrl("http://www.demoqa.com/resizable");

            Thread.Sleep(1500);

            var resizableBoxWithRestriction = driverDemoQa.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div[1]/div/span"));

            builderResize1 = new Actions(driverDemoQa);

           
                         builderResize1.DragAndDropToOffset(resizableBoxWithRestriction, 25, 25)
                                 .Perform();

            Thread.Sleep(1500);
             
            //scroll down 
             ((IJavaScriptExecutor)driverDemoQa).ExecuteScript("window.scrollBy(0,450);");

            Thread.Sleep(1500);


            builderResize2 = new Actions(driverDemoQa);

            var resizableBoxWithoutRestriction = driverDemoQa.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div[2]/div/span"));

            builderResize2.DragAndDropToOffset(resizableBoxWithoutRestriction, 150, 150)
                    .Perform();
        }

        //Selectable tests

        [Test]
        public void selectableTests1()
        {

            driverDemoQa.Navigate().GoToUrl("http://www.demoqa.com/selectable");

            Thread.Sleep(1500);

            var selectButtonCras = driverDemoQa.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div/div[1]/ul/li[1]"));
            selectButtonCras.Click();

            Thread.Sleep(1000);

            var selectButtonDapibus = driverDemoQa.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div/div[1]/ul/li[2]"));
            selectButtonDapibus.Click();

            Thread.Sleep(1000);

            var selectButtonMorbi = driverDemoQa.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div/div[1]/ul/li[3]"));
            selectButtonMorbi.Click();

            Thread.Sleep(1000);

            var selectButtonPorta = driverDemoQa.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div/div[1]/ul/li[4]"));
            selectButtonPorta.Click();

        }


        [Test]

        public void sortableTest()
        {

            driverDemoQa.Navigate().GoToUrl("http://www.demoqa.com/sortable");

            Thread.Sleep(1500);

            var oneButton = driverDemoQa.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div/div[1]/div/div[1]"));

            var sixButton = driverDemoQa.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div/div[1]/div/div[6]"));

            builderDemoQa.DragAndDrop(oneButton, sixButton)
                         .Perform();

        }

        [TearDown]

        public void TearDown()
        {
            
        }

    }
}