using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace barber.Pages.Statement
{
    public class AddModel : PageModel
    {
        private readonly Data.Repositories.IReadRepository _ReadRepository;
        private readonly Data.Repositories.IWriteRepository _WriteRepository;

        public System.Collections.Generic.IEnumerable<SelectListItem> Databases { get; set; } = default!;

        [BindProperty]
        public Data.Models.StatementRequest Statement { get; set; } = default!;

        public async System.Threading.Tasks.Task<IActionResult> OnGetAsync()
        {
            var list = await _ReadRepository.SelectDatabaseList();
            Databases = list.Select(i => new SelectListItem {Value = i.ItemKey.ToString(), Text = i.ItemText} ).ToList();
            return Page();
        }

        public AddModel(Data.Repositories.IReadRepository readRepository, Data.Repositories.IWriteRepository writeRepository)
        {
            _ReadRepository = readRepository;
            _WriteRepository = writeRepository;
        }

        public async System.Threading.Tasks.Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Statement == null)
            {
                return Page();
            }

            Statement.EditByUserName = "default";
            var result = await _WriteRepository.InsertStatement(Statement);

            return RedirectToPage("./List");
        }
    }
}