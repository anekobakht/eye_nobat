using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eye_nobat.Models
{
    public class code
    {
        [Key]
        public Int64 id { get; set; }
        //**********************************************************************
        [Display(Name = "عنوان خطا")]
        [Required(ErrorMessage = "لطفا عنوان خطا را وارد نمایید")]
        public string? name { get; set; }
        //**********************************************************************
        [Display(Name = "شماره خطا")]
        [Required(ErrorMessage = "لطفا شماره خطا را وارد نمایید")]
        public long num { get; set; }
        //**********************************************************************
        [Display(Name = "ارسال پیامک صورت پذیرد؟")]
        public bool? sms { get; set; }
        //**********************************************************************

        //**********************************************************************ForeignKey
        public ICollection<never> never { get; } = new List<never>();
        //**********************************************************************ForeignKey
    }
}
