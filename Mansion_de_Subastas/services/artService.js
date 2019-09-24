var db = require('../data/db');

const artService = () => {
    const getAllArts = (cb) => {
        db.Art.find({}, function (err, docs) {            
            cb(err, docs);
        });
    };

    const getArtById = (id, cb) => {
        db.Art.findById(id, function (err, doc) {
            cb(err, doc);
        });
    };

    const createArt = (art, cb) => {
        db.Art.create(art, function(err){
            cb(err);
        });
    };

    return {
        getAllArts,
        getArtById,
        createArt
    };
};

module.exports = artService();
