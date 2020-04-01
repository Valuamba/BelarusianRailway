using RailwayBy.PageObjects.Elements;
using System;
using System.Collections.Generic;
using System.Text;
using VSeleniumFramework.BaseSeleniumObjects;
using OpenQA.Selenium;

namespace RailwayBy.PageObjects.Form
{
    public class PassengersForm : BaseForm
    {
        private TextBox LastNameBox = new TextBox("Last Name", By.XPath("//input[contains(@id,'lastname')]"));
        private TextBox FirstNameBox = new TextBox("First Name", By.XPath("//input[contains(@id,'0:name')]"));
        private TextBox PatronymicNameBox = new TextBox("Patronymic Name", By.XPath("//input[contains(@id,'patronymic')]"));
        private TextBox DocumentNumberBox = new TextBox("Document number", By.XPath("//input[contains(@id,'docNum')]"));

        public PassengersForm(string name) : base(name)
        {

        }

        public void FillData(string lastname, string firstname, string patronymic, string docNumber)
        {
            LastNameBox.SendKeys(lastname);
            FirstNameBox.SendKeys(firstname);
            PatronymicNameBox.SendKeys(patronymic);
            DocumentNumberBox.SendKeys(docNumber);
        }
    }
}
