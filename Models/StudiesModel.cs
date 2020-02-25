using System;
using System.ComponentModel.DataAnnotations;

namespace Szkoła.Models
{
    public class StudiesModel
    {
        [Display(Name = "Nazwa uczelni:")]
        [Required(ErrorMessage = "Nazwa uczelni jest wymagana.")]
        public String universityName { get; set; }

        [Display(Name = "Kierunek:")]
        [Required(ErrorMessage = "Kierunek jest wymagany.")]
        public String fieldOfStudy { get; set; }

        [Display(Name = "Rok ukończenia:")]
        [Required(ErrorMessage = "Rok urodzenia jest wymagany")]
        public int yearOfGraduation  { get; set; }

        [Display(Name = "Stopień:")]
        [Required(ErrorMessage ="Stopień studiów jest wymagany")]
        public String academicDegree { get; set; }
    }
}