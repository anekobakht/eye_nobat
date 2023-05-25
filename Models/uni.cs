using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eye_nobat.Models
{
    public class uni
    {
        [Key]
        public Int64 id { get; set; }
        //**********************************************************************
        [Display(Name = "نام دانشگاه")]
        [Required(ErrorMessage = "لطفا نام دانشگاه را وارد نمایید")]
        public string? name { get; set; }
        //**********************************************************************
        [Display(Name = "شماره همراه")]
        [Required(ErrorMessage = "لطفا شماره همراه را وارد نمایید")]
        public string? phone { get; set; }
        //**********************************************************************
        [Display(Name = "آدرس")]
        public string? address { get; set; }
        //**********************************************************************
        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا نام و نام خانوادگی را وارد نمایید")]
        public string? flname { get; set; }
        //**********************************************************************
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا نام کاربری را وارد نمایید")]
        public string? uname { get; set; }
        //**********************************************************************
        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا کلمه عبور را وارد نمایید")]
        public string? upass { get; set; }


        //**********************************************************************ForeignKey
        public ICollection<hos> hos { get; } = new List<hos>();
        //**********************************************************************ForeignKey
    }
}
