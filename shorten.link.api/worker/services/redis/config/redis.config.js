require('dotenv').config();
const {createClient} = require('redis');
const config = {
    url: process.env.REDIS_CONNECTION_STRING
}
const client = createClient(config);

module.exports = {
    client
}