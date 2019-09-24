var db = require('../data/db');

const customerService = () => {
    const getAllCustomers = (cb) => {
        db.Customer.find({}, function (err, docs) {            
            cb(err, docs);
        });
    };

    const getCustomerById = (id, cb) => {
        db.Customer.findById(id, function (err, doc) {
            cb(err, doc);
        });
    };

    const getCustomerAuctionBids = (customerId, cb) => {
        db.AuctionBid.find({customerId:customerId}, function (err, docs) {
            cb(err, docs);
        });
    };

	const createCustomer = (customer, cb) => {
        db.Customer.create(customer, function(err){
            cb(err);
        });
    };

    return {
        getAllCustomers,
        getCustomerById,
        getCustomerAuctionBids,
		createCustomer
    };
};

module.exports = customerService();
