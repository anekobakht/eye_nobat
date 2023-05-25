using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eye_nobat.Models
{
    public class v_ertebat_marakez
    {
       
        [Display(Name = "نام دانشگاه")]
        public string? name_uni { get; set; }
        //**********************************************************************
        [Display(Name = "نام بیمارستان")]
        public string? name_hos { get; set; }
        //**********************************************************************
        [Display(Name = "نام بخش")]
        public string? name_bakhsh { get; set; }
        //**********************************************************************
       



    }
}
