using System;
using System.Collections.Generic;

namespace Crunchtime.Entities;

public partial class Airport
{
    public int Airportid { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string Icaocode { get; set; } = null!;

    public bool Ismilitary { get; set; }

    public virtual ICollection<Airportdelay> Airportdelays { get; set; } = new List<Airportdelay>();

    public virtual ICollection<Weathercondition> Weatherconditions { get; set; } = new List<Weathercondition>();
}
