using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eye_nobat.Models
{
    public class v_nemudar_never_uni
    {
        [Display(Name = "عنوان دانشگاه")]
        public string? name { get; set; }

        [Display(Name = "تعداد خطای ثبت شده دانشگاه")]
        public int? count { get; set; }

        public long id { get; set; }

    }
}
