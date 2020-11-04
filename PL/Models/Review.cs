using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PL.Models
{
    public class Review
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your name")]
        [Display(Name = "Имя")]
        [RegularExpression("^([А-ЯІЇЄ]{1}[а-яіїє']{1,20}|[A-Z]{1}[a-z]{1,20})$",
         ErrorMessage = "Only letters allowed. First letter must be uppercase.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your Comment")]
        [StringLength(400, MinimumLength = 5)]
        [Display(Name = "Коментарий")]
        public string Comment { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime Date { get; set; }
    }
}