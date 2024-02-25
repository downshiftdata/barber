using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace barber.Pages
{
    public class ExecuteModel : PageModel
    {
        private readonly Data.Repositories.IReadRepository _ReadRepository;
        private readonly Data.Repositories.IWriteRepository _WriteRepository;

        public System.Collections.Generic.IEnumerable<SelectListItem> Databases { get; set; } = default!;
        public System.Collections.Generic.IEnumerable<SelectListItem> Statements { get; set; } = default!;

        [BindProperty(Name = "databaseKey")]
        public long? DatabaseKey { get; set; }

        [BindProperty(Name = "statementKey")]
        public long? StatementKey { get; set; }

        public async System.Threading.Tasks.Task<IActionResult> OnGetAsync()
        {
            var list1 = await _ReadRepository.SelectApprovedStatementList();
            Statements = list1.Select(i => new SelectListItem {Value = i.ItemKey.ToString(), Text = i.ItemText} ).ToList();
            var list2 = await _ReadRepository.SelectDatabaseList();
            Databases = list2.Select(i => new SelectListItem {Value = i.ItemKey.ToString(), Text = i.ItemText} ).ToList();
            return Page();
        }

        public ExecuteModel(Data.Repositories.IReadRepository readRepository, Data.Repositories.IWriteRepository writeRepository)
        {
            _ReadRepository = readRepository;
            _WriteRepository = writeRepository;
        }

        public async System.Threading.Tasks.Task<IActionResult> OnPostAsync()
        {
            if (StatementKey == null || DatabaseKey == null || !ModelState.IsValid)
            {
                return Page();
            }

            // TODO: Load and Verify
            var now = System.DateTime.UtcNow;
            var rowCount = 0;
            // TODO: Actually do the work.
            var request = new Data.Models.ExecutionRequest()
            {
                StatementKey = (long)StatementKey,
                ExecuteByUserName = "default",
                DatabaseKey = (long)DatabaseKey,
                ExecuteMs = (long)System.DateTime.UtcNow.Subtract(now).TotalMilliseconds,
                RowCount = rowCount
            };
            var result = await _WriteRepository.InsertExecution(request);

            return RedirectToPage("./Index");
        }
    }
}