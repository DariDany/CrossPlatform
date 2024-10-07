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
            Assert.Equal(3, result); // 1 + 1 + 1 = 3
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
            Assert.Equal(9, result); // 3 forward rotations for each letter
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
            Assert.Equal(0, result); // No rotations needed for identical strings
        }

        [Fact]
        public void CalculateMinRotations_MixedCase()
        {
            // Arrange
            FindLength findLength = new FindLength();
            string a = "abCd";
            string b = "Azcd";

            // Act
            int result = findLength.CalculateMinRotations(a, b);

            // Assert
            Assert.Equal(2, result); // 1 rotation for 'b' to 'z', rest are identical
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
            Assert.Equal(4, result); // Each 'a' to 'z' requires 1 backward rotation
        }
    }
}

