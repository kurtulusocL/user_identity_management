using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using UserManagement.Core.Entities;

namespace UserManagement.Entities.Dtos.UserDtos.EntityFramework.ApplicationUserDto
{
    public class ApplicationUser : IdentityUser, IEntity
    {
        public async Task<ClaimsIdentity> GenereteUserIdentityIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
        public string NameSurname { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsConfirmed { get; set; }

        public void SetConfirmed()
        {
            IsConfirmed = true;
        }

        public void SetCreatedDate()
        {
            CreatedDate = DateTime.Now.ToLocalTime();
        }
        public ApplicationUser()
        {
            SetConfirmed();
            SetCreatedDate();
            EmailConfirmed = true;
            PhoneNumberConfirmed = true;
        }
    }
}