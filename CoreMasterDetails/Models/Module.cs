using System;
using System.Collections.Generic;

namespace CoreMasterDetails.Models;

public partial class Module
{
    public int ModuleId { get; set; }

    public string ModuleName { get; set; } = null!;

    public int Duration { get; set; }

    public int StudentId { get; set; }

    public virtual Student Student { get; set; } = null!;
}
