using NUnit.Framework;
using RailwayBy.PageObjects.Form;
using RailwayBy.PageObjects;
using VSeleniumFramework.Helpers;
using VSeleniumFramework.BaseSeleniumObjects;
using System.IO;

namespace RailwayBy
{
    public class Tests
    {
        BaseSingleton singleton;
        [SetUp]
        public void Setup()
        {
            singleton = BaseSingleton.GetInstance("Singleton");
            singleton.NavigateToUrl();
        }

        [OneTimeSetUp]
        public void Init()
        {
            File.WriteAllText(FileUtils.GetProperty("LogFile"), string.Empty);
        }

        //[Test]
        public void Test1()
        {
            SigninForm SigninForm = new SigninForm("Sign in");
            SigninForm.Goto_LoginForm();

            LoginForm LoginForm = new LoginForm("Login");
            LoginForm.Logining("login", FileUtils.GetProperty("Login"));
            LoginForm.Logining("password", FileUtils.GetProperty("Password"));
            LoginForm.Submit();
            LoginForm.Confirm();

            RoutePage RoutePage = new RoutePage();
            RoutePage.SetRouteInformation(FileUtils.GetProperty("DeparturePoint"), 
                FileUtils.GetProperty("DestinitionPoint"), 
                FileUtils.GetProperty("DepartureDate"));


            TrainForm TrainForm = new TrainForm("TrainForm");
            TrainForm.TrainInitialization();
            TrainForm.SelectTrain(FileUtils.GetProperty("TrainNumber"));


            SelectCarForm SelectCarForm = new SelectCarForm("Select car");
            SelectCarForm.SelectCar();

            PassengersForm PassengersForm = new PassengersForm("Passenger form");
            PassengersForm.FillData(FileUtils.GetProperty("LastName"),
                FileUtils.GetProperty("FirstName"),
                FileUtils.GetProperty("PatronymicName"),
                FileUtils.GetProperty("DocumentNumber"));
        }

        public void AtataTests()
        {

        }
    }
}