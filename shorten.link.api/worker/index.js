require('dotenv').config();
const moment = require('moment')
const cron = require('node-cron');
const { getOriginalLinksAsync } = require('./services/mssql/mssql.shorten.link');
const { setValueAsync, removeValueAsync } = require('./services/redis/redis.shorten.link');
const { KEY } = require('./constant');
const { logAsync } = require('./services/mssql/mssql.log');

const task = cron.schedule(process.env.SHORTEN_LINK_JOB, async ()=>{
    console.log(`${moment().format('LLL')}: ShortenLink Start.`);

    const originalLinks = await getOriginalLinksAsync(); 
    originalLinks.forEach(async (shortenLink) => {
        const key = `${KEY.SHORTEN_LINK}${shortenLink.Hash}`;
        await removeValueAsync(key);
        await setValueAsync(key, shortenLink.OriginalLink);
        await logAsync({
            content: `ShortenLink saved key: ${key}`,
            status: "Done"
        });
    });
    
    console.log(`${moment().format('LLL')}: ShortenLink End.`);
});

task.start();