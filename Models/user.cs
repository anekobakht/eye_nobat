using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eye_nobat.Models
{
    public class user
    {
        [Key]
        public Int64 user_id { get; set; }
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
        //**********************************************************************
        [Display(Name = "admin می باشد؟")]
        [Required(ErrorMessage = "لطفا ماهیت admin را مشخص نمایید")]
        public bool? admin { get; set; }
        //**********************************************************************


    }
}
