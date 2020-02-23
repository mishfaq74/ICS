using ICS.Questions;
using System;
using System.Collections.Generic;
using Xunit;

namespace ICS.Tests
{
    public class UnitTests
    {
        [Theory]
        [InlineData("Apple", Fruit.Apple)]
        [InlineData("Orange", Fruit.Orange)]
        [InlineData("Banana", null)]
        public void Question2_Tests(string input ,Fruit? fruit)
        {
            //Arrange
            //Act
            Fruit? result = input.ConvertToEnum<Fruit>();
            //Assert
            Assert.Equal(result, fruit);
        }
        [Fact]
        public void Question3_Tests()
        {
            //Arrange
            List<string[]> lisOfArray = new List<string[]>
            {
                new string[] { "ABC","DEF","GHI"},
                new string[] { "ABC", "KLM", "GHI"},
                new string[] { "ABC", "QRS", "STU"},
                new string[] { "ABC", "VXY", "Z12","345"},
            };
            //Act
            var result = (new Answers().Answer3(lisOfArray));
            //Assert
            Assert.Equal(9,result.Length);

        }
    }
}
