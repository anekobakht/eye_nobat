using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eye_nobat.Models
{
    public class v_nemudar_jensiat
    {
        [Display(Name = "جنسیت")]
        public string? name { get; set; }
        [Display(Name = "تعداد کل")]
        public int? count { get; set; }

        public long id { get; set; }

    }
}
