using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eye_nobat.Models
{
    public class never
    {
        [Key]
        public Int64 id { get; set; }
        //**********************************************************************ForeignKey
        [ForeignKey("bakhsh")]
        public long bakhsh_id { get; set; }
        public bakhsh bakhsh { get; set; } = null!;
        //**********************************************************************ForeignKey
        //**********************************************************************ForeignKey
        [ForeignKey("code")]
        public long code_id { get; set; }
        public code code { get; set; } = null!;
        //**********************************************************************ForeignKey

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
        //**********************************************************************ForeignKey
        [ForeignKey("jensiat")]
        public long jensiat_id { get; set; }
        public jensiat jensiat { get; set; } = null!;
        //**********************************************************************ForeignKey
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



        //**********************************************************************ForeignKey
        public ICollection<peyvast> peyvast { get; } = new List<peyvast>();
        //**********************************************************************ForeignKey

    }
}
