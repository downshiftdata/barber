namespace barber.Data.Models
{
    public interface ISqlContext
    {
        System.Data.IDbConnection GetConnection();
    }
}