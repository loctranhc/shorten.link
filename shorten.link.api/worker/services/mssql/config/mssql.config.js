require('dotenv').config();
const sql = require('mssql')

module.exports = {
  connectAsync: sql.connect(process.env.MSSQL_CONNECTION_STRING),
  context: sql
};

