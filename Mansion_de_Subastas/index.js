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
            return res.status(500).end();
        }

        return res.json(result);
    });
});

// http://localhost:3000/api/arts/:id [GET]
app.get('/api/arts/:id', function (req, res) {
    const artId = req.params.id;
    artService.getArtById(artId, (err, result) => {
        if (err) {
            return res.status(404).end();
        }

        return res.json(result);
    });
});

app.post('/api/arts', function(req, res) {
    const art = req.body;
    console.log(art);
    
    artService.createArt(art, (err) => {
        if (err) {
            console.log(err);
            
            return res.status(400).end();
        }

        return res.status(201).end();
    });
});

/*
---------------------------------------
|         artists endpoints           |
---------------------------------------
*/

// http://localhost:3000/api/artists [GET]
app.get('/api/artists', function (req, res) {
    artistService.getAllArtists((err, result) => {
        if (err) {
            return res.status(500).end();
        }
        return res.json(result);
    });
});

// http://localhost:3000/api/artists/:id [GET]
app.get('/api/artists/:id', function (req, res) {
    const artistsId = req.params.id;
    artistService.getArtistById(artistsId, (err, result) => {
        if (err) {
            return res.status(500).end();
        }

        return res.json(result);
    });
});

app.post('/api/artists', function(req, res) {
    const artist = req.body;
    artistService.createArtist(artist, (err) => {
        if (err) {
            return res.status(400).end();
        }

        return res.status(201).end();
    });
});

/*
---------------------------------------
|       customers endpoints           |
---------------------------------------
*/

// http://localhost:3000/api/customers [GET]
app.get('/api/customers', function (req, res) {
    customerService.getAllCustomers((err, result) => {
        if (err) {
            console.log(err);
            return res.status(500).end();
        }
        return res.json(result);
    });
});

// http://localhost:3000/api/customers/:id [GET]
app.get('/api/customers/:id', function (req, res) {
    const customersId = req.params.id;
    customerService.getCustomerById(customersId, (err, result) => {
        if (err) {
            return res.status(500).end();
        }

        return res.json(result);
    });
});

app.post('/api/customers', function(req, res) {
    const customer = req.body;
    customerService.createCustomer(customer, (err) => {
        if (err) {
            return res.status(400).end();
        }

        return res.status(201).end();
    });
});

// http://localhost:3000/api/customers/:id/auction-bids [GET]
app.get('/api/customers/:id/auction-bids', function (req, res) {
    var id = req.params.id;

    customerService.getCustomerAuctionBids(id, function(err, docs){
        return res.json(docs);
    });
});

/*
---------------------------------------
|        auctions endpoints           |
---------------------------------------
*/

// http://localhost:3000/api/auctions [GET]
app.get('/api/auctions', function (req, res) {
    auctionService.getAllAuctions((err, result) => {
        if (err) {
            return res.status(500).end();
        }
        
        return res.json(result);
    });
});

// http://localhost:3000/api/auctions/:id [GET]
app.get('/api/auctions/:id', function (req, res) {
    const auctionsId = req.params.id;
    auctionService.getAuctionById(auctionsId, (err, result) => {
        if (err)
        {
            return res.status(404).end();
        }
        return res.json(result);
    });
});

app.post('/api/auctions', function (req, res) {
    const auction = req.body;

    auctionService.createAuction(auction,(err) => {
        if (err) {
            return res.status(400).end();
        }
        
        return res.status(201).end();
    });
});


// http://localhost:3000/api/auctions/:id/winner [GET]
app.get('/api/auctions/:id/winner', function (req, res) {
    const auctionsId = req.params.id;
    console.log("Getting auction winner of: " + auctionsId);
    
    auctionService.getAuctionWinner(auctionsId, (err, result) => {
        if (err)
        {
            return res.status(404).end();
        }
        return res.json(result).send('This auction had no bids');
    });
});

// http://localhost:3000/api/auctions/:id/bids [GET]
app.get('/api/auctions/:id/bids', function (req, res) {
    const auctionsId = req.params.id;
    auctionService.getAuctionBidsWithinAuction(auctionsId, (err, result) => {
        if (err)
        {
            return res.status(404).end();
        }
        return res.json(result);
    });
});

//Klára place new bids
// http://localhost:3000/api/auctions/:id/bids [Post]
app.post('/api/auctions/:id/bids', function (req, res) {
    const auctionsId = req.params.id;
    const bid = req.body;

    bid.auctionId = auctionsId;

    auctionService.placeNewBid(auctionsId, bid, (err) => {
        if (err)
        {
            return res.status(404).end();
        }
        return res.status(200).end();
    }, (status)=> {return res.status(status).end();});
});

// http://localhost:3000
app.listen(3000, function () {
    console.log('Server is listening on http://localhost:3000');
});
