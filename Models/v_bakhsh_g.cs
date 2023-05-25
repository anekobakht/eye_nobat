using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eye_nobat.Models
{
    public class v_bakhsh_g
    {
        [Display(Name = "عنوان بخش")]
        public string? name { get; set; }
       
    }
}
