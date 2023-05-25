using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eye_nobat.Models
{
    public class v_count_hos
    {
        [Display(Name = "نام بیمارستان")]
        public string? name_hos { get; set; }

        [Display(Name = "تعداد کل")]
        public int? count { get; set; }


    }
}
