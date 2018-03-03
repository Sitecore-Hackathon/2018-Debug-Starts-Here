'use strict';

process.env.DEBUG = 'actions-on-google:*';
const http = require('http');
const App = require('actions-on-google').DialogflowApp;
const functions = require('firebase-functions');
const host = 'http://hackathon.scweb.arrowdesigns.net/';

exports.sitecore = functions.https.onRequest((request, response) => {
  const app = new App({request, response});
  console.log('Request headers: ' + JSON.stringify(request.headers));
  console.log('Request body: ' + JSON.stringify(request.body));
  
  // Get Parameters
  let location = request.body.result.parameters['ZipCode'];
  let email = request.body.result.parameters['Email'];
  let restaurantType = request.body.result.parameters['restaurant-type'];

  callSitecoreApi(app).then((output) => {
    response.setHeader('Content-Type', 'application/json');
    response.send(JSON.stringify({ 'speech': output, 'displayText': output}));
  }).catch((error) => {
    response.setHeader('Content-Type', 'application/json');
    response.send(JSON.stringify({ 'speech': error, 'displayText': error })); 
  });
});

// c. The function that passes data to Sitecore xConnect
function callSitecoreApi(app) {
  return new Promise((resolve, reject) => {
    let path = '/xConnect/GoogleInteraction';
    
    console.log('API Request' + host + path);
    
    http.get({host: host, path: path}, (res) => {
        let body = '';
        res.on('data', (d) => { body += d; });
        res.on('end', () => {
            // We don't return any data back for now
        });
        res.on('error', (error) => {
            reject(error); 
        });
    });
  })
};