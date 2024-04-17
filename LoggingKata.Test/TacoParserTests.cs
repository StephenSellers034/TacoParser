using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("33.524131,-86.724876,Taco Bell Birmingham...", -86.724876)]
        //Add additional inline data. Refer to your CSV file.
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete the test with Arrange, Act, Assert steps below.
            //       Note: "line" string represents input data we will Parse 
            //       to extract the Longitude.  
            //       Each "line" from your .csv file
            //       represents a TacoBell location

            //Arrange
            var tacoParser = new TacoParser();
            //Act
            var actual = tacoParser.Parse(line);
            //Assert
            Assert.Equal(expected, actual.Location.Longitude);
        }


        //TODO: Create a test called ShouldParseLatitude

        [Theory]
        [InlineData("33.858498, -84.60189, Taco Bell Austel...", 33.858498)]
        [InlineData("30.731386,-86.566652,Taco Bell Crestvie...", 30.731386)]
        [InlineData("31.236691,-85.459825,Taco Bell Dothan...", 31.236691)]

        public void ShouldParseLatitude(string line, double expected)
        {
            var tacoParser1 = new TacoParser();//Arrange three As

            var actual = tacoParser1.Parse(line);

            Assert.Equal(expected, actual.Location.Latitude);
        }
    }
}
