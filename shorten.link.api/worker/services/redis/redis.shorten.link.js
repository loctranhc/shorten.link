const {client}  = require('./config/redis.config')

client.connect();

const setValueAsync = async (key, value) => {
    await client.set(key, value);
}

const removeValueAsync = async (key) => {
    await client.del(key);
}

module.exports = {
    setValueAsync,
    removeValueAsync
}