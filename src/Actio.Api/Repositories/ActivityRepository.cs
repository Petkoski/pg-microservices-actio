using Actio.Api.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.Api.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly IMongoDatabase _database;

        public ActivityRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<Activity> GetAsync(Guid id)
            => await Collection
                .AsQueryable()
                .FirstOrDefaultAsync(c => c.Id == id);

        public async Task AddAsync(Activity activity)
            => await Collection.InsertOneAsync(activity);

        public async Task<IEnumerable<Activity>> BrowseAsync(Guid userId)
            => await Collection
                .AsQueryable()
                .Where(c => c.UserId == userId)
                .ToListAsync();

        private IMongoCollection<Activity> Collection
            => _database.GetCollection<Activity>("Activities");
    }
}
