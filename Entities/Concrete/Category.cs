using Microsoft.Owin.Security.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserManagement.Core.Entities.EntityFramework;

namespace UserManagement.Entities.Concrete
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
}
}