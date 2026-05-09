using FineTuningDemoCSharp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineTuningDemoCSharp.Pages
{
    public class IndexModel : PageModel
    {
        ChatService _service;
        [BindProperty]
        public string usermessage { get; set; }
        public string airesponse { get; set; }
        public IndexModel(ChatService service)
        {
            _service = service;
        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            airesponse = await _service.ChatWithAI(usermessage);
            return Page();
        }
    }
}
