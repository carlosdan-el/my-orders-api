namespace Infrastructure.Interfaces
{
    public interface ISqlServerConnection
    {
        string DataSource { get; set; }
        string UserId { get; set; }
        string Password { get; set; }
        string DataBase { get; set; }
    }
}