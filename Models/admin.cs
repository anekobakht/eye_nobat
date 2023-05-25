using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eye_nobat.Models
{
    public class admin
    {
        [Key]
        public Int64 id { get; set; }
        //**********************************************************************
        [Display(Name = "نام و نام خانوادگی رابط")]
        public string? flname { get; set; }
        //**********************************************************************
        [Display(Name = "نام کاربری")]
        public string? uname { get; set; }
        //**********************************************************************
        [Display(Name = "کلمه عبور")]
        public string? pass { get; set; }
        //**********************************************************************






    }
}
