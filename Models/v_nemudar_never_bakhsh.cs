using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eye_nobat.Models
{
    public class v_nemudar_never_bakhsh
    {
        [Display(Name = "عنوان بخش")]
        public string? name { get; set; }

        [Display(Name = "تعداد خطای ثبت شده")]
        public int? count { get; set; }
        public long uni_id { get; set; }
        public long hos_id { get; set; }

    }
}
