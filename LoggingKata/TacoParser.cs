namespace LoggingKata
{
    
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            
            var cells = line.Split(',');//creating the split of string cells into substrings

           

            
            double latitude = double.Parse(cells[0]);//created substring for latitude and parsed to double

            
            double longitude = double.Parse(cells[1]);// substring created for lonitude and parsed to double

            
            string name = cells[2];// created substring name for 3rd substring created

             
            Point location = new Point() // created new instance of Point class 
            {
                Latitude = latitude,// set values using object initializer 
                Longitude = longitude


            };

            
            TacoBell tacoBell = new TacoBell(name, location);// new instance with paramters

            tacoBell.Location = location;// assigned values to new instance used dot notation to 
            tacoBell.Name = name;

            
            return tacoBell; //returning my instance
        }
    }
}
