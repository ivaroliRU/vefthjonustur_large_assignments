const express = require('express');
const bodyParser = require('body-parser');
const artService = require('./services/artService');
const artistService = require('./services/artistService');
const auctionService = require('./services/auctionService');
const customerService = require('./services/customerService');
const app = express();

app.use(bodyParser.json());

/*
---------------------------------------
|           arts endpoints            |
---------------------------------------
*/

// http://localhost:3000/api/arts [GET]
app.get('/api/arts', function (req, res) {
    artService.getAllArts((err, result) => {
        if (err) {
            res.status(500).end();
        }

        return res.json(result);
    });
});

// http://localhost:3000/api/arts/:id [GET]
app.get('/api/arts/:id', function (req, res) {
    const artId = req.params.id;
    return res.json('{}');
});

app.post('/api/arts', function(req, res) {
    return res.status(201).json('{}');
});

/*
---------------------------------------
|         artists endpoints           |
---------------------------------------
*/

// http://localhost:3000/api/artists [GET]
app.get('/api/artists', function (req, res) {
    return res.json('{}');
});

// http://localhost:3000/api/artists/:id [GET]
app.get('/api/artists/:id', function (req, res) {
    const artistsId = req.params.id;
    return res.json('{}');
});

app.post('/api/artists', function(req, res) {
    return res.status(201).json('{}');
});

/*
---------------------------------------
|       customers endpoints           |
---------------------------------------
*/

// http://localhost:3000/api/customers [GET]
app.get('/api/customers', function (req, res) {
    return res.json('{}');
});

// http://localhost:3000/api/customers/:id [GET]
app.get('/api/customers/:id', function (req, res) {
    const customersId = req.params.id;
    return res.json('{}');
});

app.post('/api/customers', function(req, res) {
    return res.status(201).json('{}');
});

/*
---------------------------------------
|        auctions endpoints           |
---------------------------------------
*/

// http://localhost:3000/api/customers/:id/auction-bids [GET]
app.get('/api/customers/:id/auction-bids', function (req, res) {
    var id = req.params.id;

    customerService.getCustomerAuctionBids(id, function(err, docs){
        return res.json(docs);
    });
});

// http://localhost:3000/api/auctions [GET]
app.get('/api/auctions', function (req, res) {
    return res.json('{}');
});

// http://localhost:3000/api/auctions/:id [GET]
app.get('/api/auctions/:id', function (req, res) {
    const auctionsId = req.params.id;
    return res.json('{}');
});

// http://localhost:3000/api/auctions/:id/winner [GET]
app.get('/api/auctions/:id/winner', function (req, res) {
    const auctionsId = req.params.id;
    return res.json('{}');
});

// http://localhost:3000/api/auctions/:id/winner [Post]
app.post('/api/auctions/:id/bids', function (req, res) {
    const auctionsId = req.params.id;
    return res.json('{}');
});

// http://localhost:3000
app.listen(3000, function () {
    console.log('Server is listening on http://localhost:3000');
});