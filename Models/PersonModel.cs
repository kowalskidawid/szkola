using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Szkoła.Models
{
    /// <summary>
    ///     Model odpowiedzialny za przechowywanie podstawowych danych osobowych takich jak imię, nazwisko itd. Po tej klasie dziedziczy TeacherModel oraz StudentsModel.
    /// </summary>
    public class PersonModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane")]
        [Display(Name = "Imię:")]
        [DataType(DataType.Text)]
        public String FirstName { get; set; }

        [Display(Name = "Drugie imię:")]
        public String SecondName { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [Display(Name = "Nazwisko:")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "Email jest wymagany")]
        [EmailAddress]
        [Display(Name = "Email:")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Numer telefonu jest wymagany")]
        [RegularExpression("(\\d{3}-\\d{3}-\\d{3})", ErrorMessage = "Numer telefonu jest nieprawidlowy. Podaj numer w postaci <strong>123-456-789</strong>")]
        [Display(Name = "Telefon:")]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Data urodzenia jest wymagana")]
        [Display(Name = "Data urodzenia:")]
        [DataType(DataType.Text)]
        [RegularExpression("(\\d{4}-\\d{2}-\\d{2})", ErrorMessage = "Data urodzenia jest nieprawidłowa")]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessage = "Pesel jest wymagane")]
        [StringLength(11, ErrorMessage = "Pesel jest nieprawidłowy")]
        [Display(Name = "Pesel:")]
        public String Pesel { get; set; }

        public Address PlaceOfResidence { get; set; }

        public Address Domicile { get; set; }
    }
}
