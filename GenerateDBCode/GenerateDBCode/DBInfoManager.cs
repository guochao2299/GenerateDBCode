using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateDBCode
{
    internal class DBInfoManager
    {
        private DBInfoManager()
        { }

        private static DBInfoManager m_manager = null;
        private static DBInfoManager Instance
        {
            get
            {
                if (m_manager == null)
                {
                    m_manager = new DBInfoManager();
                }

                return m_manager;
            }
        }

        private Dictionary<string, MyDatabase> m_dbs = new Dictionary<string, MyDatabase>();


    }
}
