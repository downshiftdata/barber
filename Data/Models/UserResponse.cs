using barber.Data.Extensions;

namespace barber.Data.Models
{
    public class UserResponse : IResponseModel
    {
        static internal UserResponse Load(object[] values)
        {
            return new UserResponse(values);
        }

        public UserResponse(object[] values)
        {
            UserName = (string)values[0];
            Revision = (int)values[1];
            EditByUserName = (string)values[2];
            EditDateTime = (System.DateTime)values[3];
            PasswordHash = (string)values[4];
            IsAdmin = (bool)values[5];
            IsEditor = (bool)values[6];
            IsApprover = (bool)values[7];
            IsExecutor = (bool)values[8];
            AllowCustom = (bool)values[9];
        }

        public bool AllowCustom { get; }

        public string EditByUserName { get; }

        public System.DateTime EditDateTime { get; }

        public bool IsAdmin { get; }

        public bool IsApprover { get; }

        public bool IsEditor { get; }

        public bool IsExecutor { get; }

        public string PasswordHash { get; }

        public int Revision { get; }

        public string UserName { get; }
    }
}