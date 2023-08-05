using MusicShop.Models;

namespace MusicShop.Services
{
    public interface IDbService
    {
        public Task<ICollection<Record>> GetRecords();
        public Task<bool> DoesRecordExist(int id);
        public Task<Record?> GetRecord(int id);
        public Task AddNewRecord(Record record);
        public Task DeleteRecord(int id);
        public Task UpdateRecord(Record record);
        public Task<ICollection<Record>?> GetRecordsByArtistName(string name);
        public Task<ICollection<Record>?> GetRecordsByArtistId(int id);
        public Task<ICollection<Record>?> GetRecordsByName(string name);
        public Task<ICollection<Storage>> GetStorages();
        public Task<Storage> GetStorage(int id);
        public Task AddNewStorage(Storage storage);
        public Task DeleteStorage(int id);
        public Task<bool> DoesStorageExist(int id);
        public Task<int> QuantityOfRecordsInStock(int id);
    }
}
