using System;
using System.Threading.Tasks;
using LiteDB;
using NEvilES;
using NEvilES.Pipeline;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EFDemo1.Common
{
    public class LocalEventStore : IAsyncRepository
    {
        private readonly LiteDatabase _db;
        private readonly IEventTypeLookupStrategy _eventTypeLookupStrategy;
        private readonly CommandContext _commandContext;
        public LocalEventStore(
            LiteDatabase db,
            IEventTypeLookupStrategy eventTypeLookupStrategy,
            CommandContext commandContext
            )
        {
            _db = db;
            _eventTypeLookupStrategy = eventTypeLookupStrategy;
            _commandContext = commandContext;
        }
        private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            DefaultValueHandling = DefaultValueHandling.Populate,
            NullValueHandling = NullValueHandling.Ignore,
            TypeNameHandling = TypeNameHandling.Auto,
            Converters = new JsonConverter[] { new StringEnumConverter() }
        };
        public async Task<TAggregate> GetAsync<TAggregate>(Guid id) where TAggregate : IAggregate
        {
            IAggregate aggregate = await GetAsync(typeof(TAggregate), id);
            return (TAggregate)aggregate;
        }
        public Task<IAggregate> GetAsync(Type type, Guid id) => GetAsync(type, id, null);

        public async Task<IAggregate> GetAsync(Type type, Guid id, Int64? version)
        {

        }
        public async Task<IAggregate> GetStatelessAsync(Type type, Guid id)
        {

        }
        public async Task<AggregateCommit> SaveAsync(IAggregate aggregate)
        {
            // _db.GetCollection<EventDb>("events");

            // var customer = new Customer
            // {
            // Name = "John Doe",
            // Phones = new string[] { "8000-0000", "9000-0000" },
            // Age = 39,
            // IsActive = true
            // };

            // // Create unique index in Name field
            // col.EnsureIndex(x => x.Name, true);

            // // Insert new customer document (Id will be auto-incremented)
            // col.Insert(customer);

            // // Update a document inside a collection
            // customer.Name = "Joana Doe";

            // col.Update(customer);

            // // Use LINQ to query documents (with no index)
            // var results = col.Find(x => x.Age > 20);
        }
    }
}
