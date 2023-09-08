using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeOwnDomain.Database;

namespace WeOwnInfra.SeedData
{
    public sealed class WeOwnContextSeed 
    {
        public static async Task SeedAsync(WeOwnContext _context)
        {            
            try
            {
                var csvRecords = new List<MovieAndTvShow>();

                using (var reader = new StreamReader("WeOwnData1.csv"))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";",
                }))
                {
                    csv.Context.RegisterClassMap<CsvHeaderMap>(); 
                    var records = csv.GetRecords<MovieAndTvShow>().ToList();

                    csvRecords = records;
                }

                if (!_context.MovieAndTvShows.Any())
                {
                    _context.MovieAndTvShows.AddRange(csvRecords);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw new Exception("Something went wrong with your request");
            }
        }
    }
}
