'use strict';

const http = require('http');
const host = 'http://hackathon.scweb.arrowdesigns.net/';

const $ = require('jquery');

exports.dialogflowFirebaseFulfillment = (request, response) => {
  console.log('Request headers: ' + JSON.stringify(request.headers));
  console.log('Request body: ' + JSON.stringify(request.body));
  
  // Get Parameters
  let location = request.body.result.parameters['ZipCode'];
  let email = request.body.result.parameters['Email'];
  let restaurantType = request.body.result.parameters['restaurant-type'];

  callSitecoreApi(location, email, restaurantType).then((output) => {
    response.setHeader('Content-Type', 'application/json');
    response.send(JSON.stringify({ 'speech': output, 'displayText': output}));
  }).catch((error) => {
    response.setHeader('Content-Type', 'application/json');
    response.send(JSON.stringify({ 'speech': error, 'displayText': error })); 
  });
}

// c. The function that passes data to Sitecore xConnect
function callSitecoreApi(location, email, restaurantType) {
  return new Promise((resolve, reject) => {
    let path = '/xConnect/GoogleInteraction';
    
    $.ajax({
       type: "POST",
       url: host + path,
       data: { location: location, email: email, restaurant_type: restaurantType },
       success: function(data) {
           // We don't return any data back for now
           
       },
       error: function(error) {
           reject(error);
       }
    });
  })
}