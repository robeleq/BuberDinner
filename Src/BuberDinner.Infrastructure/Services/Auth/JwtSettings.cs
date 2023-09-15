﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Infrastructure.Services.Auth;

public class JwtSettings
{
    public const string SectionName = "JwtSettings";
    public string Secret { get; init; } = null!;
    public int ExpiryMinutes { get; init; }
    public string Issuer { get; init; } = null!;
    public string Audience { get; init; } = null!;
}
