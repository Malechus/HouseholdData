using System;
using System.Collections.Generic;

namespace HouseholdData.Models;

public partial class TransactionalChore
{
    public int Id { get; set; }

    public DateOnly WeekOf { get; set; }

    public int ChoreId { get; set; }

    public ulong Completed { get; set; }

    public DateTime? CompletedDatetime { get; set; }
}
