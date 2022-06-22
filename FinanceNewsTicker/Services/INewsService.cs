using FinanceNewsTicker.Models;

namespace FinanceNewsTicker.Services
{
    public interface INewsService
    {
        FinanceNews GetFinanceNews(int offset);
    }
}
