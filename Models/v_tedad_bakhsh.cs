using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eye_nobat.Models
{
    public class v_tedad_bakhsh
    {
        [Display(Name = "نام بخش")]
        public string? name { get; set; }
        [Display(Name = "تعداد کل")]
        public int? count { get; set; }
        [Display(Name = "نام دانشگاه")]
        public string? name_uni { get; set; }
        [Display(Name = "نام بیمارستان")]
        public string? name_hos { get; set; }
        public long uni_id { get; set; }
        public long hos_id { get; set; }
        public long bakhsh_id { get; set; }




    }
}
