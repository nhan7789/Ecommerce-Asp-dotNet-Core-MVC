using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Text;

namespace Common.Entites
{
    public class Users : IdentityUser
    {
        public string Token { get; set; }
        public DateTime TokenExpires { get; set; }
        //------------------- Claims
        [NotMapped]
        public IList<Claim> Claims { get; set; } = new List<Claim>();
    }
}
