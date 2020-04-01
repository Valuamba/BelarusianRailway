using VSeleniumFramework.BaseSeleniumObjects;
using RailwayBy.PageObjects.Elements;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace RailwayBy.PageObjects.Form
{
    public class TrainForm : BaseForm
    {
        //TextLabel DepartureTime = new TextLabel("Departure time", By.XPath("//*[contains(text(),':') and number(translate(text(),':','')) < 2359]"));

        private static readonly By radioButton_Locator = By.XPath("//*[@type='radio']");
        private static readonly By routeBox_Locator = By.XPath("//a[contains(@onclick, 'route_url')]/span");
        private static readonly By departureTime_Locator = By.XPath("//*[@class='tdCenter'][1]");
        private static readonly By destinitionTime_Locator = By.XPath("//*[@class='tdCenter'][2]");
        private static readonly By travelTime_Locator = By.XPath("//*[@class='tdCenter'][3]");
        private static readonly By thirdClass_Locator = By.XPath("//td[@class='tdRight'][2]");
        private static readonly By regularSeats_Locator = By.XPath("//td[@class='tdRight'][3]");
        private static readonly By reservedBerths_Locator = By.XPath("//td[@class='tdRight'][4]");
        private static readonly By compartment_Locator = By.XPath("//td[@class='tdRight'][5]");


        //RadioButton SelectButton = new RadioButton("Select button", By.XPath("//*[@type='radio']"));
        //TextLabel RouteBox = new TextLabel("Route", By.XPath("//a[contains(@onclick, 'route_url')]/span"));
        //TextLabel DepartureTime = new TextLabel("Departure time", By.XPath("//*[@class='tdCenter'][1]"));
        //TextLabel DestinitionTime = new TextLabel("Destinition time", By.XPath("//*[@class='tdCenter'][2]"));
        //TextLabel TravelTime = new TextLabel("Departure time", By.XPath("//*[@class='tdCenter'][3]"));


        //TextLabel ThirdClassLabel = new TextLabel("Third class", By.XPath("//td[@class='tdRight'][2]"));
        //TextLabel RegularSeatsLabel = new TextLabel("Third class", By.XPath("//td[@class='tdRight'][3]"));
        //TextLabel ReservedBerthsLabel = new TextLabel("Third class", By.XPath("//td[@class='tdRight'][4]"));
        //TextLabel CompartmentLabel = new TextLabel("Third class", By.XPath("//td[@class='tdRight'][5]"));


        TextLabel ArrivalBox = new TextLabel("Route", By.XPath(""));
        TextLabel TimeBox = new TextLabel("Route", By.XPath(""));


        List<RadioButton> RadioButton;
        List<TextLabel> RouteBox;
        List<TextLabel> DepartureTime;
        List<TextLabel> DestinitionTime;
        List<TextLabel> TravelTime;
        List<TextLabel> ThirdClassLabel;
        List<TextLabel> RegularSeatsLabel;
        List<TextLabel> ReservedBerthsLabel;
        List<TextLabel> CompartmentLabel;

        public TrainForm(string name) : base(name)
        {
            Locator = By.XPath("//tbody[contains(@id,'tbody_element')]");
        }

        public TrainForm() : base()
        {

        }

        public void TrainInitialization()
        {
            RadioButton = FindElements<RadioButton>(radioButton_Locator);
            RouteBox = FindElements<TextLabel>(routeBox_Locator);
            DepartureTime = FindElements<TextLabel>(departureTime_Locator);
            DestinitionTime = FindElements<TextLabel>(destinitionTime_Locator);
            TravelTime = FindElements<TextLabel>(travelTime_Locator);
            ThirdClassLabel = FindElements<TextLabel>(thirdClass_Locator);
            RegularSeatsLabel = FindElements<TextLabel>(regularSeats_Locator);
            ReservedBerthsLabel = FindElements<TextLabel>(reservedBerths_Locator);
            CompartmentLabel = FindElements<TextLabel>(compartment_Locator);
        }

        public void SelectTrain(string number)
        {
            Wait_UntilIsVisible();
            RadioButton[RouteBox.IndexOf(RouteBox.Single(x => x.Text().Contains(number)))].Click();
        }
    }
}
