using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace barber.Pages.Statement
{
    public class ValidateModel : PageModel
    {
        private readonly Data.Repositories.IExecuteRepository _ExecuteRepository;
        private readonly Data.Repositories.IReadRepository _ReadRepository;

        [BindProperty]
        public string Results { get; set; } = default!;

        [BindProperty]
        public Data.Models.StatementRequest Statement { get; set; } = default!;

        public async System.Threading.Tasks.Task<IActionResult> OnGetAsync([FromRoute] long key)
        {
            var response = await _ReadRepository.SelectStatementByKey(key);
            Statement = new Data.Models.StatementRequest(response);
            return Page();
        }

        public ValidateModel(Data.Repositories.IReadRepository readRepository, Data.Repositories.IExecuteRepository executeRepository)
        {
            _ReadRepository = readRepository;
            _ExecuteRepository = executeRepository;
        }

        public async System.Threading.Tasks.Task<IActionResult> OnPostAsync([FromRoute] long key)
        {
            if (!ModelState.IsValid || Statement == null)
            {
                return Page();
            }

            var database = await _ReadRepository.SelectDatabaseByKey(Statement.CheckDatabaseKey);
            var options = new Data.Models.ConnectionOptions(database.ServerName, database.DatabaseName, database.UserName, database.PasswordHash);
            var result = _ExecuteRepository.ValidateStatement(Statement.StatementText, options);
            Results = string.Format("Success:{0},RowCount:{1},Exception:{2}", result.IsSuccessful, result.RowCount, result.Exception is null ? "(None)" : result.Exception.ToString());

            return Page();
        }
    }
}