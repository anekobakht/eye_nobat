using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eye_nobat.Models
{
    public class peyvast
    {
        [Key]
        public Int64 id { get; set; }
        //**********************************************************************
        [Display(Name = "نام پیوست")]
        public string? name { get; set; }
        //**********************************************************************
        [Display(Name = "پیوست")]
        public byte[]? val { get; set; }
        //**********************************************************************
        public string? kind { get; set; }
        //**********************************************************************


        //**********************************************************************ForeignKey
        [ForeignKey("never")]
        public long never_id { get; set; }
        public never never { get; set; } = null!;
        //**********************************************************************ForeignKey





    }
}
