using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Reflection;
using VSeleniumFramework.Helpers;

namespace VSeleniumFramework.BaseSeleniumObjects
{
    public abstract class BaseElement
    {
        
        private readonly string nameType;

        // Name
        internal protected string Name { get; set; }
        

        //Element Locator
        public virtual By Locator { get; set; }
       

        //FormDriver
        private IWebElement elementDriver;
        internal virtual IWebElement ElementDriver
        {
            get
            {
                if (elementDriver != null)
                    return elementDriver;
                else
                    return BaseSingleton.GetDriver().FindElement(Locator);
               

                throw new ArgumentException("Element driver is not found locator");
            }
            set
            {
                elementDriver = value;
            }

        }


       

        public BaseElement(string name, By locator) : this(name)
        {
            try
            {
                   this.Locator = locator ?? throw new System.NullReferenceException();
            }
            catch (Exception e)
            {
                Logger.Error(nameType, Name, MethodBase.GetCurrentMethod().Name, e.GetType().Name);
                throw new Exception(e.Message);
            }
        }

        public BaseElement(IWebElement element) : this()
        {
            elementDriver = element;
        }

        public BaseElement(string name) : this()
        {
            try
            {
                this.Name = name ?? throw new System.NullReferenceException();
            }
            catch (Exception e)
            {
                Logger.Error(nameType, name, MethodBase.GetCurrentMethod().Name, e.GetType().Name);
                throw new Exception(e.Message);
            }
        }

        public BaseElement(By locator) : this()
        {
            try
            {
                this.Locator = locator ?? throw new System.NullReferenceException();
            }
            catch (Exception e)
            {
                Logger.Error(nameType, Name, MethodBase.GetCurrentMethod().Name, e.GetType().Name);
                throw new Exception(e.Message);
            }
        }

        public BaseElement()
        {
            nameType = this.GetType().Name;
        }

       
        


        public virtual void Click()
        {
            Logger.Info(nameType, Name, MethodBase.GetCurrentMethod().Name);
            
            ElementDriver.Click();
        }


        public virtual void SendKeys(string text)
        {
            ElementDriver.SendKeys(text);
        }

        public virtual void ClearText()
        {
            ElementDriver.Clear();
        }

        public virtual void MoveTo(By locator)
        {
            Wait_UntilIsVisible();

            Logger.Info(nameType, Name, MethodBase.GetCurrentMethod().Name);

            Actions actions = new Actions(BaseSingleton.GetDriver());

            actions.MoveToElement(BaseSingleton.GetDriver().FindElement(locator)).Perform();
        }

        public virtual void Wait_UntilIsVisible()
        {
            BaseSingleton.ExplicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(ElementDriver));
        }
        public virtual void Wait_UntilIsVisible(By locator)
        {
            BaseSingleton.ExplicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        public void ImplicitWait()
        {
            BaseSingleton.ImplicitWait();
        }
        public virtual string Text()
        {
            Wait_UntilIsVisible();


            return ElementDriver.GetAttribute("textContent");
        }
        
        public virtual bool IsEnabled()
        {
            Wait_UntilIsVisible();

            return ElementDriver.Enabled;
        }
        

    }
}
