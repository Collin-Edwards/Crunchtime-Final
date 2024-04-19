using System;
using System.Collections.Generic;

namespace Crunchtime.Entities;

public partial class User
{
    public int Userid { get; set; }

    public string Username { get; set; } = null!;

    public string Passwordhash { get; set; } = null!;

    public string? Email { get; set; }

    public bool Isdoduser { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }
}
