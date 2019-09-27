const Schema = require('mongoose').Schema;

module.exports = new Schema({
    name: { type: String, required: true },
    artistId: { type: Schema.Types.ObjectId, ref: 'artists', required: true },
    date: { type: Date, required: true },
    images: [String],
    description: { type: String},
    isAuctionItem: { type: Boolean, default: false },
});

/*
title* (String), artistId* (ObjectId), date* (Date, defaults to now), images (A list of
String), description (String), isAuctionItem (Boolean, defaults to false)
 */