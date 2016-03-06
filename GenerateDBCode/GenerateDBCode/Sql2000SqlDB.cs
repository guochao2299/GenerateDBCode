using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;

namespace GenerateDBCode
{
    internal class Sql2000SqlDB: SqlDBQueryableBase
    {
        public Sql2000SqlDB(string connectionString)
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
                cmd = new SqlCommand(string.Format("SELECT id,name FROM {0} WHERE type='{1}'", tableName,tableType), cnn);

                cnn.Open();
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string name = Convert.ToString(reader["name"]).Trim();
                        int id = Convert.ToInt32(reader["id"]);

                        if (funcCreateInstance != null)
                        {
                            buffer.Add(funcCreateInstance(name, id));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sql2000SqlDB->QUeryDB:检索数据库表失败，错误消息为：" + ex.Message, ex);
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

                QUeryDB<MyTable>("sysobjects", "U", tables, new Func<string, int, MyTable>(
                    delegate(string name, int id)
                    {
                        return MyTableBase.CreateTable(name, id);
                    }
                    ));

                return tables;
            }
            catch (Exception ex)
            {
                throw new Exception("Sql2000SqlDB->QueryTables:检索数据库表失败，错误消息为：" + ex.Message, ex);
            }
        }

        public override List<MyView> QueryViews()
        {
            try
            {
                List<MyView> views = new List<MyView>();

                QUeryDB<MyView>("sysobjects", "V", views, new Func<string, int, MyView>(
                    delegate(string name, int id)
                    {
                        return MyTableBase.CreateView(name, id);
                    }
                    ));

                return views;
            }
            catch (Exception ex)
            {
                throw new Exception("Sql2000SqlDB->QueryViews:检索数据库视图失败，错误消息为：" + ex.Message, ex);
            }            
        }

        private const int COL_ISNULLABLE = 0x08;
        private const int COL_ISIDENTITY = 0x80;

        public override List<MyColumn> QueryColumns(int tableID)
        {
            SqlCommand cmd = null;
            SqlDataReader reader = null;
            SqlConnection cnn = null;

            try
            {
                List<MyColumn> lstColumns = new List<MyColumn>();

                cnn = new SqlConnection(ConnectionString);

                string sqlStr = string.Format("SELECT colid from sysconstraints where id = {0} and status = 1", tableID);

                cmd = new SqlCommand(sqlStr, cnn);
                cnn.Open();

                reader = cmd.ExecuteReader();

                List<int> lstPrimaryKeys = new List<int>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int colid = Convert.ToInt32(reader["colid"] ?? "-1");
                        if (colid > 0)//colid=0表约束
                        {
                            lstPrimaryKeys.Add(colid);
                        }
                    }
                }

                reader.Close();

                sqlStr = string.Format("SELECT a.name as ColName,b.name as TypeName,a.colid,a.status,a.xprec,a.xscale,a.length,c.text " +
                                            "from  syscolumns a LEFT JOIN " +
                                            "systypes b ON a.xusertype=b.xusertype left join " +
                                            "syscomments c on a.cdefault=c.id  where a.id={0}"
                                            , tableID);

                cmd.CommandText = sqlStr;
                reader = cmd.ExecuteReader();
                
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MyColumn c = new MyColumn();
                        c.Name = Convert.ToString(reader["ColName"] ?? string.Empty); 
                        c.T = Convert.ToString(reader["TypeName"] ?? string.Empty);
                        c.MaxLength = Convert.ToInt32(reader["length"] ?? "0");
                        c.Precision = Convert.ToInt32(ReadData(reader, "xprec", "0"));
                        c.Scale = Convert.ToInt32(ReadData(reader, "xscale", "0"));
                        byte status = Convert.ToByte(ReadData(reader, "status", "0"));
                        c.Nullable = (status & COL_ISNULLABLE) != 0;
                        c.IsIdentity = (status & COL_ISIDENTITY) != 0;
                        c.DefaultValue = Convert.ToString(reader["text"] ?? string.Empty);
                        c.ID=Convert.ToInt32 (reader["colid"]??-2);
                        c.IsPrimaryKey = lstPrimaryKeys.Contains(c.ID);

                        lstColumns.Add(c);
                    }
                }

                return lstColumns;
            }
            catch (Exception ex)
            {
                throw new Exception("Sql2000SqlDB->QueryColumns:检索数据库表中列信息失败，错误消息为：" + ex.Message);
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
