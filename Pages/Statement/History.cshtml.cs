using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace barber.Pages.Statement
{
    public class HistoryModel : PageModel
    {
        private readonly Data.Repositories.IReadRepository _ReadRepository;

        public System.Collections.Generic.IEnumerable<Data.Models.StatementResponse> Revisions { get; set; }

        public HistoryModel(Data.Repositories.IReadRepository readRepository)
        {
            _ReadRepository = readRepository;
            Revisions = new System.Collections.Generic.List<Data.Models.StatementResponse>();
        }

        public async System.Threading.Tasks.Task<IActionResult> OnGetAsync([FromRoute] long key)
        {
            Revisions = await _ReadRepository.SelectStatementHistory(key);
            return Page();
        }
    }
}