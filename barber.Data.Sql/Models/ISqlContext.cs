namespace barber.Data.Sql.Models
{
    public interface ISqlContext
    {
        System.Data.IDbConnection GetConnection();
    }
}