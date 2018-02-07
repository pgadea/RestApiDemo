using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestSecurity.Models
{
    public class RestSecurityContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public RestSecurityContext() : base("name=RestSecurityContext")
        {
        }

        public System.Data.Entity.DbSet<RestSecurity.Models.Notes> Notes { get; set; }
    }
}
