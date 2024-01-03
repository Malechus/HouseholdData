using System;
using System.Collections.Generic;

namespace HouseholdData.Models;

public partial class Point
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? ChorePoints { get; set; }

    public int? GreenGem { get; set; }

    public int? ProteinPoints { get; set; }

    public int? VegetablePoints { get; set; }
}
