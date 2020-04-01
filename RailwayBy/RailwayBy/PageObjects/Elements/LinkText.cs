using OpenQA.Selenium;
using VSeleniumFramework.BaseSeleniumObjects;

namespace RailwayBy.PageObjects.Elements
{
    public class LinkText : BaseElement
    {
       

        public LinkText(string name, By elementLocator) : base(name, elementLocator)
        {
        }

        public LinkText(IWebElement element) : base(element)
        {
        }

        public LinkText(string name) : base(name)
        {
        }
    }
}
