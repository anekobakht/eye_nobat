using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eye_nobat.Models
{
    public class bakhsh
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

        //**********************************************************************ForeignKey
        [ForeignKey("hos")]
        public long hos_id { get; set; }
        public hos hos { get; set; } = null!;
        //**********************************************************************ForeignKey

        //**********************************************************************ForeignKey
        public ICollection<never> never { get; } = new List<never>();
        //**********************************************************************ForeignKey



    }
}
