using Dapper;
using MySqlConnector;

namespace DHPhoneStore
{
    public class ExcuteSqlClass
    {
        private readonly string? _connectionString;
        private readonly SqlStatementsManagerClass _sqlStatementsManagerClass = new SqlStatementsManagerClass();
        public ExcuteSqlClass() { }
        public ExcuteSqlClass(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<string> GetStatementById(string statementId)
        {
            return _sqlStatementsManagerClass.ReadStatementById(statementId);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null)
        {
            using (var dbConnection = new MySqlConnection(_connectionString))
            {
                await dbConnection.OpenAsync();

                try
                {
                    var result = await dbConnection.QueryAsync<T>(sql, parameters);
                    return result;
                }
                finally
                {
                    await dbConnection.CloseAsync();
                }
            }
        }

        public async Task<IEnumerable<T>> StatementQueryAsync<T>(string statementId, object parameters = null)
        {
            using (var dbConnection = new MySqlConnection(_connectionString))
            {
                await dbConnection.OpenAsync();

                try
                {
                    var result = await dbConnection.QueryAsync<T>(_sqlStatementsManagerClass.ReadStatementById(statementId), parameters);
                    return result;
                }
                finally
                {
                    await dbConnection.CloseAsync();
                }
            }
        }

        public async Task<object> StatementExecuteAsync(string statementId, object parameters = null)
        {
            var sql = _sqlStatementsManagerClass.ReadStatementById(statementId);

            if (string.IsNullOrEmpty(sql))
            {
                throw new ArgumentException($"Statement '{statementId}' not found");
            }

            using (var dbConnection = new MySqlConnection(_connectionString))
            {
                await dbConnection.OpenAsync();

                try
                {
                    var result = await dbConnection.ExecuteAsync(sql, parameters, null, 360);
                    return result;
                }
                catch (Exception e)
                {
                    return null;
                }
                finally
                {
                    await dbConnection.CloseAsync();
                }
            }
        }
    }
}