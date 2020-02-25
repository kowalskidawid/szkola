using System;
using System.ComponentModel.DataAnnotations;

namespace Szkoła.Models
{
    public class ParentModel
    {
        [Required(ErrorMessage = "Imię jest wymagane")]
        [Display(Name = "Imię:")]
        public String firstName { get; set; }

        [Display(Name = "Drugie imię:")]
        public String secondName { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [Display(Name = "Nazwisko:")]
        public String lastName { get; set; }

        [Display(Name = "Email:")]
        public String email { get; set; }

        [Required(ErrorMessage = "Numer telefonu jest wymagany")]
        [Phone]
        [Display(Name = "Telefon:")]
        public String phone { get; set; }

    }
}
