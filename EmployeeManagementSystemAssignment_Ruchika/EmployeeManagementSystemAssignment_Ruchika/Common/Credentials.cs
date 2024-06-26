namespace EmployeeManagementSystemAssignment_Ruchika.Common
{
    public class Credentials
    {
        public static readonly string DataBaseName = Environment.GetEnvironmentVariable("dataBaseName");
        public static readonly string ContainerName = Environment.GetEnvironmentVariable("containerName");
        public static readonly string CosmosEndPoint = Environment.GetEnvironmentVariable("cosmosUrl");
        public static readonly string PrimaryKey = Environment.GetEnvironmentVariable("primarykey");
        public static readonly string VisitorUrl = Environment.GetEnvironmentVariable("visitorUrl");
        public static readonly string AddVisitorEndPoint = "/api/VisitorSecuritySystem/AddVisitor";
        public static readonly string GetVisitorEndPoint = "/api/VisitorSecuritySystem/GetAllVisitors";
    }
}
