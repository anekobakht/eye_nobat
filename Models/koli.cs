using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eye_nobat.Models
{
    public class koli
    {
        [Key]
        public Int64 id { get; set; }
        //**********************************************************************
        [Display(Name = "نام و نام خانوادگی")]
        public string? flname { get; set; }
        //**********************************************************************
        [Display(Name = "مشاهده شده")]
        public bool? moshahede { get; set; }
        //**********************************************************************
        [Display(Name = "در حال اجرا")]
        public bool? ejra { get; set; }
        //**********************************************************************
        [Display(Name = "اتمام")]
        public bool? etmam { get; set; }
        //**********************************************************************
        //**********************************************************************
        [Display(Name = "نام بیمارستان")]
        public string? name_hos { get; set; }
        //**********************************************************************
        [Display(Name = "تاریخ ورود")]
        public string? date_vorud { get; set; }
        //**********************************************************************
        [Display(Name = "ساعت ورود")]
        public string? saat_vorud { get; set; }
        //**********************************************************************





    }
}
