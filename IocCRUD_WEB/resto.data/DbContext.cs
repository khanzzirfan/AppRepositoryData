using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Resto.Core;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Configuration;

namespace Resto.Data
{
    public class MongoDbContext
    {
        //private IMongoDatabase database;
        //private IMongoCollection<TEntity> collection;
        //private IMongoClient client;


        public MongoDbContext()
        {
          //  GetDatabase();
          //  GetCollection();
        }

        /****
        public IQueryable<TEntity> Table
        {
            get
            {
                return collection.AsQueryable();
                //throw new NotImplementedException();
            }
        }

        public object ConfigurationManager { get; private set; }

        public bool Delete(TEntity entity)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", entity.ID);
            var result = collection.DeleteOneAsync(filter);
            return result.Status == System.Threading.Tasks.TaskStatus.RanToCompletion;
        }

        public TEntity GetById(object id)
        {
            var filter = new FilterDefinitionBuilder<TEntity>().Eq("_id", id);
            var find = collection.Find(filter).FirstOrDefaultAsync();
            var result = find.Result;
            return result;
        }

        public bool Insert(TEntity entity)
        {
            entity.ID = Guid.NewGuid();
            var result = collection.InsertOneAsync(entity);
            return result.Status == System.Threading.Tasks.TaskStatus.RanToCompletion;
        }

        public bool Update(TEntity entity)
        {
            if (entity.ID == null)
                return Insert(entity);

            //collection.UpdateOneAsync<TEntity>(x => x.ID == entity.ID, entity);
            var result =  collection.ReplaceOneAsync<TEntity>(x => x.ID == entity.ID, entity);
            return result.Status == System.Threading.Tasks.TaskStatus.Created;
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
                config = "mongodb://localhost:27017/{DB_NAME}?safe=true";
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
                .GetCollection<TEntity>(typeof(TEntity).Name);
        }

        #endregion
          
        ********/
    }
}
