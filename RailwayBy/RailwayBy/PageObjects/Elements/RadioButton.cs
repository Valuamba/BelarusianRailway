using VSeleniumFramework.BaseSeleniumObjects;
using OpenQA.Selenium;

namespace RailwayBy.PageObjects.Elements
{
    public class RadioButton : BaseElement
    {
        public RadioButton(string name, By elementLocator) : base(name, elementLocator)
        {
        }
        public RadioButton() : base()
        {

        }
    }
}
