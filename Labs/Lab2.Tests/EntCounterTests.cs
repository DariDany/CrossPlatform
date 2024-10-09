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
        public class EntCounterExceptionTests
        {
            [Fact]
            public void EntCounter_InvalidK_ThrowsArgumentOutOfRangeException()
            {
                // Arrange
                int invalidK = 0; // K не може бути 0 (має бути ≥ 1)
                int p = 100;

                // Act & Assert
                Assert.Throws<ArgumentOutOfRangeException>(() => new EntCounter(invalidK, p));
            }

            [Fact]
            public void EntCounter_InvalidP_ThrowsArgumentOutOfRangeException()
            {
                // Arrange
                int k = 10;
                int invalidP = 0; // P не може бути 0 (має бути ≥ 1)

                // Act & Assert
                Assert.Throws<ArgumentOutOfRangeException>(() => new EntCounter(k, invalidP));
            }

            [Fact]
            public void EntCounter_KOutOfRange_ThrowsArgumentOutOfRangeException()
            {
                // Arrange
                int outOfRangeK = 1000001; // K не може бути більше 10^6
                int p = 100;

                // Act & Assert
                Assert.Throws<ArgumentOutOfRangeException>(() => new EntCounter(outOfRangeK, p));
            }

            [Fact]
            public void EntCounter_POutOfRange_ThrowsArgumentOutOfRangeException()
            {
                // Arrange
                int k = 1000;
                int outOfRangeP = 1000000001; // P не може бути більше 10^9

                // Act & Assert
                Assert.Throws<ArgumentOutOfRangeException>(() => new EntCounter(k, outOfRangeP));
            }

            [Fact]
            public void ReadInput_IncorrectInputFormat_ThrowsFormatException()
            {
                // Arrange
                string invalidInputFile = "invalidInput.txt";
                File.WriteAllText(invalidInputFile, "invalid_data"); // Некоректний формат даних

                // Act & Assert
                Assert.Throws<FormatException>(() => EntCounter.ReadInput(invalidInputFile));
            }

            [Fact]
            public void ReadInput_MissingValues_ThrowsFormatException()
            {
                // Arrange
                string invalidInputFile = "missingValuesInput.txt";
                File.WriteAllText(invalidInputFile, "100"); // Вхідний файл містить лише одне число

                // Act & Assert
                Assert.Throws<FormatException>(() => EntCounter.ReadInput(invalidInputFile));
            }

            [Fact]
            public void ReadInput_NonIntegerValues_ThrowsFormatException()
            {
                // Arrange
                string invalidInputFile = "nonIntegerValuesInput.txt";
                File.WriteAllText(invalidInputFile, "10 abc"); // Вхідний файл містить нецілі числа

                // Act & Assert
                Assert.Throws<FormatException>(() => EntCounter.ReadInput(invalidInputFile));
            }
        }

    }

}