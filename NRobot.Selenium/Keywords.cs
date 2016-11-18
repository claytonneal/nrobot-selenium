using System;
using OpenQA.Selenium;
using NRobot.Selenium.Domain;
using NRobot.Selenium.Commands;
using NRobot.Selenium.Commands.Element;
using NRobot.Selenium.Commands.Browser;

namespace NRobot.Selenium
{
	/// <summary>
	/// Keywords exposed to robot framework
	/// </summary>
	public class Keywords
	{
		
#region Browser Keywords

        /// <summary>
        /// Switches the context of element interactions into the located iframe
        /// </summary>
        public void Switch_Context_To_IFrame(String instance, String cssSelector)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new SwitchToFrame();
            var param = new CommandParams() { Application = browser, Locator = By.CssSelector(cssSelector) };
            var timeout = browser.CommandTimeout;
            RetryCommandInvoker.Invoke<Boolean>(command.Execute, param, timeout);
        }

        /// <summary>
        /// Navigates to the specified url
        /// </summary>
        public void Navigate_To_Url(String instance, String url)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new NavigateToURL();
            var param = new CommandParams() { Application = browser, InputData = url };
            var timeout = browser.CommandTimeout;
            RetryCommandInvoker.Invoke<Boolean>(command.Execute, param, timeout);
        }

		/// <summary>
		/// Sets the timeout for commands performed on the browser (seconds)
		/// </summary>
		public void Set_Command_TimeOut(String instance, string seconds)
		{
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            browser.SetCommandTimeout(Int32.Parse(seconds));
		}
		
		/// <summary>
		/// Sets the timeout for browser to load a page (seconds)
		/// </summary>
		public void Set_PageLoad_TimeOut(String instance, string seconds)
		{
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            browser.SetPageLoadTimeout(Int32.Parse(seconds));
		}
		
		/// <summary>
		/// Sets the timeout for browser execute scripts (seconds)
		/// </summary>
		public void Set_Script_TimeOut(string instance, string seconds)
		{
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            browser.SetScriptTimeout(Int32.Parse(seconds));
		}
		
		/// <summary>
		/// Opens the specified browser type, to specified size, and location and to specified url.
        /// Returns the identifier of the browser instance
		/// </summary>
		public string Open_Browser(string browsertype, string browsersize, string location, string url)
		{
            var config = BrowserConfigLoader.getConfig();
            config.browsername = (BrowserNames)Enum.Parse(typeof(BrowserNames), browsertype);
            config.browsersize = (BrowserSize)Enum.Parse(typeof(BrowserSize), browsersize);
            config.browserlocation = (BrowserLocations)Enum.Parse(typeof(BrowserLocations), location);
            config.url = url;
            var browser = new BrowserApp(config);
            return browser.Identifier;
		}
		
		/// <summary>
		/// Closes the browser instance
		/// </summary>
		public void Close_Browser(string instance)
		{
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            browser.CloseBrowser();
		}

        /// <summary>
        /// Returns TRUE if the browser is currently open
        /// </summary>
        public Boolean Is_Browser_Open(String instance)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            return (browser.Status == BrowserStatuses.Open);
        }

        /// <summary>
        /// Switches the context of element interaction back to the default (main page)
        /// </summary>
        public void Switch_To_Default_Content(String instance)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new SwitchToDefaultContent();
            var param = new CommandParams() { Application = browser };
            var timeout = browser.CommandTimeout;
            RetryCommandInvoker.Invoke<Boolean>(command.Execute, param, timeout);
        }

        /// <summary>
        /// Gets the url the browser is currently pointing to
        /// </summary>
        public string Get_Current_Url(String instance)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new GetCurrentURL();
            var timeout = browser.CommandTimeout;
            var param = new CommandParams() { Application = browser };
            string result = RetryCommandInvoker.Invoke<string>(command.Execute, param, timeout);
            return result;
        }

        /// <summary>
        /// Waits for a popup window to exist, and switches to it
        /// </summary>
	    public void Wait_For_Popup_Window(String instance)
	    {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new WaitForPopupWindow();
            var timeout = browser.CommandTimeout;
            var param = new CommandParams() { Application = browser };
            RetryCommandInvoker.Invoke<Boolean>(command.Execute, param, timeout);
	    }

        /// <summary>
        /// Waits for no popup windows to exist, and switches to the parent window
        /// </summary>
        public void Wait_For_No_PopupWindow(String instance)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var timeout = browser.CommandTimeout;
            var command = new WaitForNoPopupWindow();
            var param = new CommandParams() { Application = browser };
            RetryCommandInvoker.Invoke<Boolean>(command.Execute, param, timeout);
        }




#endregion

#region Element Keywords

		/// <summary>
		/// Clicks on first visible element matching the specified selector
		/// </summary>
		public void Click_On_Element(String instance, String cssSelector)
		{
			var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new ClickElement();
            var param = new CommandParams() { Application = browser, Locator =  By.CssSelector(cssSelector) };
            var timeout = browser.CommandTimeout;
            RetryCommandInvoker.Invoke<Boolean>(command.Execute, param, timeout);
		}

        /// <summary>
        /// Clicks on first visible element matching the selector and also with matching text value
        /// </summary>
        public void Click_On_Element_With_Text_Value(String instance, String cssSelector, String textValue)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new ClickElementWithTextValue();
            var param = new CommandParams() { Application = browser, Locator = By.CssSelector(cssSelector), InputData = textValue };
            var timeout = browser.CommandTimeout;
            RetryCommandInvoker.Invoke<Boolean>(command.Execute, param, timeout);
        }

		/// <summary>
		/// Clears the text in an Element (e.g. An input element)
		/// </summary>
		public void Clear_Element_Text(String instance, String cssSelector)
		{
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new ClearElement();
            var param = new CommandParams() { Application = browser, Locator = By.CssSelector(cssSelector) };
            var timeout = browser.CommandTimeout;
            RetryCommandInvoker.Invoke<Boolean>(command.Execute, param, timeout);
		}
		
		/// <summary>
		/// Sets the text in an Element (e.g. An input element)
		/// </summary>
		public void Set_Element_Text(String instance, String cssSelector, String text)
		{
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new SendKeysToElement();
            var param = new CommandParams() { Application = browser, Locator = By.CssSelector(cssSelector), InputData = text};
            var timeout = browser.CommandTimeout;
            RetryCommandInvoker.Invoke<Boolean>(command.Execute, param, timeout);
		}

        /// <summary>
        /// Gets the value of an element attribute
        /// </summary>
        public string Get_Element_Attribute(String instance, String cssSelector, String attributename)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new GetElementAttribute();
            var param = new CommandParams() { Application = browser, Locator = By.CssSelector(cssSelector), InputData = attributename };
            var timeout = browser.CommandTimeout;
            string result =  RetryCommandInvoker.Invoke<string>(command.Execute, param, timeout);
            return result;
        }

        /// <summary>
        /// Sets the text in a Web Element only if there is no text currently there
        /// </summary>
        public void Set_Element_Text_Only_If_Empty(String instance, String cssSelector, String text)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new SendKeysToEmptyElement();
            var param = new CommandParams() { Application = browser, Locator = By.CssSelector(cssSelector), InputData = text };
            var timeout = browser.CommandTimeout;
            RetryCommandInvoker.Invoke<Boolean>(command.Execute, param, timeout);
        }
		
		/// <summary>
		/// Gets the text of a Web Element. Also trims the text to remove leading/trailing spaces
		/// </summary>
		public string Get_Element_Text(String instance, String cssSelector)
		{
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new GetElementText();
            var param = new CommandParams() { Application = browser, Locator = By.CssSelector(cssSelector)};
            var timeout = browser.CommandTimeout;
            string result = RetryCommandInvoker.Invoke<string>(command.Execute, param, timeout);
            return result;
		}
		
		/// <summary>
		/// Waits until the specified Web Element is visible
		/// </summary>
		public void Wait_Until_Element_Visible(String instance, String cssSelector)
		{
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new WaitUntilElementVisible();
            var param = new CommandParams() { Application = browser, Locator = By.CssSelector(cssSelector) };
            var timeout = browser.CommandTimeout;
            RetryCommandInvoker.Invoke<Boolean>(command.Execute, param, timeout);
		}

        /// <summary>
        /// Waits until the specified Web Element is not visible
        /// </summary>
        public void Wait_Until_Element_Not_Visible(String instance, String cssSelector)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new WaitUntilElementNotVisible();
            var param = new CommandParams() { Application = browser, Locator = By.CssSelector(cssSelector) };
            var timeout = browser.CommandTimeout;
            RetryCommandInvoker.Invoke<Boolean>(command.Execute, param, timeout);
        }


        /// <summary>
        /// Selects an item from a drop down list using its text value
        /// </summary>
        public void Select_Item_By_Text(String instance, String cssSelector, String TextValue)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new SelectElementOption();
            var param = new CommandParams() { Application = browser, Locator = By.CssSelector(cssSelector), InputData = TextValue};
            var timeout = browser.CommandTimeout;
            RetryCommandInvoker.Invoke<Boolean>(command.Execute, param, timeout);
        }

        /// <summary>
        /// Waits until an elements text value contains the specified string, returns the full text of the element
        /// </summary>
        public String Wait_Until_Element_Has_Text(String instance, String cssSelector)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new WaitUntilElementHasText();
            var param = new CommandParams() { Application = browser, Locator = By.CssSelector(cssSelector)};
            var timeout = browser.CommandTimeout;
            string result = RetryCommandInvoker.Invoke<String>(command.Execute, param, timeout);
            return result;
        }

        /// <summary>
        /// Counts the number of visible elements matching the css selector
        /// </summary>
        public String Count_Visible_Elements(String instance, String cssSelector)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new CountVisibleElements();
            var param = new CommandParams() { Application = browser, Locator = By.CssSelector(cssSelector) };
            var timeout = browser.CommandTimeout;
            string result = RetryCommandInvoker.Invoke<string>(command.Execute, param, timeout);
            return result;
        }

        /// <summary>
        /// Waits until the text value of the element can be converted to a number with the specified value
        /// </summary>
        public void Wait_Until_Element_Has_Numeric_Value(String instance, String cssSelector, String expectedvalue)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new WaitUntilElementHasNumericValue();
            String expected = Double.Parse(expectedvalue).ToString();
            var param = new CommandParams() { Application = browser, Locator = By.CssSelector(cssSelector), InputData = expected};
            var timeout = browser.CommandTimeout;
            RetryCommandInvoker.Invoke<Boolean>(command.Execute, param, timeout);
        }

        /// <summary>
        /// Performs mouse hover for the specific element
        /// </summary>
        public void Hover_Over_Element(String instance, String cssSelector)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new HoverOverElement();
            var param = new CommandParams() { Application = browser, Locator = By.CssSelector(cssSelector) };
            var timeout = browser.CommandTimeout;
            RetryCommandInvoker.Invoke<Boolean>(command.Execute, param, timeout);
        }

        /// <summary>
        /// Performs mouse hover for first element matching the css selector, and with matching text value
        /// </summary>
        public void Hover_Over_Element_With_Value(String instance, String cssSelector, String textValue)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new HoverOverElementWithValue();
            var param = new CommandParams() { Application = browser, Locator = By.CssSelector(cssSelector), InputData = textValue };
            var timeout = browser.CommandTimeout;
            RetryCommandInvoker.Invoke<Boolean>(command.Execute, param, timeout);
        }

        /// <summary>
        /// Gets the text from ALL visible elements found with the cssSelector.
        /// This will return a List of strings
        /// </summary>
	    public string[] Get_Text_Of_All_Elements(String instance, String cssSelector)
	    {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new GetAllElementsText();
            var param = new CommandParams() { Application = browser, Locator = By.CssSelector(cssSelector) };
            var timeout = browser.CommandTimeout;
            string[] result = RetryCommandInvoker.Invoke<string[]>(command.Execute, param, timeout);
	        return result;
	    }

        /// <summary>
        /// Checks if the element has a specified CSS class. 
        /// Returns True/False. This is a spot check, no waits are involved.
        /// To wait for an element to have a css class see WAIT_UNTIL_ELEMENT_HAS_CSSCLASS
        /// </summary>
        public Boolean Does_Element_Have_CssClass(string instance, String cssSelector, String cssClass)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new CheckElementHasClass();
            var param = new CommandParams() { Application = browser, Locator = By.CssSelector(cssSelector), InputData = cssClass };
            var timeout = browser.CommandTimeout;
            bool result = RetryCommandInvoker.Invoke<Boolean>(command.Execute, param, timeout);
            return result;
        }

        /// <summary>
        /// Waits until an element has a specified css class
        /// </summary>
        public void Wait_Until_Element_Has_CssClass(string instance, string cssSelector, string cssClass)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new WaitUntilElementHasClass();
            var param = new CommandParams() { Application = browser, Locator = By.CssSelector(cssSelector), InputData = cssClass };
            var timeout = browser.CommandTimeout;
            RetryCommandInvoker.Invoke<Boolean>(command.Execute, param, timeout);
        }

        /// <summary>
        /// Repeatidely clicks on an element until either it gets the specified css class or a timeout happens
        /// </summary>
        public void Click_Until_Element_Has_CssClass(string instance, string cssSelector, string cssClass)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new ClickElementUntilHasClass();
            var param = new CommandParams() { Application = browser, Locator = By.CssSelector(cssSelector), InputData = cssClass };
            var timeout = browser.CommandTimeout;
            RetryCommandInvoker.Invoke<Boolean>(command.Execute, param, timeout);
        }

        /// <summary>
        /// Repeatidely clicks on an element until another element is visible or a timeout
        /// </summary>
        public void Click_Until_Another_Element_Visible(string instance, string cssElementToClickOn, string cssElementToCheckFor)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new ClickElementUntilAnotherElementDisplayed();
            var param = new CommandParams() { Application = browser, Locator = By.CssSelector(cssElementToClickOn), InputData = cssElementToCheckFor };
            var timeout = browser.CommandTimeout;
            RetryCommandInvoker.Invoke<Boolean>(command.Execute, param, timeout);
        }

#endregion

#region Screenshot

        /// <summary>
        /// Takes a screenshot from the browser and saves the image in specified path
        /// </summary>
        public void Take_ScreenShot(String instance, String filepath)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new TakeScreenShot();
            var param = new CommandParams() { Application = browser, InputData = filepath };
            var timeout = browser.CommandTimeout;
            RetryCommandInvoker.Invoke<Boolean>(command.Execute, param, timeout);
        }

#endregion


    }
}