![Hackathon Logo](documentation/images/hackathon.png?raw=true "Hackathon Logo")

# Sitecore xConnect Google Assistant Integration

We are team Debug Starts Here.  Our team consists of the following members:

- Dylan Young
- Bhavesh Maniya
- Nisha Magnani

This is our submission for the 2018 Hackathon in the `xConnect` category.

## Quick Links

1. [Installation Steps](/documentation/Readme.md)
2. YouTube Video
3. [Bot Demo Page](https://bot.dialogflow.com/823e37ff-493e-4757-ad82-d59916e99e55)

## Purpose

The purpose of this xConnect integration, is to pass data collection

## Use Case

Our module was developed with the use case of an organization that is in the business of taking food orders typically via it's website (such as GrubHub or Delivery Dudes).  This application extends that functionality, allowing for new channels to take a customers order automatically, but still bringing that transaction data back into Sitecore for personalization purposes.

## Google Assistant Customizations

Currently our application can be controlled by any device that is a controlled by Google Assistant, which include both voice and textual applications.  A short list of chat devices that will work with our application are included below:

 - Google Assistance on any Android Phones or Tablets
 - Facebook Messenger

## Future Enhancements

Eventually we would like there to be a way that you could customize the google assistant bot, and those changes would automatically flow into xConnect so that data can be personalized.

The Hackathon site can be found at http://www.sitecorehackathon.org/sitecore-hackathon-2018/

This purpose of repository is to provide a sample which shows how to structure the Hackathon submissions. We highly recommend

More integrations with other 3rd party chat/home automation applications via the Google Assistant service.

## Sitecore Package Installation

- Extract xConnect.Service.zip file
- Install xConnect.Servoce.1.0.0.zip package
  - It will add below config files:
    - [scWebRoot]\App_Config\Include\Foundation\Foundation.xConnect.config
    - [scWebRoot]\App_Config\Include\Foundation\Foundation.xConnect.RegisterContainer.config
    - [scWebRoot]\App_Config\Include\Feature\Feature.xConnect.Routes.config
  - Add below two variables in Sitecore.config file under [scWebRoot]\App_Config\ and change its value based on your environment.
    - <sc.variable name="xconnectHostName" value="sc91.xconnect.local" />
    - <sc.variable name="xConnectThumbprint" value="0B707780C8ED51F52BD34C3229C61756A34B921D" />
  - Copy GoogleApiModel, 1.0.json file and paste it at below locations:
    - [xConnectWebRoot]\App_data\Models\
    - [xConnectWebRoot]\ App_data\jobs\continuous\IndexWorker\App_data\Models\


## Entry Submission Requirements 

All teams are required to submit the following as part of their entry submission on or before the end of the Hackathon on **Saturday March 3rd 2018 at 8PM EST**. The modules should be based on [Sitecore 9.0 rev. 171219 (Update-1)](https://dev.sitecore.net/Downloads/Sitecore_Experience_Platform/90/Sitecore_Experience_Platform_90_Update1.aspx).

**Failure to meet any of the requirements will result in automatic disqualification.** Please reach out to any of the organisers or judges if you require any clarification.

- Sitecore 9.0 Update 1 Module (Module install package)
   - An installation Sitecore Package (`.zip` or `.update`)

- Module code in a public Git source repository. We will be judging (amongst other things):
  - Cleanliness of code
  - Commenting where necessary
  - Code Structure
  - Standard coding standards & naming conventions

- Precise and Clear Installation Instructions document (1 – 2 pages)
- Module usage documentation on [Readme.md](documentation) file on the Git Repository (2 – 5 pages)
  - Module Purpose
  - Module Sitecore Hackathon Category
  - How does the end user use the Module?
  - Screenshots, etc.

- Create a 2 – 10 minutes video explaining the module’s functionality (A link to youtube video)

  - What problem was solved
  - How did you solve it
  - What is the end result
