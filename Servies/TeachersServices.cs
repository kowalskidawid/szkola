using Szkoła.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System;
using MongoDB.Bson;
using System.Collections;

namespace Szkoła.Services
{
    public class TeachersServices
    {
        private readonly IMongoCollection<TeacherModel> _collection;

        public TeachersServices(string databaseName, string collectionName, string databaseUrl)
        {
            var mongoClient = new MongoClient(databaseUrl);
            var mongoDatabase = mongoClient.GetDatabase(databaseName);
            _collection = mongoDatabase.GetCollection<TeacherModel>(collectionName);
        }

        public List<TeacherModel> getAll()
        {
            List<TeacherModel> teachers = new List<TeacherModel>();
            teachers = _collection.Find(new BsonDocument()).ToList();

            return teachers;
        }

        public List<TeacherModel> getById(string _id)
        {
            var id = ObjectId.Parse(_id);
            BsonDocument document = new BsonDocument();
            document["_id"] = id;

            return _collection.Find(document).ToList();
        }

        public void create(TeacherModel teacher)
        {
          

            _collection.InsertOne(teacher);
        }


        public void edit(TeacherModel teacher)
        {
            var id = ObjectId.Parse(teacher._id);
            BsonDocument document = new BsonDocument();
            document["_id"] = id;
            _collection.FindOneAndReplaceAsync(document, teacher);
        }

        public void delete(TeacherModel teacher)
        {
            var id = ObjectId.Parse(teacher._id);
            BsonDocument document = new BsonDocument();
            document["_id"] = id;
            _collection.FindOneAndDeleteAsync(document);
        }
    }
}