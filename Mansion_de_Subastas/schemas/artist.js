const Schema = require('mongoose').Schema;

module.exports = new Schema({
    name: { type: String, required: true },
    nickname: { type: String, required: true },
    address: { type: String, required: true },
    memberSince: { type: Date, default: Date.now },
});

/*
name* (String), nickname* (String), address* (String), memberSince* (Date,
defaults to now)
*/