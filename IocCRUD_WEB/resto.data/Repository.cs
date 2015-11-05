using System;
using System.Linq;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Resto.Core;
using Resto.Core.Data;

namespace Resto.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private IMongoDatabase database;
        private IMongoCollection<T> collection;
        private IMongoClient client;
        //public object ConfigurationManager { get; private set; }

        public Repository()
        {

            GetDatabase();
            SetBsonMapping();
            GetCollection();
        }

        public void SetBsonMapping()
        {
            BsonClassMap.RegisterClassMap<Restaurant>(c =>
            {
                c.AutoMap();
                c.MapIdMember(e => e._Id);
            });
        }
        public T GetById(object id)
        {

            var filter = new FilterDefinitionBuilder<T>().Eq("_id", id);
            var find = collection.Find(filter).FirstOrDefaultAsync();
            var result = find.Result;
            return result;
        }

        public bool Insert(T entity)
        {
            entity.ID = Guid.NewGuid();
            var result = collection.InsertOneAsync(entity);
            return result.Status == System.Threading.Tasks.TaskStatus.RanToCompletion;
        }

        public bool Update(T entity)
        {
            if (entity.ID == null || entity.ID==Guid.Empty)
                return Insert(entity);

            //collection.UpdateOneAsync<TEntity>(x => x.ID == entity.ID, entity);
            var result = collection.ReplaceOneAsync<T>(x => x.ID == entity.ID, entity);
            return result.Status == System.Threading.Tasks.TaskStatus.Created;
        }

        public bool Delete(T entity)
        {
            var filter = Builders<T>.Filter.Eq("_id", entity.ID);
            var result = collection.DeleteOneAsync(filter);
            var _status = result.Status;
            return true;
        }

        public IQueryable<T> Table
        {
            get
            {
                return collection.AsQueryable();
            }
        }



       #region Private Helper Methods
        private void GetDatabase()
        {
            var client = new MongoClient(GetConnectionString());
            database = client.GetDatabase(GetDatabaseName());
        }

        private string GetConnectionString()
        {

            var config = System.Configuration.ConfigurationManager.AppSettings["MongoDbConnectionString"];
            if (config == null)
            {
                const string connectionString = "mongodb://localhost/?replicaSet=myReplSet&readPreference=primary";
                const string conn2 = "mongodb://localhost:27017/{DB_NAME}?safe=true";
                config = connectionString;
            }
            var dbName = GetDatabaseName();
            if (dbName == null)
            {
                dbName = "test";
            }

            return config.Replace("{DB_NAME}", dbName);

            //return System.Configuration.ConfigurationManager.AppSettings["MongoDbConnectionString"].Replace("{DB_NAME}", GetDatabaseName());
           //.Get("MongoDbConnectionString")
               
        }

        private string GetDatabaseName()
        {
            return "test";
            //return System.Configuration.ConfigurationManager.AppSettings.Get("MongoDbDatabaseName");
        }

        private void GetCollection()
        {
            collection = database
                .GetCollection<T>(typeof(T).Name);
        }

        #endregion
          

    }
}
