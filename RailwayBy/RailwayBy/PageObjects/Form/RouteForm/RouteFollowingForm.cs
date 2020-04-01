using VSeleniumFramework.BaseSeleniumObjects;
using RailwayBy.PageObjects.Elements;
using OpenQA.Selenium;

namespace RailwayBy.PageObjects.Form.RouteForm
{
    public class RouteFollowingForm : BaseForm
    {
        private readonly TextBox DeparturePointBox = new TextBox("Departure Point", By.XPath("//input[contains(@id,'textDepStat')]"));
        private readonly TextBox DestinitionPointBox = new TextBox("Destinition Point", By.XPath("//input[contains(@id,'textArrStat')]"));

        public RouteFollowingForm(string name)  : base(name)
        {
        }

        public void SetRoute(string departure, string destinition)
        {
            DeparturePointBox.SendKeys(departure);
            DestinitionPointBox.SendKeys(destinition);
        }
    }
}
