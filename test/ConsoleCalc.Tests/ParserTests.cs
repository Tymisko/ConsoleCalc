using Xunit;

namespace ConsoleCalc.Tests
{
    public class ParserTests
    {
        [Fact]
        void parsingTest()
        {
            // arrange
            Scanner scan = new Scanner("2+(5-3)*2");
            Parser parsedScan = new Parser(scan.scanTokens());
            // act
            // assert
            Assert.Equal(6, parsedScan.result);
        }
    }
}