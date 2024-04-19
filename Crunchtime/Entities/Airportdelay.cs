using System;
using System.Collections.Generic;

namespace Crunchtime.Entities;

public partial class Airportdelay
{
    public int Delayid { get; set; }

    public int Airportid { get; set; }

    public DateTime Timestamp { get; set; }

    public int Delayduration { get; set; }

    public string? Delayreason { get; set; }

    public virtual Airport Airport { get; set; } = null!;
}
