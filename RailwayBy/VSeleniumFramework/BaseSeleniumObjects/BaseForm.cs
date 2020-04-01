using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Reflection;
using VSeleniumFramework.Helpers;

namespace VSeleniumFramework.BaseSeleniumObjects
{
    public abstract class BaseForm
    {
        
        protected string nameType;

        //Element Name
        public string Name { get; set; }
        

        //Element Locator
        
        public virtual By Locator { get; set; }
        

        //FormDriver
     


        

        public BaseForm(string name, By locator) : this(name)
        {
            try
            {
                this.Locator = locator ?? throw new System.NullReferenceException();
            }
            catch (Exception e)
            {
                Logger.Error(nameType, name, MethodBase.GetCurrentMethod().Name, e.GetType().Name);
                throw new Exception(e.Message);
            }
        }

        public BaseForm(string name) : this()
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

        public BaseForm()
        {
            nameType = this.GetType().Name;
        }
        

        protected virtual void Wait_UntilIsVisible()
        {
            BaseSingleton.ExplicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(Locator));
        }

        public virtual void Wait_UntilIsVisible(By locator)
        {
            BaseSingleton.ExplicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
        }

        public void ImplicitWait()
        {
            BaseSingleton.ImplicitWait();
        }


       
        private IWebElement formDriver;
        internal virtual IWebElement FormDriver
        {
            get
            {
                if (formDriver != null)
                    return formDriver;
                else
                    return BaseSingleton.GetDriver().FindElement(Locator);


                throw new ArgumentException("Element driver is not found locator");
            }
            set
            {
                formDriver = value;
            }
        }


        public virtual bool IsOpened()
        {
            Wait_UntilIsVisible();
            return FormDriver.Enabled;
        }


        public List<T> FindElements<T>(By locator) where T : BaseElement, new()
        {
            try
            {
                Wait_UntilIsVisible();

                var Elements = BaseSingleton.GetDriver().FindElements(locator);

                List<T> BaseElements = new List<T>();

                foreach (var Element in Elements)
                {
                    BaseElements.Add(new T()
                    {
                        ElementDriver = Element,
                        Name = Element.GetAttribute("textContent")
                    });

                }
                return BaseElements ?? throw new NullReferenceException("BaseElements not contains elements.");
            }
            catch(NullReferenceException e)
            {
                Logger.Error(nameType, "FindElements<T>", e);
                throw new NullReferenceException(e.Message);
            }
        }


        public List<T> FindForms<T>(By locator) where T : BaseForm, new()
        {
            try
            {
                Wait_UntilIsVisible();

                var Elements = BaseSingleton.GetDriver().FindElements(locator);

                List<T> BaseForms = new List<T>();

                foreach (var Element in Elements)
                {
                    BaseForms.Add(new T()
                    {
                        FormDriver = Element,
                        Name = Element.GetAttribute("textContent")
                    });
                }
                return BaseForms ?? throw new NullReferenceException("BaseElements not contains elements.");
            }
            catch (NullReferenceException e)
            {
                Logger.Error(nameType, "FindElements<T>", e);
                throw new NullReferenceException(e.Message);
            }
        }
    }
}
