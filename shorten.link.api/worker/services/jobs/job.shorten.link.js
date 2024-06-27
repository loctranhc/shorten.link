const { setValueAsync, removeValueAsync } = require('../redis/redis.shorten.link');

const setShortenLinkAsync = async (key, value, expireSeconds) => {
    await removeValueAsync(key);
    await setValueAsync(key, value, expireSeconds);
}

module.exports = {
    setShortenLinkAsync
}