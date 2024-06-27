const { context, connectAsync } = require('./config/mssql.config');

const getOriginalLinksAsync = async () => {
    const pool = await connectAsync;
    const result = await pool.request()
        .query('SELECT OriginalLink, Hash FROM dbo.ShortenLinks')
        
    return result?.recordset;
}

module.exports = {
    getOriginalLinksAsync
};