using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensions.Msal;
using MusicShop.Data;
using MusicShop.Models;

namespace MusicShop.Services
{
    public class DbService : IDbService
    {
        private readonly ProjektContext _context;
        public DbService(ProjektContext context)
        {
            _context = context;
        }
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

        async Task IDbService.AddNewRecord(Record record)
        {
            _context.Records.AddAsync(record);
            _context.SaveChangesAsync();
        }

        async Task IDbService.AddNewStorage(Models.Storage storage)
        {
            _context.Storages.AddAsync(storage);
            _context.SaveChangesAsync();
        }

        async Task IDbService.DeleteRecord(int id)
        {
            var record = await _context.Records.FirstOrDefaultAsync(r => r.Id == id);

            _context.Records.Remove(record);
            await _context.SaveChangesAsync();

        }

        async Task IDbService.DeleteStorage(int id)
        {
            var storage = await _context.Storages.FirstOrDefaultAsync(r => r.Id == id);

            _context.Storages.Remove(storage);
            await _context.SaveChangesAsync();
        }

        async Task<bool> IDbService.DoesRecordExist(int id)
        {
            return await _context.Records.AnyAsync(e => e.Id == id);
        }


        async Task<bool> IDbService.DoesStorageExist(int id)
        {
            return await _context.Storages.AnyAsync(e => e.Id == id);
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

        async Task IDbService.UpdateRecord(Record record)
        {
            _context.Update(record);
            await _context.SaveChangesAsync();
        }
    }
}
