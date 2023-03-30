using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserManagement.Core.Entities.EntityFramework;

namespace UserManagement.Entities.Concrete
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public decimal Price { get; set; }
        public int UnitInStock { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}