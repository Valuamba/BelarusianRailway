using System;
using System.Collections.Generic;
using System.Text;
using VSeleniumFramework.BaseSeleniumObjects;
using RailwayBy.PageObjects.Elements;
using OpenQA.Selenium;

namespace RailwayBy.PageObjects.Form
{
    public class SigninForm : BaseForm
    {
        private TextLabel Signin = new TextLabel("Sign in", By.XPath("//a[contains(@onclick, 'login_main')]"));
        public SigninForm(string name) : base(name)
        {
            Locator = By.XPath("//a[contains(@onclick, 'login_main')]");
        }

        public void Goto_LoginForm()
        {
            Signin.Click();
        }
    }
}
