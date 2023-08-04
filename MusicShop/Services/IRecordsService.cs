using MusicShop.Models;

namespace MusicShop.Services
{
    public interface IRecordsService
    {
        public Task<ICollection<Record>> GetRecords();
    }
}
