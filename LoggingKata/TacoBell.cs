using System;
namespace LoggingKata
{   //created TacoBell class
    public class TacoBell : ITrackable //made TacoBell class conform to ITrackable 
	{
        public TacoBell(string name, Point location)
        {
            Name = Name;
            Location = Location;
        }
        public string Name { get; set; }
        public Point Location { get; set; }
    }
}


