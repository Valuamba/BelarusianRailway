using System;
using System.Collections.Generic;
using System.Text;
using VSeleniumFramework.BaseSeleniumObjects;
using OpenQA.Selenium;

namespace RailwayBy.PageObjects.Elements
{
    public class CheckBox : BaseElement
    {
        public CheckBox(string name, By locator) : base(name, locator)
        {
        }
    }
}
