using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actio.Common.Mongo
{
    public class MongoInitializer : IDatabaseInitializer
    {
        private bool _initialized;
        private bool _seed;
        private readonly IMongoDatabase _database;
        private readonly IDatabaseSeeder _seeder;

        public MongoInitializer(IMongoDatabase database,
            IDatabaseSeeder seeder,
            IOptions<MongoOptions> options)
        {
            _database = database;
            _seeder = seeder;
            _seed = options.Value.Seed;
        }

        public async Task InitializeAsync()
        {
            if (_initialized)
            {
                return;
            }
            RegisterConvetions();
            _initialized = true;
            if (!_seed)
            {
                return;
            }
            await _seeder.SeedAsync();
        }

        private void RegisterConvetions()
        {
            ConventionRegistry.Register("ActionConventions", new MongoConvention(), x => true);
        }

        private class MongoConvention : IConventionPack
        {
            public IEnumerable<IConvention> Conventions => new List<IConvention>
            {
                new IgnoreExtraElementsConvention(true),
                new EnumRepresentationConvention(MongoDB.Bson.BsonType.String),
                new CamelCaseElementNameConvention()
            };
        }
    }
}
