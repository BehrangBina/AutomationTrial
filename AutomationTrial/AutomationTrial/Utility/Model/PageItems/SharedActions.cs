using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationTrial.Utility.Model.PageItems
{
    public static class SharedActions
    {
        public static  void Click(IWebElement element)
        {
            element.Click();
        }

        public static void SendKey( this IWebElement element, string key)
        {
            element.SendKeys(key);
        }
        //Select DropDown By Value
        public static void  SelectDropDownByValue(IWebElement element, string value)
        {
           new SelectElement(element).SelectByValue(value);
        }
    }
}
