const { context, connectAsync } = require('./config/mssql.config');

const getOriginalLinkByHashAsync = async (hash) => {
    const pool = await connectAsync;
    const result = await pool.request()
        .input('hash', context.VarChar, hash)
        .query('SELECT TOP 1 OriginalLink FROM dbo.ShortenLinks WHERE Hash = @hash')
        
    return result?.recordset[0]?.OriginalLink;
}

module.exports = {
    getOriginalLinkByHashAsync
};