using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
             

            logger.LogInfo("Log initialized");

            
            var lines = File.ReadAllLines(csvPath);

            
            logger.LogInfo($"Lines: {lines[0]}");// Displaying the first item in lines array functions like Console.WriteLine()

            
            var parser = new TacoParser();// New instance of TacoParser class

            
            var locations = lines.Select(parser.Parse).ToArray();// Use the Select LINQ method to parse every line in lines collection




            ITrackable tacoBell1 = null;//New ITrackable varibales with initial value of null
            ITrackable tacoBell2 = null;

            
            double distance = 0;//storing the distance in a double variable

            

            for (int i = 0; i < locations.Length; i++) //created for loop to go through colleciton
            {
                var locA = locations[i];//created new variable to act as starting point of locations[i] 
                var corA = new GeoCoordinate();//created new instance of the GeoCoordinate
                corA.Latitude = locA.Location.Latitude;// corA new object being given value 
                corA.Longitude = locA.Location.Longitude;//new instance of Geocoordinate with values

                for (int s = 0; s < locations.Length; s++)
                {
                    var locB = locations[s];
                    var corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);// have to put the location and latitude inside parameter this time to instanciate and give values

                    if (corA.GetDistanceTo(corB) > distance)// use if statement to get the distance with the .GetDistanceTo() method
                    {
                        distance = corA.GetDistanceTo(corB);
                        tacoBell1 = locA;// updateing distance 
                        tacoBell2 = locB;
                    }

                }

            }



            // TODO: Once you have locA, create a new Coordinate object called `corA` with your locA's latitude and longitude.

            // SECOND FOR LOOP -
            // TODO: Now, Inside the scope of your first loop, create another loop to iterate through locations again.
            // This allows you to pick a "destination" location for each "origin" location from the first loop. 
            // Naming suggestion for variable: `locB`

            // TODO: Once you have locB, create a new Coordinate object called `corB` with your locB's latitude and longitude.

            // TODO: Now, still being inside the scope of the second for loop, compare the two locations using `.GetDistanceTo()` method, which returns a double.
            // If the distance is greater than the currently saved distance, update the distance variable and the two `ITrackable` variables you set above.

            // NESTED LOOPS SECTION COMPLETE ---------------------

            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.
            // Display these two Taco Bell locations to the console.

            logger.LogInfo($"This Taco Bell :{tacoBell1.Name} is {distance} meters away from {tacoBell2.Name}");
            // used logger.LogInfo as if its Console.WriteLine() to display the locations to the console

        }
    }
}
