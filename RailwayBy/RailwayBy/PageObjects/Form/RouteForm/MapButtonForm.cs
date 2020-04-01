using VSeleniumFramework.BaseSeleniumObjects;
using RailwayBy.PageObjects.Elements;
using OpenQA.Selenium;

namespace RailwayBy.PageObjects.Form.RouteForm
{
    public class MapButtonForm : BaseForm
    {
        private Button Continue;
        private Button Cancel = new Button("Continue", By.XPath("//input[@value='Cancel']"));


        public MapButtonForm(string name) : base(name)
        {   
        }

        public void Action(string action)
        {
            Continue = new Button("Continue", By.XPath(string.Format("//input[contains(@id,'{0}')]", action)));
            Continue.Click();
        }
    }
}
