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
        db.AuctionBid.findOne({auctionId:auctionId})
        .sort({"price" : -1})
        .limit(1)
        .exec(function(err, bid){
            db.Auction.findById(auctionId, function(err, auction){
                if(err != undefined){
                    cb(err, null);
                }

                var date = new Date(auction.endDate), CurrentDate = new Date();                
                if(date <= CurrentDate){
                    db.Customer.findOne({_id: bid.customerId}, function(err, customer){                        
                        cb(err, customer);
                    });
                }
            });
        });
    };

    const createAuction = (auction, cb) => {
        db.Auction.create(auction, function (err) {
            cb(err);
        });
    };

    const getAuctionBidsWithinAuction = (auctionId, cb, errcb) => {
        db.AuctionBid.find({ auctionId: auctionId }, function (err, docs) {
            cb(err, docs);
        });
    };

    const placeNewBid = (auctionId, customerId, price, cb, errcb) => {
        var bid = { auctionId: auctionId, customerId: customerId, price: price };
        db.AuctionBid.create(bid, function (err) {
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
