using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text;

namespace GenerateDBCode
{
    internal class Sql2008R2SqlDB : SqlDBQueryableBase
    {
        public Sql2008R2SqlDB(string connectionString)
            : base(connectionString)
        {
        }

        private void QUeryDB<T>(string tableName,string tableType, List<T> buffer, Func<string, int, T> funcCreateInstance)
            where T : MyTableBase
        {
            SqlCommand cmd = null;
            SqlDataReader reader = null;
            SqlConnection cnn = null;

            try
            {
                cnn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand(string.Format("SELECT object_id,name FROM {0} WHERE type='{1}'", tableName,tableType), cnn);

                cnn.Open();
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string name = Convert.ToString(reader["name"]).Trim();
                        int id = Convert.ToInt32(reader["object_id"]);

                        if (funcCreateInstance != null)
                        {
                            buffer.Add(funcCreateInstance(name, id));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sql2008R2SqlDB->QUeryDB:检索数据库表失败，错误消息为：" + ex.Message, ex);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (cnn != null && (cnn.State != ConnectionState.Closed))
                {
                    cnn.Close();
                }
            }
        }

        public override List<MyTable> QueryTables()
        {
            try
            {
                List<MyTable> tables = new List<MyTable>();

                QUeryDB<MyTable>("sys.tables","U", tables, new Func<string, int, MyTable>(
                    delegate(string name, int id)
                    {
                        return MyTableBase.CreateTable(name, id);
                    }
                    ));

                return tables;
            }
            catch (Exception ex)
            {
                throw new Exception("Sql2008R2SqlDB->QueryTables:检索数据库表失败，错误消息为：" + ex.Message, ex);
            }
        }

        public override List<MyView> QueryViews()
        {
            try
            {
                List<MyView> views = new List<MyView>();

                QUeryDB<MyView>("sys.views", "V", views, new Func<string, int, MyView>(
                    delegate(string name, int id)
                    {
                        return MyTableBase.CreateView(name, id);
                    }
                    ));

                return views;
            }
            catch (Exception ex)
            {
                throw new Exception("Sql2008R2SqlDB->QueryViews:检索数据库视图失败，错误消息为：" + ex.Message, ex);
            }            
        }

        public override List<MyColumn> QueryColumns(int tableID)
        {
#if DEBUG
            Console.WriteLine(tableID);
#endif
            SqlCommand cmd = null;
            SqlDataReader reader = null;
            SqlConnection cnn = null;

            try
            {
                List<MyColumn> lstColumns = new List<MyColumn>();

                cnn = new SqlConnection(ConnectionString);

                string sqlStr = string.Format("SELECT c.column_id  " +
                              "FROM sys.indexes AS i " +
                              "INNER JOIN sys.index_columns AS ic " +
                              "ON i.object_id = ic.object_id AND i.index_id = ic.index_id " +
                              "INNER JOIN sys.columns AS c "+
                              "ON ic.object_id = c.object_id AND c.column_id = ic.column_id "+ 
                              "WHERE i.is_primary_key = 1  AND i.object_id = {0}", tableID);

                cmd = new SqlCommand(sqlStr, cnn);
                cnn.Open();

                reader = cmd.ExecuteReader();

                List<int> lstPrimaryKeys = new List<int>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        lstPrimaryKeys.Add(Convert.ToInt32(ReadData(reader,"column_id","-1")));
                    }
                }

                reader.Close();

                sqlStr = string.Format("SELECT a.name as ColName,b.name as TypeName,a.column_id,a.is_identity,a.precision,a.scale,a.max_length,a.is_nullable,c.definition " +
                                            "from  sys.columns a LEFT JOIN " +
                                            "sys.types b ON a.user_type_id=b.user_type_id left join " +
                                            "sys.default_constraints c on a.default_object_id=c.object_id  where a.object_id={0}"
                                            , tableID);

                cmd.CommandText = sqlStr;
                reader = cmd.ExecuteReader();
                
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MyColumn c = new MyColumn();
                        c.Name = Convert.ToString(ReadData(reader,"ColName",string.Empty));
                        c.T = Convert.ToString(ReadData(reader,"TypeName",string.Empty));
                        c.MaxLength = Convert.ToInt32(ReadData(reader,"max_length","0"));
                        c.Precision = Convert.ToInt32(ReadData(reader,"precision","0"));
                        c.Scale = Convert.ToInt32(ReadData(reader,"scale","0"));
                        c.Nullable = Convert.ToBoolean(ReadData(reader,"is_nullable","1"));
                        c.IsIdentity = Convert.ToBoolean(ReadData(reader,"is_identity","0"));
                        c.DefaultValue = Convert.ToString(ReadData(reader,"definition",string.Empty));
                        c.ID = Convert.ToInt32(ReadData(reader,"column_id","-2"));
                        c.IsPrimaryKey = lstPrimaryKeys.Contains(c.ID);

                        lstColumns.Add(c);
                    }
                }

                reader.Close();

                foreach (MyColumn mc in lstColumns)
                {
                    if (mc.IsIdentity)
                    {
                        sqlStr = string.Format("SELECT seed_value,increment_value FROM sys.identity_columns   where object_id={0} and column_id={1}",
                            tableID, mc.ID);

                        cmd.CommandText = sqlStr;
                        reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();
                            mc.IdentityIncrement = Convert.ToInt32(ReadData(reader,"increment_value","0"));
                            mc.IdentitySeed = Convert.ToInt32(ReadData(reader,"seed_value","0"));
                        }
                    }
                }

                return lstColumns;
            }
            catch (Exception ex)
            {
                throw new Exception("Sql2008R2SqlDB->QueryColumns:检索数据库表中列信息失败，错误消息为：" + ex.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (cnn != null && (cnn.State != ConnectionState.Closed))
                {
                    cnn.Close();
                }
            }
        }

        public override MyDatabase QueryDBInfo(string dbName)
        {
            MyDatabase myDB = new MyDatabase();
            myDB.Name = dbName;

            foreach (MyTable mt in QueryTables())
            {
#if DEBUG
                Console.WriteLine(mt.Name);
#endif
                foreach (MyColumn mc in QueryColumns(mt.ID))
                {
                    mt.Columns.Add(mc.Name, mc);
                }

                myDB.Tables.Add(mt.ID, mt);
            }

            foreach (MyView mv in QueryViews())
            {
                foreach (MyColumn mc in QueryColumns(mv.ID))
                {
                    mv.Columns.Add(mc.Name, mc);
                }

                myDB.Views .Add(mv.ID, mv);
            }

            return myDB;
        }
    }
}
