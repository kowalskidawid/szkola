using Szkoła.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System;
using MongoDB.Bson;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Szkoła.Services
{
    public class StudentsServices
    {
        private readonly IMongoCollection<StudentsModel> _collection;

        public StudentsServices(string databaseName, string collectionName, string databaseUrl)
        {
            var mongoClient = new MongoClient(databaseUrl);
            var mongoDatabase = mongoClient.GetDatabase(databaseName);
            _collection = mongoDatabase.GetCollection<StudentsModel>(collectionName);
        }

        public List<StudentsModel> getAll()
        {
            List<StudentsModel> students = new List<StudentsModel>();
            students = _collection.Find(new BsonDocument()).ToList();
            
            return students;
        }

        public List<StudentsModel> getById(string _id)
        {
            var id = ObjectId.Parse(_id);
            BsonDocument document = new BsonDocument();
            document["_id"] = id;

            return _collection.Find(document).ToList();
        }


        public List<StudentsModel> getClass(string _id)
        {
            var id = ObjectId.Parse(_id);
            BsonDocument document = new BsonDocument();
            document["_id"] = id;
            var fields = Builders<StudentsModel>.Projection.Include(StudentsModel => StudentsModel.School).Include(StudentsModel => StudentsModel.Group);

            return _collection.Find(document).Project<StudentsModel>(fields).ToList();
        }

        public void create(StudentsModel student)
        {
            _collection.InsertOne(student);
        }

        public void edit(StudentsModel student)
        {
            var id = ObjectId.Parse(student._id);
            BsonDocument document = new BsonDocument();
            document["_id"] = id;
            _collection.FindOneAndReplaceAsync(document, student);
        }

        public void delete(StudentsModel student)
        {
            var id = ObjectId.Parse(student._id);
            BsonDocument document = new BsonDocument();
            document["_id"] = id;
            _collection.FindOneAndDeleteAsync(document);
        }
        
        private StudentsModel encrypt( StudentsModel student )
        {
            var text = "Hello World";
            var buffer = Encoding.UTF8.GetBytes(text);

            var iv = "1233321";
            var keyAes = GetRandomData(256);


            byte[] result;
            using (var aes = Aes.Create())
            {
                aes.Key = keyAes;
                aes.IV = iv;

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                using (var resultStream = new MemoryStream())
                {
                    using (var aesStream = new CryptoStream(resultStream, encryptor, CryptoStreamMode.Write))
                    using (var plainStream = new MemoryStream(buffer))
                    {
                        plainStream.CopyTo(aesStream);
                    }

                    result = resultStream.ToArray();
                }
            }

            return student;
        }
    }
}