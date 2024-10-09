namespace Lab3.Tests
{
    public class RectangleAreaSolverTests
    {
        [Fact]
        public void FindMaxArea_SimpleTest1()
        {
            // Arrange
            RectangleAreaSolver solver = new RectangleAreaSolver();
            string inputFile = "input1.txt";
            string outputFile = "output1.txt";
            string[] input = {
                "2",
                "0 0 2 2",
                "1 1 3 3"
            };
            File.WriteAllLines(inputFile, input);

            // Act
            solver.ReadInput(inputFile);
            int result = solver.FindMaxArea();
            solver.WriteOutput(outputFile, result);

            // Assert
            Assert.Equal(7, result); 
        }

        [Fact]
        public void FindMaxArea_SimpleTest2()
        {
            // Arrange
            RectangleAreaSolver solver = new RectangleAreaSolver();
            string inputFile = "input2.txt";
            string outputFile = "output2.txt";
            string[] input = {
                "3",
                "0 0 1 1",
                "2 2 3 3",
                "4 4 5 5"
            };
            File.WriteAllLines(inputFile, input);

            // Act
            solver.ReadInput(inputFile);
            int result = solver.FindMaxArea();
            solver.WriteOutput(outputFile, result);

            // Assert
            Assert.Equal(1, result); 
        }

        [Fact]
        public void FindMaxArea_LargerTest()
        {
            // Arrange
            RectangleAreaSolver solver = new RectangleAreaSolver();
            string inputFile = "input3.txt";
            string outputFile = "output3.txt";
            string[] input = {
                "4",
                "0 0 5 5",
                "1 1 4 4",
                "2 2 3 3",
                "6 6 7 7"
            };
            File.WriteAllLines(inputFile, input);

            // Act
            solver.ReadInput(inputFile);
            int result = solver.FindMaxArea();
            solver.WriteOutput(outputFile, result);

            // Assert
            Assert.Equal(25, result); 
        }

        [Fact]
        public void FindMaxArea_OverlappingRectanglesTest()
        {
            // Arrange
            RectangleAreaSolver solver = new RectangleAreaSolver();
            string inputFile = "input4.txt";
            string outputFile = "output4.txt";
            string[] input = {
                "3",
                "0 0 1 1",
                "1 2 3 4",
                "2 2 4 3"
            };
            File.WriteAllLines(inputFile, input);

            // Act
            solver.ReadInput(inputFile);
            int result = solver.FindMaxArea();
            solver.WriteOutput(outputFile, result);

            // Assert
            Assert.Equal(5, result); 
        }
        [Fact]
        public void FindMaxArea_TouchingCornersTest()
        {
            // Arrange
            RectangleAreaSolver solver = new RectangleAreaSolver();
            string inputFile = "input5.txt";
            string outputFile = "output5.txt";
            string[] input = {
        "2",
        "0 0 1 1",
        "1 1 2 2"
    };
            File.WriteAllLines(inputFile, input);

            // Act
            solver.ReadInput(inputFile);
            int result = solver.FindMaxArea();
            solver.WriteOutput(outputFile, result);

            // Assert
            Assert.Equal(1, result); 
        }

        [Fact]
        public void FindMaxArea_SingleRectangleTest()
        {
            // Arrange
            RectangleAreaSolver solver = new RectangleAreaSolver();
            string inputFile = "input6.txt";
            string outputFile = "output6.txt";
            string[] input = {
        "1",
        "0 0 2 2"
    };
            File.WriteAllLines(inputFile, input);

            // Act
            solver.ReadInput(inputFile);
            int result = solver.FindMaxArea();
            solver.WriteOutput(outputFile, result);

            // Assert
            Assert.Equal(4, result); 
        }

        [Fact]
        public void ReadInput_TooManyRectangles_ThrowsException()
        {
            // Arrange
            RectangleAreaSolver solver = new RectangleAreaSolver();
            string inputFile = "input_too_many.txt";
            string[] input = {
                "26",  
                "0 0 1 1"
            };
            File.WriteAllLines(inputFile, input);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => solver.ReadInput(inputFile));
            Assert.Equal("Неправильна кількість прямокутників. Має бути від 1 до 25.", exception.Message);
        }
        [Fact]
        public void ReadInput_RectangleWithInvalidCoordinates_ThrowsException()
        {
            // Arrange
            RectangleAreaSolver solver = new RectangleAreaSolver();
            string inputFile = "input_invalid_coords.txt";
            string[] input = {
                "1",
                "0 0 101 101"  
            };
            File.WriteAllLines(inputFile, input);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => solver.ReadInput(inputFile));
            Assert.Equal("Координати мають бути цілими числами в діапазоні від 0 до 100.", exception.Message);
        }

    
        [Fact]
        public void ReadInput_InvalidInputFormat_ThrowsException()
        {
            // Arrange
            RectangleAreaSolver solver = new RectangleAreaSolver();
            string inputFile = "input_invalid_format.txt";
            string[] input = {
                "1",
                "0 0 1"  
            };
            File.WriteAllLines(inputFile, input);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => solver.ReadInput(inputFile));
            Assert.Equal("Неправильний формат введення для координат прямокутника.", exception.Message);
        }

        
        [Fact]
        public void ReadInput_InvalidRectangleCoordinates_ThrowsException()
        {
            // Arrange
            RectangleAreaSolver solver = new RectangleAreaSolver();
            string inputFile = "input_invalid_rectangle_coords.txt";
            string[] input = {
                "1",
                "2 2 1 1"  
            };
            File.WriteAllLines(inputFile, input);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => solver.ReadInput(inputFile));
            Assert.Equal("Неправильні координати прямокутника. Повинно бути X1 < X2 і Y1 < Y2.", exception.Message);
        }

        [Fact]
        public void ReadInput_TooFewRectangles_ThrowsException()
        {
            // Arrange
            RectangleAreaSolver solver = new RectangleAreaSolver();
            string inputFile = "input_too_few.txt";
            string[] input = {
                "0"  
            };
            File.WriteAllLines(inputFile, input);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => solver.ReadInput(inputFile));
            Assert.Equal("Неправильна кількість прямокутників. Має бути від 1 до 25.", exception.Message);
        }
    }
}