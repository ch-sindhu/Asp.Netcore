using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleAppcore.Models
{
    public class ChangePasswordModel
    {
        [Required,DataType(DataType.Password),Display(Name ="current password")]
        public string CuurentPassword { get; set; }
        [Required,DataType(DataType.Password),Display(Name ="New Password")]
        public string NewPassword { get; set; }
        [Required,DataType(DataType.Password),Display(Name ="Confirm Password")]
        [Compare("NewPassword",ErrorMessage ="Confirm new password doesn't match")]
        public string ConfirmNewPassword { get; set; }
    }
}
