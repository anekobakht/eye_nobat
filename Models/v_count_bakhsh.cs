using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eye_nobat.Models
{
    public class v_count_bakhsh
    {

        [Display(Name = "تعداد کل")]
        public int? count { get; set; }


    }
}
