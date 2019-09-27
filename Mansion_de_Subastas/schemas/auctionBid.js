const Schema = require('mongoose').Schema;

module.exports = new Schema({
    auctionId: { type: Schema.Types.ObjectId, ref: 'auctions', required: true },
    customerId: { type: Schema.Types.ObjectId, ref: 'customers', required: true },
    price: { type: Number, required: true },
});


/*
auctionId* (ObjectId), customerId* (ObjectId), price* (Number)
*/