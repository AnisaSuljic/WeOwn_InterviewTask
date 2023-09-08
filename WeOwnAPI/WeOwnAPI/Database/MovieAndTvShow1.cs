using System;
using System.Collections.Generic;

namespace WeOwnAPI.Database;

public partial class MovieAndTvShow1
{
    public string? ShowId { get; set; }

    public string Type { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Director { get; set; } = null!;

    public string? Cast { get; set; }

    public string? Country { get; set; }

    public DateTime? DateAdded { get; set; }

    public int ReleaseYear { get; set; }

    public string Rating { get; set; } = null!;

    public string? Duration { get; set; }

    public string? ListedIn { get; set; }

    public string? Description { get; set; }

    public int Id { get; set; }
}
