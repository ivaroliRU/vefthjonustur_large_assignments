var db = require('../data/db');

const artistService = () => {
    const getAllArtists = (cb) => {
        db.Artist.find({}, function (err, docs) {            
            cb(err, docs);
        });
    };

    const getArtistById = (id, cb) => {
        db.Artist.findById(id, function (err, doc) {
            cb(err, doc);
        });
    };

    const createArtist = (artist, cb) => {
        db.Artist.create(artist, function(err){
            cb(err);
        });
    };

    return {
        getAllArtists,
        getArtistById,
        createArtist
    };
};

module.exports = artistService();
