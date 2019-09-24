const mongoose = require('mongoose');
const artSchema = require('../schemas/art');
const artistSchema = require('../schemas/artist');
const auctionSchema = require('../schemas/auction');
const auctionBidSchema = require('../schemas/auctionBid');
const customerSchema = require('../schemas/customer');

const connection = mongoose.createConnection('mongodb+srv://vefthonustur:vefthonustur@vefthonustur-kmczd.mongodb.net/vefthonustur', { useNewUrlParser: true });

module.exports = {
    Art: connection.model('arts', artSchema),
    Artist: connection.model('artists', artistSchema),
    Auction: connection.model('auctions', auctionSchema),
    AuctionBid: connection.model('AuctionBid', auctionBidSchema, 'auctionBids'),
    Customer: connection.model('customers', customerSchema)
};
