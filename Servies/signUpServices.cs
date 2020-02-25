using Szkoła.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System;
using MongoDB.Bson;
using System.Collections;

namespace Szkoła.Services
{
    public class signUpUserServices
    {
        private readonly IMongoCollection<signUpUserModel> _collection;

        public signUpUserServices(string databaseName, string collectionName, string databaseUrl)
        {
            var mongoClient = new MongoClient(databaseUrl);
            var mongoDatabase = mongoClient.GetDatabase(databaseName);
            _collection = mongoDatabase.GetCollection<signUpUserModel>(collectionName);
        }

        public List<signUpUserModel> getAll()
        {
            List<signUpUserModel> users = new List<signUpUserModel>();
            users = _collection.Find(new BsonDocument()).ToList();
            return users;
        }

        public List<signUpUserModel> getById(string _id)
        {
            var id = ObjectId.Parse(_id);
            BsonDocument document = new BsonDocument();
            document["_id"] = id;

            return _collection.Find(document).ToList();
        }

        public void edit(signUpUserModel user)
        {
            var id = ObjectId.Parse(user._id);
            BsonDocument document = new BsonDocument();
            document["_id"] = id;
            _collection.FindOneAndReplace(document, user);
        }

        public void create(signUpUserModel user)
        {
            _collection.InsertOne(user);
        }

        public void delete(signUpUserModel user)
        {
            var id = ObjectId.Parse(user._id);
            BsonDocument document = new BsonDocument();
            document["_id"] = id;
            _collection.FindOneAndDelete(document);
        }
    }
}