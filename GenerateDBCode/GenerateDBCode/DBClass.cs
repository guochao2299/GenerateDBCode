using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace GenerateDBCode
{
    [Serializable()]
    public class MyDatabase
    {
        public MyDatabase()
        { }
        public string Name = string.Empty;
        public SerializableDictionary<int, MyTable> Tables = new SerializableDictionary<int, MyTable>();
        public SerializableDictionary<int, MyView> Views = new SerializableDictionary<int, MyView>();

        public void SaveDBStruct2XMLFile(string filePath)
        {
            FileStream fs = null;

            try
            {
                fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                XmlSerializer writer = new XmlSerializer(typeof(MyDatabase));
                writer.Serialize(fs, this);
            }
            catch (Exception ex)
            {
                throw new Exception("将数据库结构另存为文件失败，错误消息为：" + ex.Message,ex);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

        public static MyDatabase ReadDBStructFromXMLFile(string filePath)
        {
            FileStream fs = null;

            try
            {
                fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                XmlSerializer writer = new XmlSerializer(typeof(MyDatabase));
                return (MyDatabase)writer.Deserialize(fs);
            }
            catch (Exception ex)
            {
                throw new Exception("将数据库结构另存为文件失败，错误消息为：" + ex.Message, ex);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }
    }

    public interface IPropertyEqual
    {
        bool PropertyEqual(object t);
    }

    [Serializable()]
    public abstract class MyTableBase:IPropertyEqual
    {
        public string Name = string.Empty;
        public int ID = -1;
        public SerializableDictionary<string, MyColumn> Columns = new SerializableDictionary<string, MyColumn>();

        public static MyTable CreateTable(string name, int id)
        {
            MyTable t = new MyTable();
            t.Name = name;
            t.ID = id;

            return t;
        }

        protected string m_tableType = string.Empty;

        public virtual string TableType
        {
            get
            {
                return m_tableType;
            }
        }

        protected string m_tableSqlTitle = string.Empty;

        public abstract string GetTableSqlTitle();

        public virtual string GetCreateSqlString()
        {
            if (Columns.Count <= 0)
            {
                throw new ArgumentNullException("表中不包含任何列定义");
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("CREATE {0}", GetTableSqlTitle()));
            sb.AppendLine("(");

            List<string> primaryKeys=new List<string>();

            foreach (MyColumn mc in Columns.Values)
            {
                sb.AppendLine(mc.ToDBString() + ",");
                
                if (mc.IsPrimaryKey)
                {
                    primaryKeys.Add(mc.Name);
                }
            }

            if (primaryKeys.Count > 0)
            {
                sb.AppendLine(string.Format("CONSTRAINT [PK_{0}] PRIMARY KEY CLUSTERED ",Name));
                sb.AppendLine("(");

                for (int i = 0; i < primaryKeys.Count; i++)
                {
                    sb.AppendLine(string.Format("{0} ASC {1}", primaryKeys[i], (i == (primaryKeys.Count - 1)) ? "" : ","));
                }

                sb.AppendLine(")");
            }
            else
            {
                sb.Remove(sb.Length - 1, 1);
            }

            sb.AppendLine(")");

            return sb.ToString();
        }

        public static MyView CreateView(string name, int id)
        {
            MyView t = new MyView();
            t.Name = name;
            t.ID = id;

            return t;
        }

        public virtual bool PropertyEqual( object table)
        {
            MyTableBase t = (MyTableBase)table;

            if (string.Compare(Name, t.Name, true) != 0)
            {
                return false;
            }

            if (this.Columns.Count != t.Columns.Count)
            {
                return false;
            }

            foreach (string colName in this.Columns.Keys)
            {
                if (!t.Columns.ContainsKey(colName))
                {
                    return false;
                }

                if (!this.Columns[colName].PropertyEqual(t.Columns[colName]))
                {
                    return false;
                }
            }

            return true;
        }
    }

    [Serializable()]
    public class MyTable : MyTableBase
    {
        public MyTable()
        {
            m_tableType = "用户表";
        }

        public override string GetTableSqlTitle()
        {
            return "TABLE";
        }
    }

    [Serializable()]
    public class MyView : MyTableBase
    {
        public MyView()
        {
            m_tableType = "视图";
        }

        public override string GetTableSqlTitle()
        {
            return "VIEW";
        }
    }

    [Serializable()]
    public class MyColumn:IPropertyEqual
    {
        public MyColumn()
        { }
        public string Name = string.Empty;
        public string T = string.Empty;
        public int MaxLength = 0;
        public int Precision = 0;
        public int Scale = 0;
        public int ID = 0;
        public bool Nullable = false;
        public bool IsPrimaryKey=false;
        public bool IsIdentity = false;
        public int IdentitySeed = 0;
        public int IdentityIncrement = 0;
        public string DefaultValue = null;

        public bool PropertyEqual(object o)
        {
            MyColumn mc=(MyColumn)o;

            if (string.Compare(Name, mc.Name, true) != 0)
            {
                return false;
            }

            if (string.Compare(T, mc.T, true) != 0)
            {
                return false;
            }

            if (Nullable != mc.Nullable)
            {
                return false;
            }

            if (IsPrimaryKey != mc.IsPrimaryKey)
            {
                return false;
            }

            if (string.Compare(DefaultValue, mc.DefaultValue, true) != 0)
            {
                return false;
            }

            if (IsIdentity != mc.IsIdentity)
            {
                return false;
            }

            if (IdentitySeed != mc.IdentitySeed)
            {
                return false;
            }

            if (IdentityIncrement != mc.IdentityIncrement)
            {
                return false;
            }

            if (Precision != mc.Precision)
            {
                return false;
            }

            if (Scale != mc.Scale)
            {
                return false;
            }

            return true;
        }

        private string GetColumnTypeDesc()
        {
            string colType = string.Empty;
            const int MAX_SIGN = -1;

            switch (T.ToUpper())
            {
                case "VARCHAR":
                case "BINARY":
                case "CHAR":
                case "VARBIANRY":

                    if (MaxLength == MAX_SIGN)
                    {
                        colType = string.Format("{0}({1}) ", T, "MAX");
                    }
                    else
                    {
                        colType = string.Format("{0}({1}) ", T, MaxLength);
                    }

                    break;

                case "DATETIMEOFFSET":
                case "DATETIME2":
                case "TIME":
                    colType = string.Format("{0}({1}) ", T, Scale);
                    break;

                case "NUMERIC":
                case "DECIMAL":
                    colType = string.Format("{0}({1},{2}) ", T, Precision, Scale);
                    break;

                case "NVARCHAR":
                case "NCHAR":

                    if (MaxLength == MAX_SIGN)
                    {
                        colType = string.Format("{0}({1}) ", T, "MAX");
                    }
                    else
                    {
                        colType = string.Format("{0}({1}) ", T, MaxLength / 2);
                    }
                    break;

                default:
                    colType = T;
                    break;
            }

            return colType;
        }

        public override string ToString()
        {
            StringBuilder sb=new StringBuilder();

            sb.Append(string.Format("Name = {0},",Name));
            sb.Append(string.Format("Type = {0},",T));
            sb.Append(string.Format("MaxLength = {0},", MaxLength));
            sb.Append(string.Format("Precision = {0},", Precision));
            sb.Append(string.Format("Scale = {0},", Scale));
            sb.Append(string.Format("Nullable = {0},", Nullable));
            sb.Append(string.Format("IsPrimaryKey = {0},", IsPrimaryKey));
            sb.Append(string.Format("IsIdentity = {0},", IsIdentity));
            sb.Append(string.Format("IdentitySeed = {0},", IdentitySeed));
            sb.Append(string.Format("IdentityIncrement = {0},", IdentityIncrement));
            sb.Append(string.Format("DefaultValue = {0},", DefaultValue??"NULL"));
                        
            return sb.ToString();
        }

        public string ToDBString()
        {
            StringBuilder sb=new StringBuilder();
            sb.Append(string.Format("{0} ",Name));
            sb.Append(string.Format("{0} ",GetColumnTypeDesc()));           

            if (IsIdentity)
            {
                sb.Append(string.Format("IDENTITY({0},{1}) ", IdentitySeed, IdentityIncrement));
            }

            sb.Append(Nullable ? "NULL " : "NOT NULL ");

            if (!string.IsNullOrEmpty(DefaultValue))
            {
                sb.Append(string.Format("DEFAULT {0} ", DefaultValue));
            }

            return sb.ToString();
        }
    }
}
