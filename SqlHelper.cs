using Dapper;
using Newtonsoft.Json;
using Polly;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SampleServices
{
    public interface ISqlHelper
    {
        List<T> GetList<T>(string storedProcedureName, DynamicParameters parameters);
    }
    public class SqlHelper : ISqlHelper
    {
        private readonly string connectionStrings;
        private readonly int retryCount = 3;

        public SqlHelper()
        {
            connectionStrings = System.Configuration.ConfigurationManager.AppSettings["DBCon"].ToString();
        }
        List<T> ISqlHelper.GetList<T>(string storedProcedureName, DynamicParameters parameters)
        {
            var statusCode = string.Empty;
            var json = string.Empty;
            var reqParams = string.Empty;
            try
            {
                reqParams = SerializeRequestData(parameters);
                using (IDbConnection connection = ReliableSqlConnection(connectionStrings))
                {
                    IEnumerable<T> query = null;

                    getData(storedProcedureName, parameters, () =>
                    {
                        query = BuildQuery<T>(connection, storedProcedureName, parameters);
                    });
                    return query?.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }
        IEnumerable<T> BuildQuery<T>(IDbConnection connection, string storedProcedureName, DynamicParameters parameters)
        {
            return SqlMapper.Query<T>(connection, storedProcedureName.ToString(), parameters, commandType: CommandType.StoredProcedure);
        }
        protected void getData(string storedProcedureName, DynamicParameters parameters, Action method)
        {
            var startTime = DateTimeOffset.Now;
            string message = "";
            try
            {
                method?.Invoke();
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
            }
        }
        private string SerializeRequestData(DynamicParameters parameters)
        {
            var paraDict = new Dictionary<string, dynamic>();
            if (parameters != null)
            {
                foreach (var parameter in parameters.ParameterNames)
                {
                    paraDict.Add(parameter, parameters.Get<dynamic>(parameter));
                }
            }
            return JsonConvert.SerializeObject(paraDict);
        }
        protected SqlConnection ReliableSqlConnection(string connectionString)
        {
            List<int> ErrorNos = new List<int>() { -2, 40197, 40501, 40613, 49918, 49919, 49920 };
            connectionString = string.Format(connectionString);
            var policy = Policy
                  .Handle<SqlException>(ex => ErrorNos.Contains(ex.Number))
                  .WaitAndRetry(3, retryAttempt =>
                          TimeSpan.FromMilliseconds(Math.Pow(1000, retryAttempt)));
            SqlConnection connection = null;
            try
            {

                policy.Execute(() =>
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                });
            }
            catch (Exception e)
            {
                //throw e;
            }
            return connection;
            //return new SqlConnection(connectionString);
        }

    }
}
