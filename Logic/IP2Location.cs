using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using CsvHelper;
using Ionic.Zip;

namespace Logic
{
    public static class IP2Location
    {
        public static List<IPRangeCountry> Download()
        {
            using (var client = new WebClient())
            {
                byte[] zippedData =
                    client.DownloadData("http://download.ip2location.com/lite/IP2LOCATION-LITE-DB1.CSV.ZIP");

                using (var zippedFileStream = new MemoryStream(zippedData))
                using (ZipFile zipFile = ZipFile.Read(zippedFileStream))
                {
                    ZipEntry compressedFileInZip = zipFile.SelectEntries("*.csv").FirstOrDefault();
                    using (var csvStream = new MemoryStream())
                    {
                        compressedFileInZip.Extract(csvStream);
                        csvStream.Position = 0;
                        using (var textReader = new StreamReader(csvStream))
                        using (var csv = new CsvReader(textReader))
                        {
                            csv.Configuration.RegisterClassMap<IPRangeCountryMap>();
                            csv.Configuration.HasHeaderRecord = false;
                            csv.Read();
                            return csv.GetRecords<IPRangeCountry>().ToList();
                        }
                    }
                }
            }
        }
    }
}