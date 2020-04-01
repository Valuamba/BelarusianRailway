using VSeleniumFramework.BaseSeleniumObjects;
using RailwayBy.PageObjects.Elements;
using OpenQA.Selenium;

namespace RailwayBy.PageObjects.Form
{
    public class SelectCarForm : BaseForm
    {
        Button Submit = new Button("Submit car", By.XPath("//*[@type='submit']"));
        public SelectCarForm(string name) : base(name)
        {
            Locator = By.XPath("//*[@class='block']");
        }

        public void SelectCar()
        {
            Wait_UntilIsVisible();
            Submit.Click();
        }
    }
}
