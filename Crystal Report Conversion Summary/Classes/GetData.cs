using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CrystalReportConversionSummary.Classes
{
    public class ReportDetail
    {
        public string User { get; set; }

        public int RunCount { get; set; }

        public DateTime EarliestExecution { get; set; }

        public DateTime MostRecentExecution { get; set; }
    }

    public class ReportRun
    {
        public int SprocID { get; set; }

        public string SprocName { get; set; }

        public string ReportName { get; set; }

        public int ExecutionCount { get; set; }

        public DateTime EarliestExecution { get; set; }

        public DateTime MostRecentExecution { get; set; }
    }

    public static class SandboxData
    {
        public const string ConnectionString = "Data Source=dbcims;Initial Catalog=Sandbox;Integrated Security=true";

        public static async Task<IEnumerable<ReportRun>> GetSprocHistoryMasterAsync()
        {
            using (var cn = new SqlConnection(ConnectionString))
            {
                var cmd = cn.CreateCommand();

                cmd.CommandText = "dbo.GetCrystalReportSprocHistory_Master";
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    cn.Open();

                    var reader = await cmd.ExecuteReaderAsync();

                    var items = new List<ReportRun>();

                    while (reader.Read())
                    {
                        items.Add(new ReportRun()
                        {
                            SprocID = (int)reader["StoredProcedureID"],
                            SprocName = (string)reader["StoredProcedureName"],
                            ReportName = (string)reader["ReportName"],
                            ExecutionCount = (int)reader["ExecutionCount"],
                            //EarliestExecution = (DateTime)reader["EarliestExecution"],
                            MostRecentExecution = (DateTime)reader["MostRecentExecution"],
                        });
                    }

                    return items;
                }
                finally
                {
                    cn.Close();
                }
            }
        }

        public static async Task<IEnumerable<ReportDetail>> GetSprocHistoryDetailAsync(int sprocId)
        {
            using (var cn = new SqlConnection(ConnectionString))
            {
                var cmd = cn.CreateCommand();

                cmd.CommandText = "dbo.GetCrystalReportSprocHistory_Detail";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StoredProcedureID", sprocId);

                try
                {
                    cn.Open();

                    var reader = await cmd.ExecuteReaderAsync();

                    var items = new List<ReportDetail>();

                    while (reader.Read())
                    {
                        items.Add(new ReportDetail()
                        {
                            User = (string)reader["ExecutionUser"],
                            RunCount = (int)reader["RunCount"],
                            EarliestExecution = (DateTime)reader["EarliestExecution"],
                            MostRecentExecution = (DateTime)reader["MostRecentExecution"]
                        });
                    }

                    return items;
                }
                finally
                {
                    cn.Close();
                }
            }
        }

        public static async Task<IEnumerable<ReportRun>> GetSprocHistoryAsyncCalledByVB6()
        {
            using (var cn = new SqlConnection(ConnectionString))
            {
                var cmd = cn.CreateCommand();

                cmd.CommandText = "dbo.GetCrystalReportSprocHistory_CalledByVB6";
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    cn.Open();

                    var reader = await cmd.ExecuteReaderAsync();

                    var items = new List<ReportRun>();

                    while (reader.Read())
                    {
                        items.Add(new ReportRun()
                        {
                            SprocID = (int)reader["StoredProcedureID"],
                            SprocName = (string)reader["StoredProcedure"],
                            ReportName = (string)reader["ReportName"],
                            ExecutionCount = (int)reader["RunCount"],
                            MostRecentExecution = (DateTime)reader["MostRecentRun"],
                        });
                    }

                    return items;
                }
                finally
                {
                    cn.Close();
                }
            }
        }

        public static async Task<IEnumerable<ReportRun>> GetSprocNotInUseAsync()
        {
            using (var cn = new SqlConnection(ConnectionString))
            {
                var cmd = cn.CreateCommand();

                cmd.CommandText = "dbo.GetCrystalReportsNotInUse";
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    cn.Open();

                    var reader = await cmd.ExecuteReaderAsync();

                    var items = new List<ReportRun>();

                    while (reader.Read())
                    {
                        items.Add(new ReportRun()
                        {
                            SprocName = (string)reader["RPT_StoredProcedure"],
                            ReportName = (string)reader["RPT_ReportName"]
                        });
                    }

                    return items;
                }
                finally
                {
                    cn.Close();
                }
            }
        }

    }
}
