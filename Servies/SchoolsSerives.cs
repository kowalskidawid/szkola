using Szkoła.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System;
using MongoDB.Bson;

namespace Szkoła.Services
{
    public class SchoolsServices
    {
        private readonly IMongoCollection<SchoolModel> _collection;

        public SchoolsServices(string databaseName, string collectionName, string databaseUrl)
        {
            var mongoClient = new MongoClient(databaseUrl);
            var mongoDatabase = mongoClient.GetDatabase(databaseName);
            _collection = mongoDatabase.GetCollection<SchoolModel>(collectionName);
        }

        public List<SchoolModel> getAll()
        {
            return _collection.Find(new BsonDocument()).ToList();
        }

        public void create(SchoolModel school)
        {
            _collection.InsertOne( school );
        }
    }
}