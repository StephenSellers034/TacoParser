using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            
            var tacoParser = new TacoParser();

            
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            
            Assert.NotNull(actual);

        }

        [Theory]// Added theory for the test
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]// added inline data to test and ensure The Test produces the right results
        [InlineData("33.524131,-86.724876,Taco Bell Birmingham...", -86.724876)]
       
        public void ShouldParseLongitude(string line, double expected)// created method to test and parse Longitude
        {
           
            //Arrange - create instance
            var tacoParser = new TacoParser();
            //Act - call the method
            var actual = tacoParser.Parse(line);
            //Assert - Assert.Equal(e,a)
            Assert.Equal(expected, actual.Location.Longitude);//Had to add on Loca and Long with dot notation to actual because 
        }


       

        [Theory]
        [InlineData("33.858498, -84.60189, Taco Bell Austel...", 33.858498)]
        [InlineData("30.731386,-86.566652,Taco Bell Crestvie...", 30.731386)]
        [InlineData("31.236691,-85.459825,Taco Bell Dothan...", 31.236691)]

        public void ShouldParseLatitude(string line, double expected)
        {
            var tacoParser1 = new TacoParser();

            var actual = tacoParser1.Parse(line);

            Assert.Equal(expected, actual.Location.Latitude);
        }
    }
}
