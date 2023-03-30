using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using UserManagement.Core.Entities;

namespace UserManagement.Entities.Dtos.AuthDtos
{
    public class RegisterDto
    {
        [Required]
        public string NameSurname { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "Your password should be between 6 and 40 characters.")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords are not same. Please, check them.")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "Your password should be between 6 and 40 characters.")]
        public string ConfirmPassword { get; set; }
        public DateTime CreatedDate { get; set; }

        public RegisterDto()
        {
            CreatedDate = DateTime.Now.ToLocalTime();
        }
    }
}