using System;
using System.Collections.Generic;
using System.Text;
using RailwayBy.PageObjects.Form.RouteForm;

namespace RailwayBy.PageObjects
{
    public class RoutePage
    {
        public void SetRouteInformation(string departure, string destinition, string date)
        {
            RouteFollowingForm RouteForm = new RouteFollowingForm("Route form");
            RouteForm.SetRoute(departure, destinition);

            DateForm DateForm = new DateForm("Date Form");
            DateForm.SetDate(date);

            MapButtonForm MapForm = new MapButtonForm("Map form");
            MapForm.Action("buttonSearch");
        }
    }
}
