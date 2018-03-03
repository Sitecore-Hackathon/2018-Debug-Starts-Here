![Hackathon Logo](documentation/images/hackathon.png?raw=true "Hackathon Logo")

# Sitecore xConnect Google Assistant Integration

We are team `Debug Starts Here`.  Our team consists of the following members:

- Dylan Young (USA)
- Bhavesh Maniya (India)
- Nisha Magnani (India)

This is our submission for the 2018 Hackathon in the `xConnect` category.

## Quick Links

1. [Installation Steps](https://github.com/Sitecore-Hackathon/2018-Debug-Starts-Here/tree/master/documentation/Readme.md)
2. YouTube Video
3. [Bot Demo Page](https://bot.dialogflow.com/823e37ff-493e-4757-ad82-d59916e99e55)

## Purpose

The purpose of this xConnect integration, is to pass data collected from the use of a Google Assistant integration, back to xDb via xConnect for customer engagments.  Ideally the Google Assistant implementation could be extended to support more advanced functionality, such as Payment Processing, that would send interaction data back to xDb via xConnect.

## Use Case

Our module was developed with the use case of an organization that is in the business of taking food orders typically via it's website (such as GrubHub or Delivery Dudes).  This application extends that functionality, allowing for new channels to take a customers order automatically, but still bringing that transaction data back into Sitecore for personalization.  We created custom facets that the user has filled in, from the Google Assistant.  When a user goes onto their phone, and says `Start Sitecore Hackathon` that triggers a action within Google Assistant to trigger our application.

The application can use text or natural language to ask the user a series of questions.  We have also turned on the `small talk` integration, so the Google Assistant will respond to friendly conversation.  When the user asks

## Google Assistant Customizations

Currently our application can be controlled by any device that is a controlled by Google Assistant, which include both voice and textual applications.  A short list of chat devices that will work with our application are included below:

 - Google Assistance on any Android Phones or Tablets
 - Facebook Messenger

### Intent Customizations

There is also the ability to extend this further with more devices.  We built the language processor with the use of `DialogFlow` with our Google Developer Account.  We create a custom agent and then defined multiple `Intents`.  To further extend the Google Assistant, more `Intents` could be added to the application. 

![Managing Intents in DialogFlow](https://i.imgur.com/Lcdy8GP.png)

### Import Current Project

To customize the current setup, you can pull the source from `[scWebRoot]\google-bot\src`.  If you package that source up in a zip, and then create a new agent in your Google Assistant part of the Google Developer console, you can import this `.zip` file.

![Import Agent](https://i.imgur.com/olb5xiL.png)

## Future Enhancements

This Google Assistant application to xConnect opens a lot of possibilities to interact with a customer in a natural way, while still collecting information about the user which can ultimately be brought back into Sitecore for personalization engagement purposes.

- Customer Support Feature Rich Application to help customers solve their problems, but to also bring that data back into xDb for customer engagment purposes.
- The use of the Marketing Automation Suite in Sitecore 9, to trigger interactions with the client based on events triggered on the website.
