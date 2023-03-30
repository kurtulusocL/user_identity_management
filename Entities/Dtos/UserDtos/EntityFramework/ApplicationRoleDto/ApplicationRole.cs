using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserManagement.Core.Entities;

namespace UserManagement.Entities.Dtos.UserDtos.EntityFramework.ApplicationRoleDto
{
    public class ApplicationRole : IdentityRole, IEntity
    {
        public ApplicationRole()
        {
            SetCreatedDate();
        }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public void SetCreatedDate()
        {
            CreatedDate = DateTime.Now.ToLocalTime();            
        }
        public ApplicationRole(string roleNames, string description, string Discriminator) : base(roleNames)
        {
            this.Description = description;
            Discriminator = "IdentityRole";

        }

    }
}