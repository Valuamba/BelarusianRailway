using Atata;
using Atata.Bootstrap;

namespace RailwayBy.Pages
{
    using _ = RoutePage;
    public class RoutePage : Page<_>
    {
        [FindByXPath("//*[@id='dateInfo']//input")]
        public DateInput<_> DepartureDateBox { get; private set; }

        [FindByXPath("//input[contains(@id,'textDepStat')]")]
        public TextInput<_> DeparturePointBox { get; private set; }

        [FindByXPath("//input[contains(@id,'textArrStat')]")]
        public TextInput<_> DestinitionPointBox { get; private set; }

        [Term("Продолжить", "Сбросить")]
        public Button<TrainPage, _> ContinueButton { get; private set; }


        [FindByClass("fields")]
        public Table<RouteRow, _> RouteConfigurationTable { get; private set; }

        public class RouteRow : TableRow<_>
        {
            [FindByIndex(0)]
            public Text<_> RouteTitle { get; private set; }

            [FindByIndex(0)]
            public TextInput<_> RouteValueBox { get; private set; }
        }
       
    }
}
