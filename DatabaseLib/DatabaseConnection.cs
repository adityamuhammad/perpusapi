using System.Data;

namespace perpusapi.DatabaseLib
{
    public class DatabaseConnection {
        public DatabaseConnection(IDbConnection dbConnection){
            this.dbConnection = dbConnection;
        }

        internal IDbConnection dbConnection {get;}
    }

}