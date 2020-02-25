using Szkoła.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System;
using MongoDB.Bson;
using System.Collections;

namespace Szkoła.Services
{
    public class SubjectsServices
    {
        private readonly IMongoCollection<SubjectModel> _collection;

        public SubjectsServices(string databaseName, string collectionName, string databaseUrl)
        {
            var mongoClient = new MongoClient(databaseUrl);
            var mongoDatabase = mongoClient.GetDatabase(databaseName);
            _collection = mongoDatabase.GetCollection<SubjectModel>(collectionName);
        }

        public List<SubjectModel> getAll()
        {
            List<SubjectModel> students = new List<SubjectModel>();
            students = _collection.Find(new BsonDocument()).ToList();

            return students;
        }

        public void create(SubjectModel subject)
        {
            _collection.InsertOne(subject);
        }

        public List<SubjectModel> getById(string _id)
        {
            var id = ObjectId.Parse(_id);
            BsonDocument document = new BsonDocument();
            document["_id"] = id;

            return _collection.Find(document).ToList();
        }

        public void edit(SubjectModel subject)
        {
            var id = ObjectId.Parse( subject._id );
            BsonDocument document = new BsonDocument();
            document["_id"] = id;
            _collection.FindOneAndReplaceAsync(document, subject);
        }

        public void delete(SubjectModel subject)
        {
            var id = ObjectId.Parse(subject._id);
            BsonDocument document = new BsonDocument();
            document["_id"] = id;
            _collection.FindOneAndDeleteAsync(document);
        }
    }
}