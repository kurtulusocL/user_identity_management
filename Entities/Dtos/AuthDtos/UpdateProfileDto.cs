using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserManagement.Entities.Dtos.AuthDtos
{
    public class UpdateProfileDto
    {
        [Required]
        public string Username { get; set; }       

        [Required, EmailAddress]
        public string Email { get; set; }       

        [Required]
        public string PhoneNumber { get; set; }
        public bool IsConfirmed { get; set; }
        public DateTime UpdatedDate { get; set; }

        public UpdateProfileDto()
        {
            IsConfirmed = true;
            UpdatedDate = DateTime.Now.ToLocalTime();
        }
    }
}