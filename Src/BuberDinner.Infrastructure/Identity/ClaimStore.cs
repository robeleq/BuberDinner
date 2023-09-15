using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Infrastructure.Identity
{
    public static class ClaimStore
    {
        public static List<Claim> claims = new List<Claim>() 
        { 
            new Claim("Create:User", "Create User"),
            new Claim("View:User", "View User"),
            new Claim("Edit:User", "Edit User"),
            new Claim("Delete:User", "Delete User"),

            new Claim("Create:Role", "Create User Role"),
            new Claim("View:Role", "View User Role"),
            new Claim("Edit:Role", "Edit User Role"),
            new Claim("Delete:Role", "Delete User Role"),
            new Claim("Add:Role", "Add User Role"),

            new Claim("Create:Claim", "Create User Claim"),
            new Claim("View:Claim", "View User Claim"),
            new Claim("Edit:Claim", "Edit User Claim"),
            new Claim("Delete:Claim", "Delete User Claim"),
            new Claim("Add:Claim", "Add User Claim"),
        };
    }
}
