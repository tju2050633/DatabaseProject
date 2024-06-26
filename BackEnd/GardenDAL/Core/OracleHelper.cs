﻿using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Garden.DAL.Core
{
    public static class OracleHelper
    {
        // 数据库连接字段
        //public static string connectionString = "Data Source=localhost:1521/orcl;User Id=C##gd;Password=123456;";
        private static readonly string connectionString = "Data Source=120.27.148.187:1521/orcl;User Id=C##gd;Password=123456;";
        public static DataTable ExecuteTable(string cmdText, params OracleParameter[] oracleParameters)
        {
            using OracleConnection conn = new(connectionString);
            conn.Open();
            using OracleCommand cmd = new(cmdText, conn);
            cmd.Parameters.AddRange(oracleParameters);
            OracleDataAdapter adapter = new(cmd);
            DataSet ds = new();
            adapter.Fill(ds);
            return ds.Tables[0];
        }


        public static int ExecuteNonQuery(string cmdText, params OracleParameter[] oracleParameters)
        {
            using OracleConnection conn = new(connectionString);
            conn.Open();
            using OracleCommand cmd = new(cmdText, conn);
            cmd.Parameters.AddRange(oracleParameters);
            return cmd.ExecuteNonQuery();
        }

        public static object ExecuteScalar(string cmdText, params OracleParameter[] oracleParameters)
        {
            using OracleConnection conn = new(connectionString);
            conn.Open();
            using OracleCommand cmd = new(cmdText, conn);
            cmd.Parameters.AddRange(oracleParameters);
            return cmd.ExecuteScalar();
        }
    }
}
