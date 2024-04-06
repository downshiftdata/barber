namespace barber.Data.Repositories
{
    public interface IWriteRepository
    {
        System.Threading.Tasks.Task<Data.Models.WriteResult> ApproveStatement(Data.Models.StatementRequest request);

        System.Threading.Tasks.Task<Data.Models.WriteResult> InsertDatabase(Data.Models.DatabaseRequest request);

        System.Threading.Tasks.Task<Data.Models.WriteResult> InsertExecution(Data.Models.ExecutionRequest request);

        System.Threading.Tasks.Task<Data.Models.WriteResult> InsertStatement(Data.Models.StatementRequest request);

        System.Threading.Tasks.Task<Data.Models.WriteResult> InsertUser(Data.Models.UserRequest request);

        System.Threading.Tasks.Task<Data.Models.WriteResult> UpdateDatabase(Data.Models.DatabaseRequest request);

        System.Threading.Tasks.Task<Data.Models.WriteResult> UpdateStatement(Data.Models.StatementRequest request);

        System.Threading.Tasks.Task<Data.Models.WriteResult> UpdateUser(Data.Models.UserRequest request);
    }
}