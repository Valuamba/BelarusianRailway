using VSeleniumFramework.BaseSeleniumObjects;
using OpenQA.Selenium;

namespace RailwayBy.PageObjects.Elements
{
    public class TextBox : BaseElement
    {
        public TextBox(string name, By locator) : base(name, locator)
        {          
        }
        public TextBox() : base()
        {

        }
    }
}
