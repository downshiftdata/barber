using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace barber.Pages.Database
{
    public class AddModel : PageModel
    {
        private readonly Data.Repositories.IWriteRepository _WriteRepository;

        [BindProperty]
        public Data.Models.DatabaseRequest Database { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        public AddModel(Data.Repositories.IWriteRepository writeRepository)
        {
            _WriteRepository = writeRepository;
        }

        public async System.Threading.Tasks.Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Database == null)
            {
                return Page();
            }

            Database.EditByUserName = "default";
            var result = await _WriteRepository.InsertDatabase(Database);

            return RedirectToPage("./List");
        }
    }
}