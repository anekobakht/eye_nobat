using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eye_nobat.Models
{
    public class v_uni_hos_bakhsh1
    {
        [Key]
        public Int64 id { get; set; }
        //**********************************************************************
        [Display(Name = "نام بخش")]
        public string? name { get; set; }
        //**********************************************************************
        [Display(Name = "شماره تماس")]
        public string? phone { get; set; }
        //**********************************************************************
        [Display(Name = "آدرس")]
        public string? address { get; set; }
        //**********************************************************************
        [Display(Name = "نام و نام خانوادگی رابط")]
        public string? flname { get; set; }
        //**********************************************************************
        [Display(Name = "نام کاربری")]
        public string? uname { get; set; }
        //**********************************************************************
        [Display(Name = "کلمه عبور")]
        public string? upass { get; set; }
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
        [Display(Name = "شناسه بیمارستان")]
        public long hos_id { get; set; }
        //**********************************************************************




    }
}
