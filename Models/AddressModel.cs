using System;
using System.ComponentModel.DataAnnotations;

namespace Szkoła.Models
{
    public class Address
    {
        [Required(ErrorMessage = "To pole jest wymagane")]
        [Display(Name = "Ulica:")]
        public String street { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [Display(Name = "Kod pocztowy:")]
        [RegularExpression("[0-9]{2}-[0-9]{3}", ErrorMessage ="Kod pocztowy jest nieprawidłowy")]
        public String zipCode { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [Display(Name = "Miasto:")]
        public String town { get; set; }
    }
}