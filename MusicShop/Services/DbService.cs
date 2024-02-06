using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensions.Msal;
using MusicShop.Data;
using MusicShop.Models;
using MusicShop.Models.DTOs;

namespace MusicShop.Services
{
    public class DbService : IDbService
    {
        private readonly ProjektContext _context;
        public DbService(ProjektContext context)
        {
            _context = context;
        }
        //records
        public async Task<ICollection<Record>> GetRecords()
        {
            return await _context.Records
                .Include(r => r.TypeOfRecord)
                .Include(r => r.Distributor)
                .Include(r => r.Artists)
                .Include(r => r.Genres)
                .Include(r => r.RecordStorages)
                .ToListAsync();
        }

        async Task<Record?> IDbService.GetRecord(int id)
        {
            return await _context.Records
                .Include(r => r.TypeOfRecord)
                .Include(r => r.Distributor)
                .Include(r => r.Artists)
                .Include(r => r.Genres)
                .Include(r => r.RecordStorages)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        async Task<ICollection<Record>?> IDbService.GetRecordsByArtistId(int id)
        {
            return await _context.Records
               .Include(r => r.TypeOfRecord)
               .Include(r => r.Distributor)
               .Include(r => r.Artists)
               .Include(r => r.Genres)
               .Include(r => r.RecordStorages)
               .Where(r => r.Artists.Any(a => a.Id == id))
               .ToListAsync();
        }

        async Task<ICollection<Record>?> IDbService.GetRecordsByArtistName(string name)
        {
            return await _context.Records
                .Include(r => r.TypeOfRecord)
                .Include(r => r.Distributor)
                .Include(r => r.Artists)
                .Include(r => r.Genres)
                .Include(r => r.RecordStorages)
                .Where(r => r.Artists.Any(a => EF.Functions.Like(a.Name, $"%{name}%")))
                .ToListAsync();
        }

        async Task<ICollection<Record>?> IDbService.GetRecordsByName(string name)
        {
            return await _context.Records
                .Include(r => r.TypeOfRecord)
                .Include(r => r.Distributor)
                .Include(r => r.Artists)
                .Include(r => r.Genres)
                .Include(r => r.RecordStorages)
                .Where(r => EF.Functions.Like(r.Name, $"%{name}%"))
                .ToListAsync();
        }
        async Task IDbService.UpdateRecord(Record record)
        {
            _context.Update(record);
            await _context.SaveChangesAsync();
        }
        async Task IDbService.AddNewRecord(Record record)
        {
            _context.Records.AddAsync(record);
            _context.SaveChangesAsync();
        }
        async Task IDbService.DeleteRecord(int id)
        {
            var record = await _context.Records.FirstOrDefaultAsync(r => r.Id == id);

            _context.Records.Remove(record);
            await _context.SaveChangesAsync();

        }
        async Task<bool> IDbService.DoesRecordExist(int id)
        {
            return await _context.Records.AnyAsync(e => e.Id == id);
        }


        //artists
        async Task IDbService.AddNewArtist(Artist artist)
        {
            throw new NotImplementedException();
        }
        async Task IDbService.DeleteArtist(int id)
        {
            throw new NotImplementedException();
        }
        async Task<bool> IDbService.DoesArtistExist(int id)
        {
            return await _context.Artists.AnyAsync(e => e.Id == id);
        }
        async Task<Artist> IDbService.GetArtist(int id)
        {
            return _context.Artists.FirstOrDefault(e => e.Id == id);
        }
        async Task IDbService.UpdateArtist(AddArtistDTO artistDto)
        {
            throw new NotImplementedException();
        }
        //storages
        async Task IDbService.AddNewStorage(Models.Storage storage)
        {
            _context.Storages.AddAsync(storage);
            _context.SaveChangesAsync();
        }
        async Task IDbService.DeleteStorage(int id)
        {
            var storage = await _context.Storages.FirstOrDefaultAsync(r => r.Id == id);

            _context.Storages.Remove(storage);
            await _context.SaveChangesAsync();
        }
        async Task<Models.Storage> IDbService.GetStorage(int id)
        {
            return await _context.Storages
                .Include(r => r.RecordStorages)
                .ThenInclude(rs => rs.Storage)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        async Task<ICollection<Models.Storage>> IDbService.GetStorages()
        {
            return await _context.Storages
                .Include(r => r.RecordStorages)
                .ThenInclude(rs => rs.Storage)
                .ToListAsync();
        }

        async Task<int> IDbService.QuantityOfRecordsInStock(int id)
        {
            return await _context.RecordStorages
                .Where(rs => rs.RecordId == id)
                .SumAsync(rs => rs.Quantity);
        }
        async Task<bool> IDbService.DoesStorageExist(int id)
        {
            return await _context.Storages.AnyAsync(e => e.Id == id);
        }

        Task IDbService.UpdateArtist(Artist artist)
        {
            throw new NotImplementedException();
        }
        //distributor
        async Task<Models.Distributor> IDbService.GetDistributor(int id)
        {
            return await _context.Distributors.FirstOrDefaultAsync(e => e.Id == id);
        }
        async Task<bool> IDbService.DoesDistributorExist(int id)
        {
            return await (_context.Distributors.AnyAsync(e => e.Id == id));
        }
        //Type of record
        async Task<TypeOfRecord> IDbService.GetTypeOfRecord(int id)
        {
            return await _context.TypeOfRecords.FirstOrDefaultAsync(e => e.Id == id);
        }

        async Task<bool> IDbService.DoesTypeOfRecordExist(int id)
        {
            return await _context.TypeOfRecords.AnyAsync(e => e.Id == id);
        }
        //record storages
        async Task<ICollection<RecordStorage>> IDbService.GetRecordStoragesByRecordId(int id)
        {
            return await _context.RecordStorages
                .Include(e => e.RecordId)
                .Include(e => e.StorageId)
                .Include(e => e.Record)
                .Include(e => e.Storage)
                .Include(e => e.Quantity)
                .Where(e => e.RecordId == id)
                .ToListAsync();
        }

        //record orders
        async Task<ICollection<OrderRecord>> IDbService.GetOrderRecordsByRecordId(int id)
        {
            return await _context.OrderRecords
                .Include(e => e.RecordId)
                .Include(e => e.Record)
                .Include(e => e.OrderId)
                .Include(e => e.Order)
                .Include(e => e.Quantity)
                .Where(e => e.RecordId == id)
                .ToListAsync();
        }
    }
}
