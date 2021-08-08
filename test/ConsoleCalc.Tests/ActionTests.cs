using Xunit;

namespace ConsoleCalc.Tests
{
    public class ActionTests
    {
        [Fact]
        void action00()
        {
            // arrange
            Scanner scan = new Scanner("2+6:2*3");
            Parser parsedScan = new Parser(scan.scanTokens());
            // act
            // assert
            Assert.Equal(11, parsedScan.result);
        }
        [Fact]
        void action01()
        {
            // arrange
            Scanner scan = new Scanner("7-2*0+5:5-2");
            Parser parsedScan = new Parser(scan.scanTokens());
            // assert
            Assert.Equal(6, parsedScan.result);
        }
        [Fact]
        void action02()
        {
            // arrange
            Scanner scan = new Scanner("2*(1+3)");
            Parser parsedScan = new Parser(scan.scanTokens());
            // assert
            Assert.Equal(8, parsedScan.result);
        }
        [Fact]
        void action03()
        {
            // arrange
            Scanner scan = new Scanner("2(1+3)");
            Parser parsedScan = new Parser(scan.scanTokens());
            // assert
            Assert.Equal(8, parsedScan.result);
        }
        [Fact]
        void action04()
        {
            // arrange
            Scanner scan = new Scanner("-99+1");
            Parser parsedScan = new Parser(scan.scanTokens());
            // assert
            Assert.Equal(-98, parsedScan.result); 
        }
        [Fact]
        void action05()
        {
            // arrange
            Scanner scan = new Scanner("(-99+1)*1=");
            Parser parsedScan = new Parser(scan.scanTokens());
            // assert
            Assert.Equal(-98, parsedScan.result); 
        }
    }
}