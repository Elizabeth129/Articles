using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PL.Models
{
    public class Age
    {
        public Age()
        {
            Anketes = new List<Ankete>();
        }
        public int Id { get; set; }
        [Display(Name = "Возраст")]
        public string AgeName { get; set; }
        public virtual ICollection<Ankete> Anketes { get; set; }
    }
}