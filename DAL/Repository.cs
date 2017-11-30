using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal static class Repository
    {

        internal enum Instance
        {
            /// <summary>
            /// Primary read/write DB.
            /// </summary>
            Primary,
            /// <summary>
            /// Crawlers read-only DB.
            /// </summary>
            Crawlers,
            /// <summary>
            /// Read-only DB.
            /// </summary>
            ReadOnly,
            /// <summary>
            /// Read-only 2 DB. WTH is this?
            /// </summary>
            ReadOnly2,
            /// <summary>
            /// Logging DB.
            /// </summary>
            Logging
        }


        public static DbConnection GetConnection(Instance dc = Instance.Primary)
        {
            var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");

            var connection = factory.CreateConnection();

            if (connection == null)
                return null;

            connection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString." + dc].ConnectionString;

            return connection;
        }
    }
}
