namespace Infrastructure.Interfaces
{
    public interface IDatabaseConnection
    {
        string connectionString { get; set; }
        string databaseName { get; set; }
        string tableName { get; set; }
    }
}