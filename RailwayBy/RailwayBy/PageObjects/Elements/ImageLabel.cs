using OpenQA.Selenium;
using VSeleniumFramework.BaseSeleniumObjects;

namespace RailwayBy.PageObjects.Elements
{
    class ImageLabel : BaseElement
    {
       

        public ImageLabel(string name, By elementLocator) : base(name, elementLocator)
        {
        }

        public ImageLabel(IWebElement element) : base(element)
        {
        }

        public ImageLabel(string name) : base(name)
        {
        }

       
    }
}
