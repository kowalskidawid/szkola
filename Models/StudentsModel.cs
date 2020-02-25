using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Szkoła.Models
{
    /// <summary>
    ///     Model odpowiedzialny za przechowywanie danych uczniów. 
    /// </summary>
    public class StudentsModel : PersonModel
    {
        [Required(ErrorMessage = "Wybór klasy jest wymagany")]
        [Display(Name = "Klasa:")]
        public int Group { get; set; }

        [Required(ErrorMessage = "Wybór szkołę jest wymagany")]
        [Display(Name = "Szkoła:")]
        public String School { get; set; }

        public List<ParentModel> Parents { get; set; }
    }
}
