using WorkPoint_WebApp.Shared.DataTransferObjects;
using WorkPoint_WebApp.Shared.Parameters;

namespace WorkPoint_WebApp.Service.Contract
{
    public interface INewsService
    {
        public Task<PagedList<NewsReturnDto>> GetNewsListAsync(NewsParameters newsParam);
        public Task<NewsReturnDto> GetNewsAsync(Guid id);
        public Task<bool> UpdateNewsAsync(Guid id, NewsDto newsDto);
        public Task<bool> CreateNewsAsync(NewsDto newsDto);


    }
}
