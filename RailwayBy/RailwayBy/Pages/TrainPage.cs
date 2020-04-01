using Atata;

namespace RailwayBy.Pages
{
    using _ = TrainPage;
    public class TrainPage : Page<_>
    {
        //private static readonly By radioButton_Locator = By.XPath("//*[@type='radio']");
        //private static readonly By routeBox_Locator = By.XPath("//a[contains(@onclick, 'route_url')]/span");
        //private static readonly By departureTime_Locator = By.XPath("//*[@class='tdCenter'][1]");
        //private static readonly By destinitionTime_Locator = By.XPath("//*[@class='tdCenter'][2]");
        //private static readonly By travelTime_Locator = By.XPath("//*[@class='tdCenter'][3]");
        //private static readonly By thirdClass_Locator = By.XPath("//td[@class='tdRight'][2]");
        //private static readonly By regularSeats_Locator = By.XPath("//td[@class='tdRight'][3]");
        //private static readonly By reservedBerths_Locator = By.XPath("//td[@class='tdRight'][4]");
        //private static readonly By compartment_Locator = By.XPath("//td[@class='tdRight'][5]");
        public class TrainItem : Control<_>
        {

        }


        public TableRowList<TrainRow, _> Trains { get; private set; }

        public class TrainRow : TableRow<_>
        {
            [FindByXPath("//*[@type='radio']")]
            public RadioButton<_> RadioButton { get; private set; }


            [FindByXPath("//a[contains(@onclick, 'route_url')]/span")]
            public Text<_> RouteLabel { get; private set; }
        }

        public class TrainTable : TableRowList<TrainRow,_>
        {

        }
    }
}
