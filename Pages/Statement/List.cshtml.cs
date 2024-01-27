using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace barber.Pages.Statement
{
    public class ListModel : PageModel
    {
        private readonly Data.Repositories.IReadRepository _ReadRepository;

        public System.Collections.Generic.IEnumerable<Data.Models.StatementResponse> Statements { get; set; }

        public ListModel(Data.Repositories.IReadRepository readRepository)
        {
            _ReadRepository = readRepository;
            Statements = new System.Collections.Generic.List<Data.Models.StatementResponse>();
        }

        public async System.Threading.Tasks.Task<IActionResult> OnGetAsync()
        {
            Statements = await _ReadRepository.SelectStatements();
            return Page();
        }
    }
}