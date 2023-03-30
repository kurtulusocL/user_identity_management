using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserManagement.Entities.Dtos.AuthDtos
{
    public class ChangePasswordDto
    {
        [Required]
        public string CurrentPassword { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "Your password should be between 8 and 40 characters.")]
        public string NewPassword { get; set; }

        [StringLength(40, MinimumLength = 8, ErrorMessage = "Your password should be between 8 and 40 characters.")]
        [Compare("NewPassword", ErrorMessage = "Passwords are not same. Please check them.")]
        public string ConfirmNewPassword { get; set; }
    }
}