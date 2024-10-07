using System.Diagnostics.Tracing;

namespace Lab2.Tests
{
    public class EntCounterTests
    {
        [Fact]
        public void CountEnts_SimpleTest1()
        {
            // Arrange
            int k = 4;
            int p = 10;
            EntCounter entCounter = new EntCounter(k, p);

            // Act
            long result = entCounter.CountEnts();

            // Assert
            Assert.Equal(2, result); 
        }

        [Fact]
        public void CountEnts_SimpleTest2()
        {
            // Arrange
            int k = 8;
            int p = 10;
            EntCounter entCounter = new EntCounter(k, p);

            // Act
            long result = entCounter.CountEnts();

            // Assert
            Assert.Equal(5, result); 
        }

        [Fact]
        public void CountEnts_LargerTest()
        {
            // Arrange
            int k = 360;
            int p = 1000;
            EntCounter entCounter = new EntCounter(k, p);

            // Act
            long result = entCounter.CountEnts();

            // Assert
            Assert.Equal(179, result); 
        }

        [Fact]
        public void CountEnts_ZeroWordsTest()
        {
            // Arrange
            int k = 1; 
            int p = 100;
            EntCounter entCounter = new EntCounter(k, p);

            // Act
            long result = entCounter.CountEnts();

            // Assert
            Assert.Equal(0, result); 
        }
    }
}