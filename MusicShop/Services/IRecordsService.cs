using MusicShop.Models;

namespace MusicShop.Services
{
    public interface IRecordsService
    {
        public Task<IEnumerable<Record>> GetRecords();
    }
}
