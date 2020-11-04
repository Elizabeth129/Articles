using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Models
{
    public class Ankete
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your name")]
        [Display(Name = "Имя")]
        [RegularExpression("^([А-ЯІЇЄ]{1}[а-яіїє']{1,20}|[A-Z]{1}[a-z]{1,20})$",
         ErrorMessage = "Only letters allowed. First letter must be uppercase.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your surname")]
        [Display(Name = "Фамилия")]
        [RegularExpression("^([А-ЯІЇЄ]{1}[а-яіїє']{1,20}|[A-Z]{1}[a-z]{1,20})$",
         ErrorMessage = "Only letters allowed. First letter must be uppercase.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Please enter your surname")]
        [Display(Name = "Почта")]
        [EmailAddress(ErrorMessage = "Error email")]
        [Remote("ValidateEmail", "Worksheet")]
        public string Email { get; set; }
        [Display(Name = "Ваши любимые жанры")]
        public virtual ICollection<AnketeGenre> AnketeGenres { get; set; }
        public Ankete()
        {
            AnketeGenres = new List<AnketeGenre>();
        }

        public int? TimeId { get; set; }

        [Display(Name = "Сколько времени в день вы читаете")]
        public virtual Time Time { get; set; }
        public int AgeId { get; set; }
        [Display(Name = "Возраст")]
        public virtual Age Age { get; set; }
    }
}