using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PL.Models
{
    public class Time
    {
        public int Id { get; set; }
        [Display(Name = "Сколько времени в день вы читаете")]
        public string TimeName { get; set; }
        public virtual ICollection<Ankete> Anketes { get; set; }
        public Time()
        {
            Anketes = new List<Ankete>();
        }
    }
}