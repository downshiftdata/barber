using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace barber.Pages.Database
{
    public class ListModel : PageModel
    {
        private readonly Data.Repositories.IReadRepository _ReadRepository;

        public System.Collections.Generic.IEnumerable<Data.Models.DatabaseResponse> Databases { get; set; }

        public ListModel(Data.Repositories.IReadRepository readRepository)
        {
            _ReadRepository = readRepository;
            Databases = new System.Collections.Generic.List<Data.Models.DatabaseResponse>();
        }

        public async System.Threading.Tasks.Task<IActionResult> OnGetAsync()
        {
            Databases = await _ReadRepository.SelectDatabases();
            return Page();
        }
    }
}