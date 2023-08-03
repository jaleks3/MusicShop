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
        public async Task<IEnumerable<Record>> GetRecords()
        {
           return await _context.Records.ToListAsync();
        }
    }
}
