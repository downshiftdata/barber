namespace barber.Data.Models
{
    public class UserRequest : IRequestModel
    {
        public UserRequest() { }

        public UserRequest(UserResponse response)
        {
            UserName = response.UserName;
            PasswordHash = response.PasswordHash;
            IsAdmin = response.IsAdmin;
            IsEditor = response.IsEditor;
            IsApprover = response.IsApprover;
            IsExecutor = response.IsExecutor;
        }

        public string EditByUserName { get; set; } = string.Empty;

        public bool IsAdmin { get; set; } = false;

        public bool IsApprover { get; set; } = false;

        public bool IsEditor { get; set; } = false;

        public bool IsExecutor { get; set; } = false;

        public string PasswordHash { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

    }
}