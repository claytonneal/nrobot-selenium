﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NRobot.Selenium.Domain;

namespace NRobot.Selenium.Commands.Element
{
    /// <summary>
    /// Command to find and return first visible element for a Locator
    /// </summary>
    internal class GetVisibleElement
    {

        internal IWebElement Execute(CommandParams param)
        {
            var driver = param.Application.GetDriver();
            var elements = driver.FindElements(param.Locator);
            if (elements != null)
            {
                foreach (IWebElement element in elements)
                {
                    if (element.Displayed) return element;
                }
            }
            throw new ElementNotVisibleException("No visible elements matching selector");
        }

    }
}
