CSharp-IP2Location
==================

Gets [ip2location.com Lite DB1](http://lite.ip2location.com/database-ip-country) as a typed List to save in your database or cache or whatever your persistent storage is.

Usage
-----
First you need to build this from source or download this package from NuGet: <https://www.nuget.org/packages/IP2Location>

After you have included this library all you have to do is call the Download method from IP2LocationHandler: 
`List<IPRangeCountry> range = IP2LocationHandler.Download();`
