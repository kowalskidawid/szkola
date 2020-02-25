using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Bson;

namespace Szkoła.Models
{
    public class SchoolModel
    {
        public ObjectId _id { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [Display(Name = "Nazwa:")]
        public string name { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [Display(Name = "Liczba klas")]
        [Range(1, Double.MaxValue, ErrorMessage = "Liczba klas nie może być większa od 0")]
        public int quantityOfClass { get; set; }
    }
}