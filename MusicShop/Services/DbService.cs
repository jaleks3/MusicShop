﻿using Microsoft.EntityFrameworkCore;
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
            var existingEntity = _context.Records.Find(record.Id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).State = EntityState.Detached;
            }
            _context.Update(record);
            await _context.SaveChangesAsync();
        }

        async Task IDbService.AddNewRecord(Record record)
        {
            await _context.Records.AddAsync(record);
            await _context.SaveChangesAsync();
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
        async Task<ICollection<Artist>> IDbService.GetArtists()
        {
            return await _context.Artists.ToListAsync();
        }
        async Task IDbService.AddNewArtist(Artist artist)
        {
            await _context.Artists.AddAsync(artist);
            await _context.SaveChangesAsync();
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
            return _context.Artists
                .Include(e => e.Records)
                .FirstOrDefault(e => e.Id == id);
        }
        async Task IDbService.UpdateArtist(Artist artist)
        {
            var oldArtist = _context.Artists.Find(artist.Id);
            
            _context.Entry(oldArtist).CurrentValues.SetValues(artist);
            await _context.SaveChangesAsync();
        }
        //storages
        async Task IDbService.AddNewStorage(Models.Storage storage)
        {
            await _context.Storages.AddAsync(storage);
            await _context.SaveChangesAsync();
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

        
        async Task<bool> IDbService.DoesStorageExist(int id)
        {
            return await _context.Storages.AnyAsync(e => e.Id == id);
        }
        //distributor
        async Task<Models.Distributor> IDbService.GetDistributor(int id)
        {
            return await _context.Distributors
                .Include(e => e.Records)
                .FirstOrDefaultAsync(e => e.Id == id);
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
        async Task<int> IDbService.QuantityOfRecordsInStock(int id)
        {
            return await _context.RecordStorages
                .Where(rs => rs.RecordId == id)
                .SumAsync(rs => rs.Quantity);
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
        //genre
        async Task<bool> IDbService.DoesGenreExist(int id)
        {
            return await _context.Genres.AnyAsync(r => r.Id == id);
        }
        async Task<Genre> IDbService.GetGenre(int id)
        {
            return await _context.Genres.FirstOrDefaultAsync(r => r.Id == id);
        }
        //customer
        async Task<bool> IDbService.DoesCustomerExist(int id)
        {
            return await _context.Customers.AnyAsync(r => r.Id == id);
        }

        async Task<Customer> IDbService.GetCustomer(int id)
        {
            return await _context.Customers
                .Include(e => e.Address)
                .Include(e => e.Discount)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        async Task IDbService.CreateCustomer(Customer customer)
        {
            await _context.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        async Task IDbService.DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(r => r.Id == id);

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        async Task IDbService.UpdateCustomer(Customer customer)
        {
            var oldCustomer = _context.Customers.Find(customer.Id);
            
            _context.Entry(oldCustomer).CurrentValues.SetValues(customer);
            await _context.SaveChangesAsync();
        }
        //orders
        async Task<bool> IDbService.DoesOrderExist(int id)
        {
            return await _context.Orders.AnyAsync(r => r.Id == id);
        }

        async Task<Order> IDbService.GetOrder(int id)
        {
            return await _context.Orders
                .Include(e => e.Address)
                .Include(e => e.Status)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        async Task IDbService.UpdateOrder(Order order)
        {
            var oldOrder = _context.Orders.Find(order.Id);

            _context.Entry(oldOrder).CurrentValues.SetValues(order);
            await _context.SaveChangesAsync();
        }

        async Task IDbService.DeleteOrder(int id)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(e => e.Id == id);

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        async Task<ICollection<Order>> IDbService.GetOrders()
        {
            return await _context.Orders
                .Include(e => e.Address)
                .Include(e => e.Status)
                .ToListAsync();
        }

        async Task IDbService.CreateOrder(Order order)
        {
            await _context.AddAsync(order);
            await _context.SaveChangesAsync();
        }
    }
}
