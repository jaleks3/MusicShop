using MusicShop.Models;
using MusicShop.Models.DTOs;

namespace MusicShop.Services
{
    public interface IDbService
    {
        //records
        public Task<ICollection<Record>> GetRecords();
        public Task<bool> DoesRecordExist(int id);
        public Task<Record?> GetRecord(int id);
        public Task AddNewRecord(Record record);
        public Task DeleteRecord(int id);
        public Task UpdateRecord(Record record);
        public Task<ICollection<Record>?> GetRecordsByArtistName(string name);
        public Task<ICollection<Record>?> GetRecordsByArtistId(int id);
        public Task<ICollection<Record>?> GetRecordsByName(string name);
        //storages
        public Task AddNewStorage(Storage storage);
        public Task DeleteStorage(int id);
        
        public Task<ICollection<Storage>> GetStorages();
        public Task<Storage> GetStorage(int id);
        public Task<bool> DoesStorageExist(int id);
        public Task<int> QuantityOfRecordsInStock(int id);
        //artists
        public Task AddNewArtist(Artist artist);
        public Task DeleteArtist(int id);
        public Task<Artist> GetArtist(int id);
        public Task UpdateArtist(Artist artist);
        public Task<bool> DoesArtistExist(int id);
        public Task UpdateArtist(AddArtistDTO artistDto);
        //Distributor
        public Task<Distributor> GetDistributor(int id);
        public Task<bool> DoesDistributorExist(int id);
        //Type of record
        public Task<TypeOfRecord> GetTypeOfRecord(int id);
        public Task<bool> DoesTypeOfRecordExist(int id);
        //record storages
        public Task<ICollection<RecordStorage>> GetRecordStoragesByRecordId(int id);
        //order records
        public Task<ICollection<OrderRecord>> GetOrderRecordsByRecordId(int id);
    }
}
