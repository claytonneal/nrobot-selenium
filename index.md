# NRobot Selenium

.Net Robot Framework keyword library for Selenium

## Purpose

There is already a Selenium keyword library for Robot Framework, but that library is written in Python. Therefore if your a .Net test automation engineer, you may have reservations on using a Python library that you cannot contribute to or fix bugs in. Therefore NRobot-Selenium could be for you!

## Getting Started

### Installation

To install and get started with NRobot-Selenium:

* Ensure .Net Framework version 4.6.1 installed
* Install NRobot-Server from <https://github.com/claytonneal/nrobot-server>
* Install the Chrome, Gecko, Edge etc. drivers from Selenium and add their location to your PATH variable


### Configuring NRobot-Server

NRobot-Server needs configuring to load the NRobot-Selenium keywords and xml documentation file

* Open the file *NRobot.Server.exe.config* in notepad
* Replace the section with below:

```
<NRobotServerConfiguration>
	<port number="8270"/>
		<assemblies>
			<add name="NRobot.Selenium" type="NRobot.Selenium.Keywords" docfile="NRobot.Selenium.xml"/>
	</assemblies>
</NRobotServerConfiguration>
```

* Save the file

### Starting NRobot-Server

* Launch *NRobot.Server.exe*
* Once launched, right click on the desktop tray icon and select menu item *Keywords*

You should now see that the NRobot-Selenium keywords have been loaded, and your now ready to start writing selenium test cases!

## Using NRobot Selenium

The best way to learn is with an example, so lets dive in!

### Acme Film Example

In this example we are going to create a Robot Framework test case that will:

* Open the Acme File web page <http://grid-tools-downloads.com/testpages/form2.html> in Chrome
* Enter a new users registration details
* Click Submit to submit the user registration
* Check that the registration page is displayed

This example is supplied in the Examples folder.

#### Step 1 - Create Per Page Resource Files

In Robot Framework we can simulate the Page Object Model of Selenium by encapsulating each page of the web application as a robot framework resource file. Each resource file contains:

* Variables that hold the CSS locators of the elements of interest on the page
* Robot Framework keywords that interact with that page by calling NRobot-Selenium keywords

In the Acme File web application there are two pages, the *Register* page and the *Register Success* page.

Lets have a closer look at the *RegisterPage* resource file. Firstly we give the file some documentation, and also import all the NRobot-Selenium keywords:

```
*** Settings ***
Documentation     Resource file that represents the register page
Library           Remote    http://localhost:8270/NRobot/Selenium/Keywords    WITH NAME    SELENIUM
```

Here the *Library* keyword has connected to NRobot-Server and imported the NRobot-Selenium keywords so they are available in the resource file. We have imported the keywords into Robot Framework with name prefix of *SELENIUM*.
 
Next the resource file holds the CSS selectors for the different elements on the page, for example the *FirstName* element

```
*** Variables ***
${FIRST-NAME-TEXTBOX}    input#Name
```

These locators can be found for example using *FireBug* in Firefox browser.


Finally for each element on the page, a user defined keyword is added to interact with that element, for example to fill the *FirstName* field:

```
*** Keywords ***
Enter First Name
    [Arguments]    ${NAME}
    SELENIUM.SET ELEMENT TEXT    ${BROWSERID}    ${FIRST-NAME-TEXTBOX}    ${NAME}
```

Here a user defined keyword called *Enter First Name* takes a ```${NAME}``` parameter and then called the NRobot-Selenium keyword called *SET ELEMENT TEXT* and supplies to that keyword:

* The id of the currently opened browser ```${BROWSERID}``` we will see how this is created later on
* The CSS selector of the element to use, in this case we can use the ```${FIRST-NAME-TEXTBOX}``` variable we created before
* The value to set in the text box, the keywords ```${NAME}``` input parameter

We can then repeat this exercise for all elements in the *RegisterPage* to complete this resource file.


### Step 2 - Create a Common Resource File

The *Common* resource file can be used to hold:

* Overall global settings for the entire test suite
* Robot Variable keywords that can be used globally (like helper functions!)
* Setup/Teardown keywords that will use NRobot-Selenium to open and close the browser

The last point here is of interest. It is *best practice* that each test case will have a Setup and a Tear down that will open and close the browser. This way each test case get a fresh clean browser to work with.

We can place now the homepage url of Acme Film inside the common resource file:

```
*** Variables ***
${HOMEPAGE}       http://grid-tools-downloads.com/testpages/form2.html
```

Having a variable hold the application under test homepage is good practice, as you can easily then point the test cases to a different URL (for example a different test environment).

Now lets have a look at the *SetupBrowser* keyword that we will use to open a browser:

```
*** Keywords ***
SetupBrowser
    [Documentation]    Opens Firefox to the homepage and sets variable BROWSERID
    # Open the browser
    Set Test Variable    ${ISBROWSEROPEN}    ${false}
    ${INSTANCE}=    SELENIUM.OPEN BROWSER    Chrome    DESKTOP    Local    ${HOMEPAGE}
    Set Test Variable    ${ISBROWSEROPEN}    ${true}
    Set Test Variable    ${BROWSERID}    ${INSTANCE}
    # Set the timeouts
    SELENIUM.SET COMMAND TIMEOUT    ${INSTANCE}    10
    SELENIUM.SET PAGELOAD TIMEOUT    ${INSTANCE}    10
```

What this user defined keyword does is:

* Sets test case level variable ```${ISBROWSEROPEN}``` initially to *False*
* Calls the NRobot-Selenium keyword called *Open Browser* and specifies that:
	* The browser type is *Chrome*
	* The browser is to be resized to *Desktop* size
	* The browser location is *Local* (as apposed to Remote selenium grid)
	* The URL to point the browser to is our previously defined ```${HOMEPAGE}```
* The test case level variabke ```${ISBROWSEROPEN}`` is now set to *True*
* The test case level variable ```${BROWSERID}``` is set to the id of the browser returned by NRobot-Selenium. This id is then used in each NRobot-Selenium command to interact with that browser instance.
* The *Command* and *PageLoad* timeouts are set in NRobot-Selenium to 10 seconds

And finally lets take a look at the *CloseBrowser* keyword that is used to close a browser:

```
CloseBrowser
    [Documentation]    Closes the browser instance created in SetupBrowser
    Run Keyword If    ${ISBROWSEROPEN}    SELENIUM.CLOSEBROWSER    ${BROWSERID}
```

### Step 3 - Create the Test Case

Now we have all in place to build the test case. So lets take a look at it:

We firstly import our resource files:

```
*** Settings ***
Resource          RegisterPage.txt
Resource          RegisterSuccessPage.txt
Resource          CommonResources.txt
```

And now the whole test is:

```
*** Test Cases ***
Register New User
    [Setup]    CommonResources.SetupBrowser
    # Enter user details
    RegisterPage.Enter First Name    Bob
    RegisterPage.Enter Last Name    Smith
    RegisterPage.Select Title    Mr
    RegisterPage.Enter Age    30
    RegisterPage.Enter Email Address    bob@smith.com
    RegisterPage.Enter Confirmation Email Address    bob@smith.com
    RegisterPage.Enter Password    Password123
    RegisterPage.Enter Confirmation Password    Password123
    RegisterPage.Enter Mobile Number    12345678901
    RegisterPage.Enter Home Number    12345678901
    RegisterPage.Enter Address Line 1    The Gallops
    RegisterPage.Enter Address Line 2    Middle Street
    RegisterPage.Enter City    Northern Town
    RegisterPage.Select Country    UK
    RegisterPage.Select How Find Us    Search engine
    RegisterPage.Click Receive Future Offers
    RegisterPage.Click on Terms and Conditions
    # Click on Submit
    RegisterPage.Click on Submit
    # Check on success page
    RegisterSuccessPage.Check on Page
    # Check registration message
    ${MESSAGE}=    RegisterSuccessPage.Get Registration Message
    Should Contain    ${MESSAGE}    You have successfully registered for ACME Film
    [Teardown]    CommonResources.CloseBrowser
```

What the test does is:

* It sets the the keyword *SetupBrowser* defined earlier to be the Setup of the test case
* It then uses the *RegisterPage* resource file keywords to enter the new user details
* It submits the new user form
* It then uses keyword *Check on Page* from the *RegisterSuccessPage* resource file to check the success page is displayed
* It then gets the message from the register success page
* It then checks the success message contains the correct text
* Finally it then sets the *CloseBrowser* keyword as its teardown

## Available Keywords

The list of available keywords in NRobot-Selenium can be viewed in several places:

* View the file *NRobot-Selenium-Keywords.html* in the GitHub repository
* When loaded into NRobot-Server available keywords can be viewed by right clicking on the NRobot-Server desktop tray icon and selecting option *Keywords*
* If using RIDE once the keywords are imported via a ```LIBRARY``` command the available keywords can be viewed in the RIDE user interface


## Configuring NRobot Selenium

NRobot-Selenium is configured via file *NRobot.Selenium.Config.yaml*
The configuration settings are:

Setting Name  | Description
------------- | -------------
huburl  | When using selenium grid (BrowserLocation = Remote), the URL of the selenium grid hub
browsername  | If no browser name supplied to Open Browser keyword the default to use
browsersize | If no browser size supplied to Open Browser keyword the default to use
browserlocation | If no browser location supplied to Open Browser keyword the default to use
commandtimeout | The timeout in seconds for each browser interaction command
pageloadtimeout | The timeout in seconds passed to selenium for page load timeout
scripttimeout | The timeout in seconds passed to selenium fro script timeout
openretrycount | The number of times keyword Open Browser will retry to open a browser before raising an error
openretrydelay | The delay in seconds the keyword Open Browser will use between each open browser attempt 

## Upgrading Selenium Version

NRobot-Selenium by default uses Selenium v3, however it is can be upgraded/downgraded by changing the nuget packages referenced by the visual studio project, and recompiling the project.

## Contributing

All defects, enhancements are welcome and can be logged on GitHub. All code contributions are also welcome.
