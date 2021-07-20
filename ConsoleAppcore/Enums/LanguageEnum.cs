using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleAppcore.Enums
{
    public enum LanguageEnum
    {
        [Display(Name="Hindi Language")]
        Hindi = 10,
        [Display(Name = "English Language")]
        English  =11,
        [Display(Name = "Telugu Language")]
        Telugu  =12,
        [Display(Name = "Tamil Language")]
        Tamil  =13,
        [Display(Name = "Kannada Language")]
        Kannada  =14,
        [Display(Name = "urdu Language")]
        urdu =15

    }
}
