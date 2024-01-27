using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace barber.Pages.Statement
{
    public class EditModel : PageModel
    {
        private readonly Data.Repositories.IReadRepository _ReadRepository;
        private readonly Data.Repositories.IWriteRepository _WriteRepository;

        public System.Collections.Generic.IEnumerable<SelectListItem> Databases { get; set; } = default!;

        [BindProperty]
        public Data.Models.StatementRequest Statement { get; set; } = default!;

        public async System.Threading.Tasks.Task<IActionResult> OnGetAsync([FromRoute] long key)
        {
            var response = await _ReadRepository.SelectStatementByKey(key);
            Statement = new Data.Models.StatementRequest(response);
            var list = await _ReadRepository.SelectDatabaseList();
            Databases = list.Select(i => new SelectListItem {Value = i.ItemKey.ToString(), Text = i.ItemText} ).ToList();
            return Page();
        }

        public EditModel(Data.Repositories.IReadRepository readRepository, Data.Repositories.IWriteRepository writeRepository)
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
            Statement.EditByUserName = "default";
            var result = await _WriteRepository.UpdateStatement(Statement);

            return RedirectToPage("./List");
        }
    }
}