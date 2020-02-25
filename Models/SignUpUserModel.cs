using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Szkoła.Models
{
    public class signUpUserModel
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

        [Required(ErrorMessage = "Email jest wymagany")]
        [Display(Name = "Email:")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public bool[] accessToSchool { get; set; }
        public bool[] accessToSubject { get; set; }
        public bool[] accessToStudents { get; set; }
        public bool[] accessToTeachers { get; set; }
        public bool[] accessToUsers { get; set; }
    }
}
