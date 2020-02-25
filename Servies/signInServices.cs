using Szkoła.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System;
using MongoDB.Bson;
using System.Collections;

namespace Szkoła.Services
{
    public class signInServices
    {
        private readonly IMongoCollection<signInUserModel> _collection;

        public signInServices(string databaseName, string collectionName, string databaseUrl)
        {
            var mongoClient = new MongoClient(databaseUrl);
            var mongoDatabase = mongoClient.GetDatabase(databaseName);
            _collection = mongoDatabase.GetCollection<signInUserModel>(collectionName);
        }

        public List<signInUserModel> getAll()
        {
            List<signInUserModel> users = new List<signInUserModel>();

            var fields = Builders<signInUserModel>.Projection.Include(signInUserModel => signInUserModel.Login).Include(signInUserModel => signInUserModel.Login);
            return _collection.Find(new BsonDocument()).Project<signInUserModel>(fields).ToList();
        }

        public List<signInUserModel> signIn(signInUserModel user)
        {
            List<signInUserModel> users = new List<signInUserModel>();

            BsonDocument query = new BsonDocument();
            query.Add("Login", user.Login);
            query.Add("Password", user.Password);

            var fields = Builders<signInUserModel>.Projection.Include(signInUserModel => signInUserModel.Login).Include(signInUserModel => signInUserModel.Login);
            return _collection.Find(query).Project<signInUserModel>(fields).ToList();
        }
    }
}