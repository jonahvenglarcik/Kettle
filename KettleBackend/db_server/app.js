const express = require('express');
//const { json } = require('express');
const app = express();
const BodyParser = require("body-parser");
app.use(express.json());
app.use(BodyParser.json());
app.use(BodyParser.urlencoded({ extended: true }));
const MONGO_URL = 'mongodb://localhost:27017/';
var MongoClient = require('mongodb').MongoClient
var database, collection;
var querystring = require('querystring');


app.post('/user/createCS', (req, res) => {
	res.header("Access-Control-Allow-Origin", "*");
	res.header("Access-Control-Allow-Headers",
                "Origin, X-Requested-With, Content-Type, Accept");
	console.log("enterd post");	
	
	var myobj = { 
		"RealName": req.body.RealName, 
		"UserName": req.body.UserName,
		"Location": req.body.Location
	 };
	console.log("Object Created");
	collection.insertOne(myobj, function(err, result) {
		if (err) throw err;
		res.send(result.result);
		
	});
});

app.get('/', (req, res) => {
    res.send('Hello Unity Developers');
});


let user = {
	"RealName": "Bobby",
	"UserName": "bobjin32",
	"Location": {
		"Latitude": 34.45721,
		"Longitude": -15.68216
	}
};

let users = [];

users.push(user);

app.get('/user', (req, res) => {
	var q = querystring.parse(req.query);
	//console.log(req.query);
	//console.log(q.search);
	//console.log(JSON.parse(req.query.search));
	

	var query = JSON.stringify(req.query);
	console.log(query);
	query = JSON.parse(query);
	console.log(query);
  	collection.findOne(query, function(err, result) {
    if (err) throw err;
	console.log(result);
	res.send(result);
	});
});


app.listen(3000, () =>{ 
	console.log('started and listening.');
	MongoClient.connect(MONGO_URL, { useNewUrlParser: true, useUnifiedTopology: true }, 
		(error, client) => {
        if(error) {
            throw error;
        }
        database = client.db("Kettle_Test");
        collection = database.collection("Users");
        console.log("Connected to Kettle_Test !");
    });
});