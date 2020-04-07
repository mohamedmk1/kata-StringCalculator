using Kata3Solution;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace NUnitKata3
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Should_return_0_when_empty_string()
        {
            // Arrange
            StringCalculator sc = new StringCalculator();
            List<String> seperators = new List<string>();
            seperators.Add(",");
            int expectedResult = 0;

            // Act
            int actualResult = sc.AddNumber("", seperators);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void Should_return_3_when_string_is_3()
        {
            // Arrange
            StringCalculator sc = new StringCalculator();
            List<String> seperators = new List<string>();
            seperators.Add(",");
            int expectedResult = 3;

            // Act
            int actualResult = sc.AddNumber("3", seperators);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void Should_return_4_when_string_is_1_comma_3()
        {
            // Arrange
            StringCalculator sc = new StringCalculator();
            List<String> seperators = new List<string>();
            seperators.Add(",");
            int expectedResult = 4;

            // Act
            int actualResult = sc.AddNumber("1,3", seperators);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void Should_return_6_when_string_is_1_comma_3_comma_2()
        {
            // Arrange
            StringCalculator sc = new StringCalculator();
            List<String> seperators = new List<string>();
            seperators.Add(",");
            int expectedResult = 6;

            // Act
            int actualResult = sc.AddNumber("1,3,2", seperators);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void Should_return_6_when_string_is_1_newLine_3_newLine_2()
        {
            // Arrange
            StringCalculator sc = new StringCalculator();
            List<String> seperators = new List<string>();
            seperators.Add("\n");
            int expectedResult = 6;

            // Act
            int actualResult = sc.AddNumber("1\n3\n2", seperators);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void Should_return_8_when_string_is_1_comma_3_newLine_4()
        {
            // Arrange
            StringCalculator sc = new StringCalculator();
            int expectedResult = 8;
            List<String> seperators = new List<string>();
            seperators.Add(",");
            seperators.Add("\n");

            // Act
            int actualResult = sc.AddNumber("1,3\n4", seperators);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void Should_catch_exception_when_string_is_1_comma_newLine()
        {
            // Arrange
            StringCalculator sc = new StringCalculator();
            List<String> seperators = new List<string>();
            string expectedErrorMessage = "The following input is not ok";
            seperators.Add(",");
            seperators.Add("\n");

            // Act
            var exception = Assert.Throws<Exception>(() => sc.AddNumber("1,\n", seperators));

            // Assert
            Assert.AreEqual(exception.Message, expectedErrorMessage);
        }

        [Test]
        public void Should_return_9_when_string_is_1_comma_4_tab_4()
        {
            // Arrange
            StringCalculator sc = new StringCalculator();
            int expectedResult = 9;
            List<String> seperators = new List<string>();
            seperators.Add(",");
            seperators.Add("\t");

            // Act
            int actualResult = sc.AddNumber("1,4\t4", seperators);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void Should_return_5_when_string_is_delimeter_1_comma_4()
        {
            // Arrange
            StringCalculator sc = new StringCalculator();
            int expectedResult = 3;
            List<String> seperators = new List<string>();
            seperators.Add(";");

            // Act
            int actualResult = sc.AddNumber("//;\n1;2", seperators);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void Should_catch_exception_when_string_is_1_comma_minus_4()
        {
            // Arrange
            StringCalculator sc = new StringCalculator();
            List<String> seperators = new List<string>();
            string expectedErrorMessage = "negatives not allowed: -4";
            seperators.Add(",");

            // Act
            var exception = Assert.Throws<Exception>(() => sc.AddNumber("1,-4", seperators));

            // Assert
            Assert.AreEqual(exception.Message, expectedErrorMessage);
        }

        [Test]
        public void Should_catch_exception_when_string_is_1_comma_minus_4_comma_minus_3()
        {
            // Arrange
            StringCalculator sc = new StringCalculator();
            List<String> seperators = new List<string>();
            string expectedErrorMessage = "negatives not allowed: -4 -3";
            seperators.Add(",");

            // Act
            var exception = Assert.Throws<Exception>(() => sc.AddNumber("1,-4,-3", seperators));

            // Assert
            Assert.AreEqual(exception.Message, expectedErrorMessage);
        }

        [Test]
        public void Should_return_3_when_string_is_delimeter_3_comma_1001()
        {
            // Arrange
            StringCalculator sc = new StringCalculator();
            int expectedResult = 3;
            List<String> seperators = new List<string>();
            seperators.Add(";");

            // Act
            int actualResult = sc.AddNumber(@"//;\n3;1001", seperators);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void Should_return_6_when_string_is_delimeters_newLine_delimeters_2_delimeters_3()
        {
            // Arrange
            StringCalculator sc = new StringCalculator();
            List<String> seperators = new List<String>();
            int expectedResult = 6;

            // Act
            int actualResult = sc.AddNumber(@"//[***]\n1***2***3", seperators);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void Should_catch_exception_when_string_is_not_good()
        {
            // Arrange
            StringCalculator sc = new StringCalculator();
            List<String> seperators = new List<string>();
            string expectedErrorMessage = "The delimeters must be the same";

            // Act
            var exception = Assert.Throws<Exception>(() => sc.AddNumber("//[***]\n1***2****3", seperators));

            // Assert
            Assert.AreEqual(exception.Message, expectedErrorMessage);
        }

        [Test]
        public void Should_return_10_when_string_is_delimeter1_delimeter2_newLine_2_delimeter1_3_delimeter2_5()
        {
            // Arrange
            StringCalculator sc = new StringCalculator();
            List<String> seperators = new List<String>();
            int expectedResult = 10;

            // Act
            int actualResult = sc.AddNumber(@"//[*][%]\n2*3%5", seperators);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }

    }
}