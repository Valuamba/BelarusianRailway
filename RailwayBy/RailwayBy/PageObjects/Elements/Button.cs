using OpenQA.Selenium;
using VSeleniumFramework.BaseSeleniumObjects;

namespace RailwayBy.PageObjects.Elements
{
    public class Button : BaseElement
    {
        public Button(string name, By elementLocator) : base(name, elementLocator)
        {
        }

        public Button(IWebElement element) : base(element)
        {
        }

        public Button(string name) : base(name)
        {

        }
    }
}
