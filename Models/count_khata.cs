using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace general_cheshm.Models
{
    public class count_khata
    {
        [Display(Name = "تعداد")]
        public int count { get; set; }
        //**********************************************************************
        [Display(Name = "کد خطا")]
        public string num_khata { get; set; }
        //**********************************************************************
    }
}
