**Category:** xConnect

What is the purpose of your module? What problem does it solve and how does it do that?

## Pre-requisites

Below is a list of the dependencies required to integrate xConnect with Google Assistant:

- Sitecore 9.0.1 with xConnect/xDb enabled
- Google Developer Account

## Installation

This installation includes instructions on installing the required changes for xConnect as well as installing the Google Assistant Project in your Google Developer account.

### Sitecore Package Installation

  - Extract xConnect.Service.zip file
  - Install xConnect.Service.1.0.0.zip package

It will add below config files:
>[scWebRoot]\App_Config\Include\Foundation\Foundation.xConnect.config
>[scWebRoot]\App_Config\Include\Foundation\Foundation.xConnect.RegisterContainer.config
>[scWebRoot]\App_Config\Include\Feature\Feature.xConnect.Routes.config

#### xConnect Customizations

Add the following patch to your Sitecore.config file under `[scWebRoot]\App_Config\` and change its value based on your environment.

```xml
<?xml version="1.0"?>
<!--
  Purpose: Configuration settings for my hackathon module
-->
<configuration xmlns:patch="http://www.sitecore.net/xmlconfig/">
  <sitecore>
    <sc.variable name="xconnectHostName" value="sc91.xconnect.local" />
    <sc.variable name="xConnectThumbprint" value="0B707780C8ED51F52BD34C3229C61756A34B921D" />
  </sitecore>
</configuration>
```

Copy `GoogleApiModel, 1.0.json` file and paste it at below locations:

  > [xConnectWebRoot]\App_data\Models\
  > [xConnectWebRoot]\App_data\jobs\continuous\IndexWorker\App_data\Models\

### Google Assistant

In the repository we have included source for the changes required so you can start building your own Google Assistant applications.  Those changes are found here: `

