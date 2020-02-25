using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Szkoła.Models
{
    /// <summary>
    ///     Model odpowiedzialny za przechowywanie danych nauczycieli. 
    /// </summary>
    public class TeacherModel : PersonModel
    {
        public StudiesModel[] Studies { get; set; }

        public String[] Subjects { get; set; }
    }
}