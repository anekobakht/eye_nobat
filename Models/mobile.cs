using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eye_nobat.Models
{
    public class mobile
    {
        [Key]
        public long id { get; set; }
        //**********************************************************************
        [Display(Name = "نام و نام خانوادگی")]
        public string? flname { get; set; }
        //**********************************************************************
        [Display(Name = "شماره همراه")]
        public string? number { get; set; }
        //**********************************************************************







    }
}
