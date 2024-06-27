const { context, connectAsync } = require('./config/mssql.config');

const logAsync = async (logModel) => {
    const pool = await connectAsync;
    const result = await pool.request()
        .input('Content', context.VarChar, logModel.content)
        .input('Status', context.VarChar, logModel.status)
        .query("insert into WorkerLogs (JobName, Content, Status) values ('ShortenLink', @Content, @Status)");
        
    return result?.recordset;
}

module.exports = {
    logAsync
};