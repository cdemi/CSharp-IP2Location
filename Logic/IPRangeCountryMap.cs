using CsvHelper.Configuration;

namespace IP2Location
{
    internal sealed class IPRangeCountryMap : CsvClassMap<IPRangeCountry>
    {
        public IPRangeCountryMap()
        {
            Map(m => m.StartIP).Index(0);
            Map(m => m.EndIP).Index(1);
            Map(m => m.ISO_Code_2).Index(2);
        }
    }
}
