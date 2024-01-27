using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace barber.Pages.Database
{
    public class EditModel : PageModel
    {
        private readonly Data.Repositories.IReadRepository _ReadRepository;
        private readonly Data.Repositories.IWriteRepository _WriteRepository;

        [BindProperty]
        public Data.Models.DatabaseRequest Database { get; set; } = default!;

        public async System.Threading.Tasks.Task<IActionResult> OnGetAsync([FromRoute] long key)
        {
            var response = await _ReadRepository.SelectDatabaseByKey(key);
            Database = new Data.Models.DatabaseRequest(response);
            return Page();
        }

        public EditModel(Data.Repositories.IReadRepository readRepository, Data.Repositories.IWriteRepository writeRepository)
        {
            _ReadRepository = readRepository;
            _WriteRepository = writeRepository;
        }

        public async System.Threading.Tasks.Task<IActionResult> OnPostAsync([FromRoute] long key)
        {
            if (!ModelState.IsValid || Database == null)
            {
                return Page();
            }

            Database.DatabaseKey = key;
            Database.EditByUserName = "default";
            var result = await _WriteRepository.UpdateDatabase(Database);

            return RedirectToPage("./List");
        }
    }
}