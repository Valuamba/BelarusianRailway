using VSeleniumFramework.BaseSeleniumObjects;
using RailwayBy.PageObjects.Elements;
using OpenQA.Selenium;

namespace RailwayBy.PageObjects.Form.RouteForm
{ 
    public class DateForm : BaseForm
    {
        TextBox DepartureDateBox = new TextBox("Departure date", By.XPath("//*[@id='dateInfo']//input"));

        public DateForm(string name) : base(name)
        {
        }

        public void SetDate(string date)
        {
            DepartureDateBox.ClearText();
            DepartureDateBox.SendKeys(date);
        }
            
    }
}
