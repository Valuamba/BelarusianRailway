using OpenQA.Selenium;
using System;
using VSeleniumFramework.BaseSeleniumObjects;


namespace RailwayBy.PageObjects.Elements
{
    public class TextLabel : BaseElement
    { 
        
        public TextLabel(string name, By elementLocator) : base(name, elementLocator)
        {
        }

        public TextLabel(IWebElement element) : base(element)
        {
        }

        public TextLabel(string name) : base(name)
        {
        }

        public TextLabel() : base()
        {

        }
    }
}
