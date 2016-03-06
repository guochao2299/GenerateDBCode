using System;
using System.Collections.Generic;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text;

namespace GenerateDBCode
{
    /// <summary>
    /// 该接口用于创建Sql查询语句
    /// </summary>
    internal interface ISqlDBQueryable
    {
        List<MyTable> QueryTables();

        List<MyView> QueryViews();

        List<MyColumn> QueryColumns(int tableID);

        MyDatabase QueryDBInfo(string dbName);

        string ConnectionString { get; }
    }

    internal abstract class SqlDBQueryableBase : ISqlDBQueryable
    {
        public const string SQL_2008_R2 = "SQL2008R2";
        public const string SQL_2000 = "SQL2000";

        protected string m_connectionString = string.Empty;

        public SqlDBQueryableBase(string connectionString)
        {
            m_connectionString = connectionString;
        }

        #region ISqlDBQueryable Members

        public virtual List<MyTable> QueryTables()
        {
            return new List<MyTable>();
        }

        public virtual List<MyView> QueryViews()
        {
            return new List<MyView>();
        }

        protected object ReadData(SqlDataReader reader, string key, string defaultValue)
        {
            if (reader[key] == DBNull.Value)
            {
                return defaultValue;
            }

            return reader[key] ?? defaultValue;
        }

        public virtual MyDatabase QueryDBInfo(string dbName)
        {
            MyDatabase m = new MyDatabase();
            m.Name = dbName;
            return m;
        }
        public virtual List<MyColumn> QueryColumns(int tableID)
        {
            return new List<MyColumn>();
        }

        public string ConnectionString
        {
            get
            {
                return m_connectionString;
            }
        }

        public static ISqlDBQueryable CreateQueryableSqlDB(string sign, string cnnString)
        {
            ISqlDBQueryable result = null;

            switch (sign.ToUpper())
            {
                case SQL_2008_R2:
                    result = new Sql2008R2SqlDB(cnnString);
                    break;

                case SQL_2000:
                    result = new Sql2000SqlDB(cnnString);
                    break;

                default:
                    result = new NullSqlDB(cnnString);
                    break;
            }

            return result;
        }

        public static List<string> SupportedSqlDB
        {
            get
            {
                List<string> lstDbs = new List<string>();
                lstDbs.Add(SQL_2008_R2);
                lstDbs.Add(SQL_2000);

                return lstDbs;
            }
        }

        #endregion
    }

    internal class NullSqlDB : SqlDBQueryableBase
    {
        public NullSqlDB(string connectionString)
            : base(connectionString)
        { }
    }
}
