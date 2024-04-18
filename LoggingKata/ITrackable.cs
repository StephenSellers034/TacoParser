using System;

namespace LoggingKata
{
    public interface ITrackable //created interface with properties did not set values
    {
        string Name { get; set; }
        Point Location { get; set; }
    }
}