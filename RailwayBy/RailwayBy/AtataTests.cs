using NUnit.Framework;
using Atata;
using RailwayBy.Pages;
using VSeleniumFramework.Helpers;
using System.Linq;

namespace RailwayBy
{
    [TestFixture]
    public class AtataTests
    {
        [SetUp]
        public void Init()
        {
            AtataContext.Configure().
                UseChrome().
                WithArguments("start-maximized").
                UseBaseUrl("https://poezd.rw.by/").
                UseNUnitTestName().
                AddNUnitTestContextLogging().
                WithoutSectionFinish().
                LogNUnitError().
                Build();

        }

        [TearDown]
        public void TearDown()
        {
           // AtataContext.Current?.CleanUp();
        }

        [Test]
        public void Test()
        {
            Go.To<SignInPage>().Signin.Click();
            Go.To<LoginPage>().
                Login.Set(FileUtils.GetProperty("Login")).
                Password.Set(FileUtils.GetProperty("Password")).
                CommandExButton.Click().
                ConfirmBox.Click();


            Go.To<RoutePage>().
                DeparturePointBox.Set(FileUtils.GetProperty("DeparturePoint")).
                DestinitionPointBox.Set(FileUtils.GetProperty("DestinitionPoint")).
                DepartureDateBox.Set(new System.DateTime(2020, 4, 01)).
                ContinueButton.ClickAndGo().

                Trains.First(x => x.RouteLabel == FileUtils.GetProperty("TrainNumber")).
                RadioButton.ClickAndGo<CarsPage>().
                Submit.ClickAndGo().

                LastName.Set(FileUtils.GetProperty("LastName")).
                FirstName.Set(FileUtils.GetProperty("FirstName")).
                PatronymicName.Set(FileUtils.GetProperty("PatronymicName")).
                DocumentNumber.Set(FileUtils.GetProperty("DocumentNumber")).
                Seat.Click().
                ConfirmBox.ClickAndGo<CheckOrderPage>().

                Continue.ClickAndGo<ComplitePage>().

                PaymentTable.Rows[x => x.Method == "Оплата с помощью банковских карт"].
                RadioButton.Click()

                ;

            

        }


        [Test]
        public void TestRouteTable()
        {
            Go.To<SignInPage>().Signin.Click();
            Go.To<LoginPage>().
                Login.Set(FileUtils.GetProperty("Login")).
                Password.Set(FileUtils.GetProperty("Password")).
                CommandExButton.Click().
                ConfirmBox.Click();


            Go.To<RoutePage>().
                RouteConfigurationTable.
                Rows[x => x.RouteTitle == "Станция отправления"].
                RouteValueBox.Set(FileUtils.GetProperty("DeparturePoint")).

                RouteConfigurationTable.
                Rows[x => x.RouteTitle == "Станция назначения"].
                RouteValueBox.Set(FileUtils.GetProperty("DestinitionPoint")).


                DepartureDateBox.Set(new System.DateTime(2020, 4, 01));
        }
    }
}
