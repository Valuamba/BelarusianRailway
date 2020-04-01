using VSeleniumFramework.BaseSeleniumObjects;
using RailwayBy.PageObjects.Elements;
using OpenQA.Selenium;

namespace RailwayBy.PageObjects.Form
{
    public class LoginForm : BaseForm
    {
        private TextBox LoginBox;
        private readonly Button SubmitButton = new Button("Submit button", By.XPath("//input[@class='commandExButton']"));
        private readonly CheckBox ConfirmBox = new CheckBox("Confirm Box", By.XPath("//input[@type='checkbox']"));
        public LoginForm(string name) : base(name)
        {
            Locator = By.XPath("//div[@class='login']");
        }

        public void Logining(string inputParameter, string loginText)
        {
            LoginBox = new TextBox(inputParameter, By.XPath(string.Format("//input[@id='{0}']", inputParameter)));
            LoginBox.SendKeys(loginText);
        }

        public void Submit()
        {
            SubmitButton.Click();
        }

        public void Confirm()
        {
            ConfirmBox.Click();
        }
    }
}
