using System.Data;

namespace perpusapi.DatabaseLib
{
    public class DatabaseConnection 
    {
        public DatabaseConnection(IDbConnection connection)
        {
            this.connection = connection;
        }

        internal IDbConnection connection { get; }
    }

}