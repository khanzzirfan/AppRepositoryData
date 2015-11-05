using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Resto.Core.Data;

namespace Resto.Client
{
    public class UploadManager
    {
        IMongoClient client;
        IMongoDatabase db;
            // const string connectionString = "mongodb://myUserName:MyPassword@linus.mongohq.com:myPortNumber/";
            const string connectionString = "mongodb://localhost/?replicaSet=myReplSet&readPreference=primary";
            // const string connectionString = "mongodb://localhost";

           
        public UploadManager()
        {
            client = new MongoClient(connectionString);
            db = client.GetDatabase("test");

        }
        public void UploadRestaurantData()
        {
            string folderName = @"c:\mongodb\bin";
            var path = Path.Combine(folderName, "\\primer-dataset.json");

            path = folderName + "\\primer-dataset.json";
            this.UploadData("Restaurant", path);
        }

        private async void UploadData(string collectionName, string jsonFilePath)
        {
            try
            {
                await db.DropCollectionAsync(collectionName);
                var collection = db.GetCollection<Restaurant>(collectionName);
                using (var streamReader = new StreamReader(jsonFilePath))
                {
                    string line;
                    while ((line = await streamReader.ReadLineAsync()) != null)
                    {
                        using (var jsonReader = new JsonReader(line))
                        {
                            var context = BsonDeserializationContext.CreateRoot(jsonReader);
                            var document = collection.DocumentSerializer.Deserialize(context);
                            collection.InsertOneAsync(document);
                        }
                    }
                }

                Console.WriteLine("Successfully Uploaded Grades");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception \n\n");
                Console.WriteLine(ex.Message);
            }

        }


    }
}
