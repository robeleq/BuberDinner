using BuberDinner.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.DTOs.Auth
{
    public class AuthResultDTO
    {
        public IdentityUser User { get; set; } = null!;

        public string Token { get; set; } = null!;
    }
}
