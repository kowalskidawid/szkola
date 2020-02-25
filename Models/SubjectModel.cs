using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Szkoła.Models
{
    public class SubjectModel {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [Display(Name = "Skrót:")]
        public String abbreviation { get; set; }

        [Display(Name = "Nazwa:")]
        [Required]
        public String name { get; set; }
    }
}
