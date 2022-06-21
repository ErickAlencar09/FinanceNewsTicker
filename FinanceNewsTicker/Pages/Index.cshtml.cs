using FinanceNewsTicker.Models;
using FinanceNewsTicker.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceNewsTicker.Pages
{
    public class IndexModel : PageModel
    {
        public FinanceNews news;
        private readonly ILogger<IndexModel> _logger;
        private readonly INewsService _newsService;

        public IndexModel(ILogger<IndexModel> logger, INewsService newsService)
        {
            _logger = logger;
            _newsService = newsService;
        }

        public void OnGet()
        {
           news = _newsService.GetFinanceNews();

        }
    }
}