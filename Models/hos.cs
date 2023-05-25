using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eye_nobat.Models
{
    public class hos
    {
        [Key]
        public Int64 id { get; set; }
        //**********************************************************************
        [Display(Name = "نام بیمارستان")]
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
        [ForeignKey("uni")]
        public long uni_id { get; set; }
        public uni uni { get; set; } = null!;
        //**********************************************************************ForeignKey
        //**********************************************************************ForeignKey
        public ICollection<bakhsh> bakhsh { get; } = new List<bakhsh>();
        //**********************************************************************ForeignKey


    }
}
