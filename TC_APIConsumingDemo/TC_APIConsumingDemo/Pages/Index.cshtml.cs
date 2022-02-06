using APIConsumeLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TC_APIConsumingDemo.Pages
{
    public class IndexModel : PageModel
    {
        public Uri UriSource { get; set; }
        public int MaxNumber { get; set; } = 0;
        public int CurrentNumber { get; set; } = 0;
        public ComicModel Comic { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGetAsync(int number = 0)
        {
            CurrentNumber = number;
            ApiHelper.InitializeClient();
            await LoadImage(CurrentNumber);
        }

        private async Task LoadImage(int imageNumber = 0)
        {
            Comic = await ComicProcessor.LoadComic(imageNumber);

            if (imageNumber == 0)
            {
                MaxNumber = Comic.Num;
                HttpContext.Session.SetInt32("MaxNumber", MaxNumber);
            }
            else
            {
                MaxNumber = HttpContext.Session.GetInt32("MaxNumber") ?? Comic.Num;
            }

            CurrentNumber = Comic.Num;
            UriSource = new Uri(Comic.Img, UriKind.Absolute);
        }
    }
}