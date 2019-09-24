var db = require('../data/db');

const auctionService = () => {
    const getAllAuctions = (cb) => {
        db.Auction.find({}, function (err, docs) {
            cb(err, docs);
        });
    };

    const getAuctionById = (id, cb) => {
        db.Auction.findById(id, function (err, doc) {
            cb(err, doc);
        });
    };

    const getAuctionWinner = (auctionId, cb) => {
        db.Customer.findOne({ auctionId: auctionId })
        .populate('auctions')
        .populate('auctionBids')
        .sort('price')
        .exec(function (err, doc) {
            cb(err,doc);
        });
    };

	const createAuction = (auction, cb) => {
        db.Auction.create(auction , function(err) {
            cb(err);
        });
    };

	const getAuctionBidsWithinAuction = (auctionId, cb) => {
        db.AuctionBid.find({auctionId:auctionId}, function(err, docs){
            cb(err, docs);
        });
    };

	const placeNewBid = (auctionId, customerId, price, cb) => {
        var bid = {auctionId:auctionId, customerId:customerId, price:price};
        db.AuctionBid.create(bid , function(err) {
            cb(err);
        });
	}

    return {
        getAllAuctions,
        getAuctionById,
        getAuctionWinner,
		createAuction,
		getAuctionBidsWithinAuction,
		placeNewBid
    };
};

module.exports = auctionService();
