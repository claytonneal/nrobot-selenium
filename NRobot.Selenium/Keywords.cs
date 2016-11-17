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
            var command = new SwitchToFrame(browser);
            var param = new CommandParams() { Locator = By.CssSelector(cssSelector) };
            var timeout = browser.CommandTimeout;
            var retry = new RetryCommandInvoker<Object>(command, param, timeout);
            retry.Invoke();
        }

        /// <summary>
        /// Navigates to the specified url
        /// </summary>
        public void Navigate_To_Url(String instance, String url)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new NavigateToURL(browser);
            var param = new CommandParams() { InputData = url };
            var timeout = browser.CommandTimeout;
            var retry = new RetryCommandInvoker<Object>(command, param, timeout);
            retry.Invoke();
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
            var command = new SwitchToDefaultContent(browser);
            var timeout = browser.CommandTimeout;
            var retry = new RetryCommandInvoker<Object>(command, null, timeout);
            retry.Invoke();
        }

        /// <summary>
        /// Gets the url the browser is currently pointing to
        /// </summary>
        public string Get_Current_Url(String instance)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new GetCurrentURL(browser);
            var timeout = browser.CommandTimeout;
            var retry = new RetryCommandInvoker<string>(command, null, timeout);
            string result = retry.Invoke();
            return result;
        }

        /// <summary>
        /// Waits for a popup window to exist, and switches to it
        /// </summary>
	    public void Wait_For_Popup_Window(String instance)
	    {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new WaitForPopupWindow(browser);
            var timeout = browser.CommandTimeout;
            var retry = new RetryCommandInvoker<Object>(command, null, timeout);
            retry.Invoke();
	    }

        /// <summary>
        /// Waits for no popup windows to exist, and switches to the parent window
        /// </summary>
        public void Wait_For_No_PopupWindow(String instance)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var timeout = browser.CommandTimeout;
            var command = new WaitForNoPopupWindow(browser);
            var retry = new RetryCommandInvoker<Object>(command, null, timeout);
            retry.Invoke();
        }




#endregion

#region Element Keywords

		/// <summary>
		/// Clicks on first visible element matching the specified selector
		/// </summary>
		public void Click_On_Element(String instance, String cssSelector)
		{
			var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var click = new ClickElement(browser);
            var param = new CommandParams() { Locator =  By.CssSelector(cssSelector) };
            var timeout = browser.CommandTimeout;
            var retry = new RetryCommandInvoker<Object>(click, param, timeout);
            retry.Invoke();
		}

        /// <summary>
        /// Clicks on first visible element matching the selector and also with matching text value
        /// </summary>
        public void Click_On_Element_With_Text_Value(String instance, String cssSelector, String textValue)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var click = new ClickElementWithTextValue(browser);
            var param = new CommandParams() { Locator = By.CssSelector(cssSelector), InputData = textValue };
            var timeout = browser.CommandTimeout;
            var retry = new RetryCommandInvoker<Object>(click, param, timeout);
            retry.Invoke();
        }

		/// <summary>
		/// Clears the text in an Element (e.g. An input element)
		/// </summary>
		public void Clear_Element_Text(String instance, String cssSelector)
		{
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var clear = new ClearElement(browser);
            var param = new CommandParams() { Locator = By.CssSelector(cssSelector) };
            var timeout = browser.CommandTimeout;
            var retry = new RetryCommandInvoker<Object>(clear, param, timeout);
            retry.Invoke();
		}
		
		/// <summary>
		/// Sets the text in an Element (e.g. An input element)
		/// </summary>
		public void Set_Element_Text(String instance, String cssSelector, String text)
		{
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var settext = new SendKeysToElement(browser);
            var param = new CommandParams() { Locator = By.CssSelector(cssSelector), InputData = text};
            var timeout = browser.CommandTimeout;
            var retry = new RetryCommandInvoker<Object>(settext, param, timeout);
            retry.Invoke();
		}

        /// <summary>
        /// Gets the value of an element attribute
        /// </summary>
        public string Get_Element_Attribute(String instance, String cssSelector, String attributename)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var getattr = new GetElementAttribute(browser);
            var param = new CommandParams() { Locator = By.CssSelector(cssSelector), InputData = attributename };
            var timeout = browser.CommandTimeout;
            var retry = new RetryCommandInvoker<string>(getattr, param, timeout);
            string result = retry.Invoke();
            return result;
        }

        /// <summary>
        /// Sets the text in a Web Element only if there is no text currently there
        /// </summary>
        public void Set_Element_Text_Only_If_Empty(String instance, String cssSelector, String text)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var settext = new SendKeysToEmptyElement(browser);
            var param = new CommandParams() { Locator = By.CssSelector(cssSelector), InputData = text };
            var timeout = browser.CommandTimeout;
            var retry = new RetryCommandInvoker<Object>(settext, param, timeout);
            retry.Invoke();
        }
		
		/// <summary>
		/// Gets the text of a Web Element. Also trims the text to remove leading/trailing spaces
		/// </summary>
		public string Get_Element_Text(String instance, String cssSelector)
		{
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var gettext = new GetElementText(browser);
            var param = new CommandParams() { Locator = By.CssSelector(cssSelector)};
            var timeout = browser.CommandTimeout;
            var retry = new RetryCommandInvoker<string>(gettext, param, timeout);
            var result = retry.Invoke();
            return result;
		}
		
		/// <summary>
		/// Waits until the specified Web Element is visible
		/// </summary>
		public void Wait_Until_Element_Visible(String instance, String cssSelector)
		{
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new WaitUntilElementVisible(browser);
            var param = new CommandParams() { Locator = By.CssSelector(cssSelector) };
            var timeout = browser.CommandTimeout;
            var retry = new RetryCommandInvoker<Object>(command, param, timeout);
            retry.Invoke();
		}

        /// <summary>
        /// Waits until the specified Web Element is not visible
        /// </summary>
        public void Wait_Until_Element_Not_Visible(String instance, String cssSelector)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new WaitUntilElementNotVisible(browser);
            var param = new CommandParams() { Locator = By.CssSelector(cssSelector) };
            var timeout = browser.CommandTimeout;
            var retry = new RetryCommandInvoker<Object>(command, param, timeout);
            retry.Invoke();
        }


        /// <summary>
        /// Selects an item from a drop down list using its text value
        /// </summary>
        public void Select_Item_By_Text(String instance, String cssSelector, String TextValue)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new SelectElementOption(browser);
            var param = new CommandParams() { Locator = By.CssSelector(cssSelector), InputData = TextValue};
            var timeout = browser.CommandTimeout;
            var retry = new RetryCommandInvoker<Object>(command, param, timeout);
            retry.Invoke();
        }

        /// <summary>
        /// Waits until an elements text value contains the specified string, returns the full text of the element
        /// </summary>
        public String Wait_Until_Element_Has_Text(String instance, String cssSelector)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new WaitUntilElementHasText(browser);
            var param = new CommandParams() {Locator = By.CssSelector(cssSelector)};
            var timeout = browser.CommandTimeout;
            var retry = new RetryCommandInvoker<string>(command, param, timeout);
            string result = retry.Invoke();
            return result;
        }

        /// <summary>
        /// Counts the number of visible elements matching the css selector
        /// </summary>
        public String Count_Visible_Elements(String instance, String cssSelector)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new CountVisibleElements(browser);
            var param = new CommandParams() { Locator = By.CssSelector(cssSelector) };
            var timeout = browser.CommandTimeout;
            var retry = new RetryCommandInvoker<string>(command, param, timeout);
            string result = retry.Invoke();
            return result;
        }

        /// <summary>
        /// Waits until the text value of the element can be converted to a number with the specified value
        /// </summary>
        public void Wait_Until_Element_Has_Numeric_Value(String instance, String cssSelector, String expectedvalue)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new WaitUntilElementHasNumericValue(browser);
            String expected = Double.Parse(expectedvalue).ToString();
            var param = new CommandParams() { Locator = By.CssSelector(cssSelector), InputData = expected};
            var timeout = browser.CommandTimeout;
            var retry = new RetryCommandInvoker<Object>(command, param, timeout);
            retry.Invoke();
        }

        /// <summary>
        /// Performs mouse hover for the specific element
        /// </summary>
        public void Hover_Over_Element(String instance, String cssSelector)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new HoverOverElement(browser);
            var param = new CommandParams() { Locator = By.CssSelector(cssSelector) };
            var timeout = browser.CommandTimeout;
            var retry = new RetryCommandInvoker<Object>(command, param, timeout);
            retry.Invoke();
        }

        /// <summary>
        /// Performs mouse hover for first element matching the css selector, and with matching text value
        /// </summary>
        public void Hover_Over_Element_With_Value(String instance, String cssSelector, String textValue)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new HoverOverElementWithValue(browser);
            var param = new CommandParams() { Locator = By.CssSelector(cssSelector), InputData = textValue };
            var timeout = browser.CommandTimeout;
            var retry = new RetryCommandInvoker<Object>(command, param, timeout);
            retry.Invoke();
        }

        /// <summary>
        /// Gets the text from ALL visible elements found with the cssSelector.
        /// This will return a List of strings
        /// </summary>
	    public string[] Get_Text_Of_All_Elements(String instance, String cssSelector)
	    {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new GetAllElementsText(browser);
            var param = new CommandParams() { Locator = By.CssSelector(cssSelector) };
            var timeout = browser.CommandTimeout;
            var retry = new RetryCommandInvoker<string[]>(command, param, timeout);
            string[] result = retry.Invoke();
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
            var command = new CheckElementHasClass(browser);
            var param = new CommandParams() { Locator = By.CssSelector(cssSelector), InputData = cssClass };
            var timeout = browser.CommandTimeout;
            var retry = new RetryCommandInvoker<Boolean>(command, param, timeout);
            Boolean result = retry.Invoke();
            return result;
        }

        /// <summary>
        /// Waits until an element has a specified css class
        /// </summary>
        public void Wait_Until_Element_Has_CssClass(string instance, string cssSelector, string cssClass)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new WaitUntilElementHasClass(browser);
            var param = new CommandParams() { Locator = By.CssSelector(cssSelector), InputData = cssClass };
            var timeout = browser.CommandTimeout;
            var retry = new RetryCommandInvoker<Object>(command, param, timeout);
            retry.Invoke();
        }

        /// <summary>
        /// Repeatidely clicks on an element until either it gets the specified css class or a timeout happens
        /// </summary>
        public void Click_Until_Element_Has_CssClass(string instance, string cssSelector, string cssClass)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new ClickElementUntilHasClass(browser);
            var param = new CommandParams() { Locator = By.CssSelector(cssSelector), InputData = cssClass };
            var timeout = browser.CommandTimeout;
            var retry = new RetryCommandInvoker<Object>(command, param, timeout);
            retry.Invoke();
        }

        /// <summary>
        /// Repeatidely clicks on an element until another element is visible or a timeout
        /// </summary>
        public void Click_Until_Another_Element_Visible(string instance, string cssElementToClickOn, string cssElementToCheckFor)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new ClickElementUntilAnotherElementDisplayed(browser);
            var param = new CommandParams() { Locator = By.CssSelector(cssElementToClickOn), InputData = cssElementToCheckFor };
            var timeout = browser.CommandTimeout;
            var retry = new RetryCommandInvoker<Object>(command, param, timeout);
            retry.Invoke();
        }

#endregion

#region Screenshot

        /// <summary>
        /// Takes a screenshot from the browser and saves the image in specified path
        /// </summary>
        public void Take_ScreenShot(String instance, String filepath)
        {
            var browser = BrowserManager.Instance.getBrowserInstance(instance);
            var command = new TakeScreenShot(browser);
            var param = new CommandParams() { InputData = filepath };
            var timeout = browser.CommandTimeout;
            var retry = new RetryCommandInvoker<Object>(command, param, timeout);
            retry.Invoke();
        }

#endregion


    }
}