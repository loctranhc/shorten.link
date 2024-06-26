const os = require('os');
const { HTTP_STATUS_CODE, KEY } = require('./constant');
const {getOriginalLinkByHashAsync} = require('./services/mssql/mssql.shorten.link');
const {getValue, setValue} = require('./services/redis/redis.shorten.link');
const app = require('express')();
require('dotenv').config();

app.get('/:urlHash', async (req, res) => {
    const urlHash = req.params['urlHash'];

    //Get original url from cache
    let redirectEndpoint = await getValue(`${KEY.SHORTEN_LINK}${urlHash}`);
    
    //If not exist in cache, get it from database
    if(redirectEndpoint == undefined || redirectEndpoint == '')
        redirectEndpoint = await getOriginalLinkByHashAsync(urlHash);

    res.redirect(HTTP_STATUS_CODE.MOVED_PERMANENTLY, redirectEndpoint);
});

app.listen(process.env.PORT, ()=>{
    console.log(`Hostname: ${os.hostname} is listening on port: ${process.env.PORT}`)
});