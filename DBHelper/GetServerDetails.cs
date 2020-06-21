using DBHelper;

namespace DBHelper
{
    public static class GetServerDetails
    {
        public static string connectionString => DBDetails.Default.connectionString;

        public static string providerName => DBDetails.Default.providerName;
    }
}
