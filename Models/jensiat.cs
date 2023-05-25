using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eye_nobat.Models
{
    public class jensiat
    {
        [Key]
        public Int64 id { get; set; }
        //**********************************************************************
        [Display(Name = "جنسیت")]
        public string? name { get; set; }
        //**********************************************************************
       

        //**********************************************************************ForeignKey
        public ICollection<never> never { get; } = new List<never>();
        //**********************************************************************ForeignKey



    }
}
