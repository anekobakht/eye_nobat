using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eye_nobat.Models
{
    public class v_uni_hos1
    {
        [Key]
        [Display(Name = "شناسه بیمارستان")]
        public long hos_id { get; set; }
        //**********************************************************************
        [Display(Name = "نام دانشگاه")]
        public string? uni_name { get; set; }
        //**********************************************************************
        [Display(Name = "شناسه دانشگاه")]
        public long uni_id { get; set; }
        //**********************************************************************
        [Display(Name = "نام بیمارستان")]
        public string? hos_name { get; set; }
        //**********************************************************************
       




    }
}
