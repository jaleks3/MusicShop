using Microsoft.EntityFrameworkCore;
using MusicShop.Data;
using MusicShop.Models;

namespace MusicShop.Services
{
    public class RecordsService : IRecordsService
    {
        private readonly ProjektContext _context;
        public RecordsService(ProjektContext context)
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
    }
}
