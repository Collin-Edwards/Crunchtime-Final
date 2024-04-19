using System;
using System.Collections.Generic;

namespace Crunchtime.Entities;

public partial class Weathercondition
{
    public int Conditionid { get; set; }

    public int Airportid { get; set; }

    public DateTime Timestamp { get; set; }

    public double Temperature { get; set; }

    public double Windspeed { get; set; }

    public string? Winddirection { get; set; }

    public double? Visibility { get; set; }

    public string? Conditiondescription { get; set; }

    public virtual Airport Airport { get; set; } = null!;
}
