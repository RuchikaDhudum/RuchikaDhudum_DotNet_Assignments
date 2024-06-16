namespace EmployeeManagementSystemAssignment_Ruchika.Common
{
    public class Credentials
    {
        public static readonly string DataBaseName = Environment.GetEnvironmentVariable("dataBaseName");
        public static readonly string ContainerName = Environment.GetEnvironmentVariable("containerName");
        public static readonly string CosmosEndPoint = Environment.GetEnvironmentVariable("cosmosUrl");
        public static readonly string PrimaryKey = Environment.GetEnvironmentVariable("primarykey");
    }
}
