using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eye_nobat.Models
{
    public class v_koli_detail
    {
        [Key]
        public Int64 id { get; set; }
        //**********************************************************************
        [Display(Name = "نام و نام خانوادگی بیمار")]
        public string? flname { get; set; }
        //**********************************************************************
        [Display(Name = "کد ملی")]
        public string? codemeli { get; set; }
        //**********************************************************************
        [Display(Name = "سن")]
        public string? sen { get; set; }
        //**********************************************************************
        [Display(Name = "تاریخ مراجعه")]
        public string? date_morajee { get; set; }
        //**********************************************************************
        [Display(Name = "ساعت مراجعه")]
        public string? saat_morajee { get; set; }
        //**********************************************************************
        [Display(Name = "تاریخ وقوع")]
        public string? date_voghu { get; set; }
        //**********************************************************************
        [Display(Name = "ساعت وقوع")]
        public string? saat_voghu { get; set; }
        //**********************************************************************
        [Display(Name = "توضیحات")]
        public string? tozihat { get; set; }
        //**********************************************************************
        [Display(Name = "شماره کد")]
        public long? code_num { get; set; }
        //**********************************************************************
        [Display(Name = "عنوان کد خطا")]
        public string? code_name { get; set; }
        //**********************************************************************
        [Display(Name = "نام بخش")]
        public string? bakhsh_name { get; set; }
        //**********************************************************************
        [Display(Name = "نام بیمارستان")]
        public string? hos_name { get; set; }
        //**********************************************************************
        [Display(Name = "نام دانشگاه")]
        public string? uni_name { get; set; }
        //**********************************************************************
        [Display(Name = "شماره کد")]
        public long? code_id { get; set; }
        //**********************************************************************
        [Display(Name = "جنسیت")]
        public string? jensiat_name { get; set; }
        //**********************************************************************
        [Display(Name = "شناسه جنسیت")]
        public long? jensiat_id { get; set; }
        //**********************************************************************
        [Display(Name = "شناسه دانشگاه")]
        public long? uni_id { get; set; }
        //**********************************************************************
        [Display(Name = "شناسه بیمارستان")]
        public long? hos_id { get; set; }
        //**********************************************************************
        [Display(Name = "شناسه بخش")]
        public long? bakhsh_id { get; set; }
        //**********************************************************************






    }
}
