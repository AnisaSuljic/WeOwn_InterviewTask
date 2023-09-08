using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeOwnDomain.Database;

namespace WeOwnInfra.SeedData
{
    public class CsvHeaderMap : ClassMap<MovieAndTvShow>
    {
        public CsvHeaderMap()
        {
            Map(m => m.ShowId).Name("show_id");
            Map(m => m.Type).Name("type");
            Map(m => m.Title).Name("title");
            Map(m => m.Director).Name("director");
            Map(m => m.Cast).Name("cast");
            Map(m => m.Country).Name("country");
            Map(m => m.DateAdded).Name("date_added");
            Map(m => m.ReleaseYear).Name("release_year");
            Map(m => m.Rating).Name("rating");
            Map(m => m.Duration).Name("duration");
            Map(m => m.ListedIn).Name("listed_in");
            Map(m => m.Description).Name("description");
        }
    }
}
