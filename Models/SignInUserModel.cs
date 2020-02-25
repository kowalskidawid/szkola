using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Szkoła.Models
{
    public class signInUserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String _id { get; set; }

        [Required(ErrorMessage = "Login jest wymagany")]
        [Display(Name = "Login:")]
        [DataType(DataType.Text)]
        [MinLength(6, ErrorMessage = "Login musi mieć więcej niż 6 znaków")]
        public String Login { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane")]
        [Display(Name = "Hasło:")]
        [MinLength(6, ErrorMessage = "Hasło musi mieć więcej niż 6 znaków")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}
