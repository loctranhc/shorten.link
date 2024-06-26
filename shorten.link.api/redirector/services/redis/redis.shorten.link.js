const {client}  = require('./config/redis.config')

client.connect();

const getValue = async (key) => {
    const value = await client.get(key);
    return value;
}

module.exports = {
    getValue
}