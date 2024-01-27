using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace barber.Pages.Statement
{
    public class ApproveModel : PageModel
    {
        private readonly Data.Repositories.IReadRepository _ReadRepository;
        private readonly Data.Repositories.IWriteRepository _WriteRepository;

        [BindProperty]
        public Data.Models.StatementRequest Statement { get; set; } = default!;

        public async System.Threading.Tasks.Task<IActionResult> OnGetAsync([FromRoute] long key)
        {
            var response = await _ReadRepository.SelectStatementByKey(key);
            Statement = new Data.Models.StatementRequest(response);
            return Page();
        }

        public ApproveModel(Data.Repositories.IReadRepository readRepository, Data.Repositories.IWriteRepository writeRepository)
        {
            _ReadRepository = readRepository;
            _WriteRepository = writeRepository;
        }

        public async System.Threading.Tasks.Task<IActionResult> OnPostAsync([FromRoute] long key)
        {
            if (!ModelState.IsValid || Statement == null)
            {
                return Page();
            }

            Statement.StatementKey = key;
            Statement.ApproveByUserName = "default";
            var result = await _WriteRepository.ApproveStatement(Statement);

            return RedirectToPage("./List");
        }
    }
}