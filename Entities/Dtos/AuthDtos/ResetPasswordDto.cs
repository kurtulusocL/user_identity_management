using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UserManagement.Core.Entities;

namespace UserManagement.Entities.Dtos.AuthDtos
{
    public class ResetPasswordDto
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        public string Code { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "Your password should be between 6 and 40 characters.")]
        public string Password { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "Your password should be between 6 and 40 characters.")]
        public string ConfirmPassword { get; set; }
    }
}