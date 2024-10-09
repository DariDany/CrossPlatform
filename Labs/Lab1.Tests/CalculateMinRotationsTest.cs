using System;
using Xunit;

namespace Lab1.Tests
{
    public class FindLengthTests
    {
        [Fact]
        public void CalculateMinRotations_SimpleTest1()
        {
            // Arrange
            FindLength findLength = new FindLength();
            string a = "abc";
            string b = "bcd";

            // Act
            int result = findLength.CalculateMinRotations(a, b);

            // Assert
            Assert.Equal(3, result); 
        }

        [Fact]
        public void CalculateMinRotations_SimpleTest2()
        {
            // Arrange
            FindLength findLength = new FindLength();
            string a = "xyz";
            string b = "abc";

            // Act
            int result = findLength.CalculateMinRotations(a, b);

            // Assert
            Assert.Equal(9, result); 
        }

        [Fact]
        public void CalculateMinRotations_IdenticalStrings()
        {
            // Arrange
            FindLength findLength = new FindLength();
            string a = "abc";
            string b = "abc";

            // Act
            int result = findLength.CalculateMinRotations(a, b);

            // Assert
            Assert.Equal(0, result); 
        }

        [Fact]
        public void CalculateMinRotations_MixedCase()
        {
            // Arrange
            FindLength findLength = new FindLength();
            string a = "abCd";
            string b = "Azcd";

            // Act
            int result = findLength.CalculateMinRotations(a.ToLower(), b.ToLower());

            // Assert
            Assert.Equal(2, result); 
        }

        [Fact]
        public void CalculateMinRotations_AllSameCharacter()
        {
            // Arrange
            FindLength findLength = new FindLength();
            string a = "aaaa";
            string b = "zzzz";

            // Act
            int result = findLength.CalculateMinRotations(a, b);

            // Assert
            Assert.Equal(4, result); 
        }

        // Тест для перевірки виключення на різні довжини рядків
        [Fact]
        public void CalculateMinRotations_DifferentLength_ThrowsException()
        {
            // Arrange
            FindLength findLength = new FindLength();
            string a = "abc";
            string b = "abcd";

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => findLength.CalculateMinRotations(a, b));
            Assert.Equal("Рядки повинні бути однакової довжини.", exception.Message);
        }

        // Тест для перевірки виключення на довжину більше 105 символів
        [Fact]
        public void CalculateMinRotations_TooLongStrings_ThrowsException()
        {
            // Arrange
            FindLength findLength = new FindLength();
            string a = new string('a', 106); 
            string b = new string('b', 106);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => findLength.CalculateMinRotations(a, b));
            Assert.Equal("Довжина рядків не повинна перевищувати 105 символів.", exception.Message);
        }

        // Тест для перевірки виключення на наявність недопустимих символів
        [Fact]
        public void CalculateMinRotations_InvalidCharacters_ThrowsException()
        {
            // Arrange
            FindLength findLength = new FindLength();
            string a = "abc";
            string b = "a1c"; 

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => findLength.CalculateMinRotations(a, b));
            Assert.Equal("Рядки повинні містити лише маленькі букви англійського алфавіту.", exception.Message);
        }
    }
}
